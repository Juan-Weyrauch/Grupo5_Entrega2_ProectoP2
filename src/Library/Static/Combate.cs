using ClassLibrary;
using Library.Static;

using System;
using System.Linq;
using Library.Static;

namespace Library
{
    public static class Combate
    {
        static IVisitor _infoVisitor = new InfoVisitor();

        public static IPlayer _jugadorActual;
        public static IPlayer _jugadorRival;
        public static IPokemon _pokemonActual;
        public static IPokemon _pokemonRival;

        public static void DeterminarTurno(IPlayer jugador1, IPlayer jugador2)
        {
            int turno = 0;
            while (Calculator.CombatValidation(jugador1, jugador2))
            {
                // Es turno del jugador 1
                Console.WriteLine($"Es turno del jugador {jugador1.Name}");
                Combatir(jugador1, jugador2);
                
                // Verifica si el combate terminó después del turno del jugador 1
                if (!Calculator.CombatValidation(jugador1, jugador2)) break;
                
                // Es turno del jugador 2
                Console.WriteLine($"Es turno del jugador {jugador2.Name}");
                Combatir(jugador2, jugador1);

                // Verifica si el combate terminó después del turno del jugador 2
                if (!Calculator.CombatValidation(jugador1, jugador2)) break;
            }
        }

        private static void Combatir(IPlayer jugadorActual, IPlayer jugadorRival)
        {
            int contadorEAtaquesEspeciales;
            IPokemon pokemonActual = jugadorActual.SelectedPokemon;
            IPokemon pokemonRival = jugadorRival.SelectedPokemon;
            _pokemonActual = jugadorActual.SelectedPokemon;
            _pokemonRival = jugadorRival.SelectedPokemon;
            int estadoDelPokemon = Calculator.ChequearEstado(pokemonActual);
    
            // Chequeo si aun tiene pokemons
            int estadoDelEquipo = Calculator.IndividualcombatValidation(jugadorActual.Equipo);
            if (pokemonActual.Health == 0 && estadoDelEquipo == 0) // Si no puede seguir jugando, termina el juego.
            {
                ImpresoraDeTexto.FinDelJuego(jugadorRival.Name);
            }
            else if ((pokemonActual.Health > 0 || estadoDelEquipo > 0) && estadoDelPokemon == 0 ) // Si sigue con pokemons en estado normal
            {
                if (pokemonActual.Health <= 0) // Si el Pokémon actual está fuera de combate, debe elegir otro.
                {
                    Console.WriteLine($"Tu Pokémon {pokemonActual.Name} ha sido derrotado.");
                    Console.WriteLine("Debes seleccionar otro Pokémon: ");
                    ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);

                    while (true)
                    {
                        Console.WriteLine("Por favor selecciona un pokemon:");
                        if (int.TryParse(Console.ReadLine(), out int pokemonSeleccionado) &&
                            pokemonSeleccionado >= 0 && pokemonSeleccionado < jugadorActual.Equipo.Count &&
                            jugadorActual.Equipo[pokemonSeleccionado].Health > 0)
                        {
                            jugadorActual.SelectedPokemon = jugadorActual.Equipo[pokemonSeleccionado];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Selección no válida. Ingresa un número correspondiente a un Pokémon con salud.");
                        }
                    }
                }
                
                // Si el Pokémon está bien y listo, se continúa con la acción
                IniciarAccion(jugadorActual, jugadorRival);
            }
        }

        private static void IniciarAccion(IPlayer jugadorActual, IPlayer jugadorRival)
        {
            int contadorAtaquesEspeciales;
            IPokemon pokemonActualJugador = jugadorActual.SelectedPokemon;
            IPokemon pokemonActualRival = jugadorRival.SelectedPokemon;

            // Solicita al jugador su movimiento
            // Esto permite imprimir que pokemon tiene el jugador ahora mismo.
            string seleccion = ImpresoraDeTexto.TurnoJugador(jugadorActual.Name,pokemonActualJugador.Name,pokemonActualJugador.Health,pokemonActualJugador.InicialHealth);
            
            // A = Atacar, B = Cambiar Pokémon, C = Usar Item
            if (seleccion == "A")
            {
                Console.WriteLine("¿Con qué deseas atacar?");
                ImpresoraDeTexto.MostrarAtaques(jugadorActual);

                int ataqueSeleccionado = Convert.ToInt16(Console.ReadLine()) -1 ; // Para desbugear los ataques.

                // Validar que la selección de ataque sea válida
                ataqueSeleccionado = Calculator.ValidAtackSelection(ataqueSeleccionado, jugadorActual.SelectedPokemon);

                IAtaque ataquePokemon = pokemonActualJugador.Ataques[ataqueSeleccionado];

                // Si el ataque no es especial, realiza el ataque directo
                if (ataquePokemon.Especial == 0)
                {
                    int damage = Calculator.CalcularDañoPorTipo(jugadorActual.SelectedPokemon, jugadorRival.SelectedPokemon, ataquePokemon);
                    pokemonActualRival.DecreaseHealth(damage);
                    ImpresoraDeTexto.MostrarAtaques(jugadorActual);
                    ImpresoraDeTexto.PokemonAtacado(pokemonActualRival.Name,pokemonActualJugador.Name,ataquePokemon.Name);
                    if (pokemonActualRival.Health == 0)
                    {
                        ImpresoraDeTexto.MuerteDelPokemon(pokemonActualRival);
                        jugadorRival.EliminarPokemon(pokemonActualRival);
                    }
                }
                else
                {
                    // Si el ataque es especial, aplica efectos especiales
                    EfectuarAtaqueEspecial(jugadorActual, jugadorRival, ataquePokemon);
                }
            }
            // B = Cambiar de Pokémon
            else if (seleccion == "B")
            {
                Console.WriteLine("¿A qué Pokémon deseas cambiar?");
                ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);
                int pokemonSeleccionado = Convert.ToInt16(Console.ReadLine());
                // Imprime el pokemon  a que ha sido cambiado el juego:
                
                // Actualiza el Pokémon seleccionado
                jugadorActual.SelectedPokemon = jugadorActual.Equipo[pokemonSeleccionado];
                ImpresoraDeTexto.CambiarPokemon(pokemonActualJugador.Name, jugadorActual.SelectedPokemon.Name); // Hay que cambiarlo por un visitor
            }
            // C = Usar Item
            else if (seleccion == "C")
            {
                Console.WriteLine("¿Qué item deseas usar?");
                int inventoryStatus = ImpresoraDeTexto.ImprimirItems(jugadorActual.Inventario);

                if (inventoryStatus == 0) // Si no tiene ítems para usar
                {
                    // Aquí tampoco necesitas hacer otra llamada a IniciarAccion.
                }
                else if (inventoryStatus == 1) // Si tiene ítems para usar
                {
                    int itemSeleccionado = Convert.ToInt16(Console.ReadLine());
                    jugadorActual.UsarItem(itemSeleccionado, jugadorActual.SelectedPokemon);
                }
            }

            // El flujo regresa al siguiente turno
        }
        
        /// <summary>
        /// Este método setea el estado del Pokémon rival solamente si el ataque utilizado es 'especial'
        /// </summary>
        /// <param name="jugadorActual"></param>
        /// <param name="jugadorRival"></param>
        /// <param name="ataque"></param>
        private static void EfectuarAtaqueEspecial(IPlayer jugadorActual, IPlayer jugadorRival, IAtaque ataque)
        {
            IAtaque ataqueActual = ataque;
            int tipo = ataqueActual.Especial;
            string nombreAtaque = ataqueActual.Name;
            string nombrePoke = jugadorRival.SelectedPokemon.Name;

            // Generador de número aleatorio
            Random rnd = new Random();
    
            if (tipo == 1) // Quemar
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 1);
                int damage = (int)Math.Round(jugadorRival.SelectedPokemon.Health * 0.10); // daño del 10%
                jugadorRival.SelectedPokemon.DecreaseHealth(damage);
                jugadorRival.SelectedPokemon.CambiarEstado(1); // Estado quemado
            }
            else if (tipo == 2) // Envenenar
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 2);
                int damage = (int)Math.Round(jugadorRival.SelectedPokemon.Health * 0.05); // daño del 5%
                jugadorRival.SelectedPokemon.DecreaseHealth(damage);
                jugadorRival.SelectedPokemon.CambiarEstado(2); // Estado envenenado
            }
            else if (tipo == 3) // Paralizar
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 3);
                jugadorRival.SelectedPokemon.CambiarEstado(3); // Estado paralizado
            }
            else if (tipo == 4) // Dormir
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 4);
                jugadorRival.SelectedPokemon.CambiarEstado(4); // Estado dormido
                jugadorRival.SelectedPokemon.TurnosDormido = rnd.Next(1, 4); // Duerme entre 1 y 3 turnos
            }
        }
        
        public static void RealizarAtaque(IPokemon atacante, IPokemon defensor, IAtaque ataque)
        {
            // Verifica si el Pokémon atacante puede atacar antes de realizar el ataque
            if (!atacante.PuedeAtacar())
            {
                Console.WriteLine($"{atacante.Name} no puede realizar el ataque debido a su estado.");
                return; // Sale del método si el Pokémon no puede atacar
            }

            // Si el Pokémon puede atacar, procede con el ataque
            defensor.DecreaseHealth(ataque.Poder);
            Console.WriteLine($"{atacante.Name} ataca a {defensor.Name} con {ataque.Name} causando {ataque.Poder} de daño.");
        }


    }
}
