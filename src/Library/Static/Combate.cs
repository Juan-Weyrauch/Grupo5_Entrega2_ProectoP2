using System;
using ClassLibrary;
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
                    SeleccionarNuevoPokemon(jugadorActual);
                }
                
                // Si el Pokémon está bien y listo, se continúa con la acción
                IniciarAccion(jugadorActual, jugadorRival);
            }
        }

        private static void IniciarAccion(IPlayer jugadorActual, IPlayer jugadorRival)
        {
            IPokemon pokemonActualJugador = jugadorActual.SelectedPokemon;
            IPokemon pokemonActualRival = jugadorRival.SelectedPokemon;

            // Solicita al jugador su movimiento
            string seleccion = ImpresoraDeTexto.TurnoJugador(jugadorActual.Name, pokemonActualJugador.Name, pokemonActualJugador.Health, pokemonActualJugador.InicialHealth);
            
            // A = Atacar, B = Cambiar Pokémon, C = Usar Item
            if (seleccion == "A")
            {
                Console.WriteLine("¿Con qué deseas atacar?");
                ImpresoraDeTexto.MostrarAtaques(jugadorActual);

                int ataqueSeleccionado = Convert.ToInt16(Console.ReadLine()) - 1;
                ataqueSeleccionado = Calculator.ValidAtackSelection(ataqueSeleccionado, jugadorActual.SelectedPokemon);

                IAtaque ataquePokemon = pokemonActualJugador.Ataques[ataqueSeleccionado];

                // Si el ataque no es especial, realiza el ataque directo
                if (ataquePokemon.Especial == 0)
                {
                    int damage = Calculator.CalcularDañoPorTipo(jugadorActual.SelectedPokemon, jugadorRival.SelectedPokemon, ataquePokemon);
                    pokemonActualRival.DecreaseHealth(damage);
                    Console.WriteLine($"{pokemonActualJugador.Name} atacó a {pokemonActualRival.Name} causando {damage} puntos de daño.");

                    if (pokemonActualRival.Health == 0)
                    {
                        Console.WriteLine($"{pokemonActualRival.Name} ha sido derrotado.");
                        jugadorRival.EliminarPokemon(pokemonActualRival);
                        ImpresoraDeTexto.MuerteDelPokemon(pokemonActualRival);
                        SeleccionarNuevoPokemon(jugadorRival);
                    }
                }
                else
                {
                    // Si el ataque es especial, aplica efectos especiales
                    EfectuarAtaqueEspecial(jugadorActual, jugadorRival, ataquePokemon);
                }
            }
            else if (seleccion == "B") // Cambiar Pokémon
            {
                CambiarPokemon(jugadorActual);
            }
            else if (seleccion == "C") // Usar Item
            {
                UsarItem(jugadorActual);
            }
        }
        
        private static void EfectuarAtaqueEspecial(IPlayer jugadorActual, IPlayer jugadorRival, IAtaque ataque)
        {
            IAtaque ataqueActual = ataque;
            int tipo = ataqueActual.Especial;
            string nombreAtaque = ataqueActual.Name;
            string nombrePoke = jugadorRival.SelectedPokemon.Name;

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
            if (!atacante.PuedeAtacar())
            {
                Console.WriteLine($"{atacante.Name} no puede realizar el ataque debido a su estado.");
                return;
            }

            defensor.DecreaseHealth(ataque.Poder);
            Console.WriteLine($"{atacante.Name} ataca a {defensor.Name} con {ataque.Name} causando {ataque.Poder} de daño.");
        }

        private static void CambiarPokemon(IPlayer jugadorActual)
        {
            Console.WriteLine("¿A qué Pokémon deseas cambiar?");
            ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);
            int pokemonSeleccionado = Convert.ToInt16(Console.ReadLine()) - 1;

            if (pokemonSeleccionado >= 0 && pokemonSeleccionado < jugadorActual.Equipo.Count && jugadorActual.Equipo[pokemonSeleccionado].Health > 0)
            {
                IPokemon pokemonActualJugador = jugadorActual.SelectedPokemon;
                jugadorActual.SelectedPokemon = jugadorActual.Equipo[pokemonSeleccionado];
                ImpresoraDeTexto.CambiarPokemon(pokemonActualJugador.Name, jugadorActual.SelectedPokemon.Name);
            }
            else
            {
                Console.WriteLine("Selección no válida. Asegúrate de seleccionar un Pokémon con vida.");
            }
        }

        private static void UsarItem(IPlayer jugadorActual)
        {
            Console.WriteLine("¿Qué ítem deseas usar?");
            int inventoryStatus = ImpresoraDeTexto.ImprimirItems(jugadorActual.Inventario);

            if (inventoryStatus == 1)
            {
                int itemSeleccionado = Convert.ToInt16(Console.ReadLine()) - 1;
                jugadorActual.UsarItem(itemSeleccionado);
            }
            else
            {
                Console.WriteLine("No tienes ítems en tu inventario.");
            }
        }

        private static void SeleccionarNuevoPokemon(IPlayer jugador)
        {
            if (jugador.Equipo.Count > 0)
            {
                Console.WriteLine("Selecciona un nuevo Pokémon de tu equipo:");
                ImpresoraDeTexto.ImprimirEquipo(jugador.Equipo);

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int pokemonSeleccionado) &&
                        pokemonSeleccionado >= 1 && pokemonSeleccionado <= jugador.Equipo.Count &&
                        jugador.Equipo[pokemonSeleccionado - 1].Health > 0)
                    {
                        jugador.SelectedPokemon = jugador.Equipo[pokemonSeleccionado - 1];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Selección no válida. Ingresa un número correspondiente a un Pokémon con salud.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{jugador.Name} no tiene más Pokémon disponibles.");
            }
        }
    }
}
