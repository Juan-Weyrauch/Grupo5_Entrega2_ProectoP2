using ClassLibrary;
using Library.Static;
using System;
using System.Linq;

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
            _jugadorActual = jugador1;
            _jugadorRival = jugador2;

            while (Calculator.CombatValidation(jugador1, jugador2))
            {
                Console.WriteLine($"Es el turno de {_jugadorActual.Name}");

                // Aplicar el efecto de estado al Pokémon actual antes de cualquier acción
                AplicarEfectoEstado(_jugadorActual.SelectedPokemon);

                // Si el Pokémon puede atacar, ejecuta la acción
                if (_jugadorActual.SelectedPokemon.PuedeAtacar())
                {
                    IniciarAccion(_jugadorActual, _jugadorRival);
                }

                // Cambia de jugador al final del turno
                CambiarJugador();

                // Verificar el estado del combate después de cada turno
                if (!Calculator.CombatValidation(jugador1, jugador2))
                {
                    break;
                }
            }
        }

        // Método auxiliar para cambiar el jugador
        private static void CambiarJugador()
        {
            var temp = _jugadorActual;
            _jugadorActual = _jugadorRival;
            _jugadorRival = temp;
        }

        public static void Combatir(IPlayer jugadorActual, IPlayer jugadorRival)
        {
            IPokemon pokemonActual = jugadorActual.SelectedPokemon;
            IPokemon pokemonRival = jugadorRival.SelectedPokemon;
            _pokemonActual = pokemonActual;
            _pokemonRival = pokemonRival;
            int estadoDelPokemon = Calculator.ChequearEstado(pokemonActual);

            // Aplicar el efecto de estado antes de cualquier acción
            AplicarEfectoEstado(pokemonActual);

            // Chequeo si aun tiene pokemons
            int estadoDelEquipo = Calculator.IndividualcombatValidation(jugadorActual.Equipo);
            if (pokemonActual.Health == 0 && estadoDelEquipo == 0) // Si no puede seguir jugando, termina el juego.
            {
                ImpresoraDeTexto.FinDelJuego(jugadorRival.Name);
            }
            else if ((pokemonActual.Health > 0 || estadoDelEquipo > 0) && estadoDelPokemon == 0) // Si sigue con pokemons en estado normal
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

        public static void AplicarEfectoEstado(IPokemon pokemon)
        {
            switch (pokemon.EstadoActual)
            {
                case Estado.Paralizado:
                    if (!pokemon.PuedeAtacar())
                    {
                        Console.WriteLine($"{pokemon.Name} está paralizado y pierde el turno.");
                        return; // Sale si el Pokémon pierde el turno
                    }
                    break;

                case Estado.Dormido:
                    if (pokemon.TurnosDormido > 0)
                    {
                        Console.WriteLine($"{pokemon.Name} está dormido y pierde el turno.");
                        pokemon.TurnosDormido--; // Reduce los turnos de sueño
                        return; // Sale si el Pokémon pierde el turno
                    }
                    break;

                case Estado.Quemado:
                    Console.WriteLine($"{pokemon.Name} está quemado y recibe daño residual.");
                    pokemon.DecreaseHealth((int)(pokemon.InicialHealth * 0.10)); // Daño residual por quemadura
                    break;

                case Estado.Envenenado:
                    Console.WriteLine($"{pokemon.Name} está envenenado y recibe daño residual.");
                    pokemon.DecreaseHealth((int)(pokemon.InicialHealth * 0.05)); // Daño residual por veneno
                    break;

                default:
                    break;
            }
        }

        private static void IniciarAccion(IPlayer jugadorActual, IPlayer jugadorRival)
        {
            IPokemon pokemonActualJugador = jugadorActual.SelectedPokemon;
            IPokemon pokemonActualRival = jugadorRival.SelectedPokemon;

            // Solicita al jugador su movimiento
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
                jugadorActual.SelectedPokemon = jugadorActual.Equipo[pokemonSeleccionado];
                ImpresoraDeTexto.CambiarPokemon(pokemonActualJugador.Name, jugadorActual.SelectedPokemon.Name);
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
        }

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
                jugadorRival.SelectedPokemon.CambiarEstado(1); // Cambia el estado del rival a quemado
            }
            else if (tipo == 2) // Dormir
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 2);
                jugadorRival.SelectedPokemon.CambiarEstado(2);
            }
            else if (tipo == 3) // Paralizar
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 3);
                jugadorRival.SelectedPokemon.CambiarEstado(3);
            }
            else if (tipo == 4) // Veneno
            {
                ImpresoraDeTexto.ImprimirCambioEstado(nombrePoke, nombreAtaque, 4);
                jugadorRival.SelectedPokemon.CambiarEstado(4);
            }
        }
    }
}
