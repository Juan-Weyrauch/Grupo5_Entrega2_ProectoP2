using ClassLibrary;
using Library.Static;

namespace Library
{
    public static class Combate
    {
        static IVisitor InfoVisitor = new InfoVisitor();

        static IPlayer JugadorActual;
        static IPlayer JugadorRival;
        static IPokemon PokemonActual;
        static IPokemon PokemonRival;

        public static void Recibir(IPokemon pokemon, int damage)
        {
            pokemon.DecreaseHealth(damage);
        }

        public static void Combatir(IPlayer Jugador1, IPlayer Jugador2)
        {
            int turno = 0;

            while (Calculator.CombatValidation(Jugador1, Jugador2))
            {
                if (turno % 2 == 0) // Sistema sencillo que permite detectar cuando es el turno de cada jugador.
                {
                    JugadorActual = Jugador1;
                    JugadorRival = Jugador2;
                }
                else
                {
                    JugadorActual = Jugador2;
                    JugadorRival = Jugador1;
                }

                if (turno < 2)
                {
                    ImpresoraDeTexto.MostrarPokemons(JugadorActual);
                }

                Turno(JugadorActual, JugadorRival);

                turno++;
            }
        }

        public static void Turno(IPlayer JugadorActual, IPlayer JugadorRival)
        {
            IPokemon pokemonActual = JugadorActual.SelectedPokemon;
            IPokemon pokemonRival = JugadorRival.SelectedPokemon;

            if (CheckVida(pokemonActual))  // Comprobamos si el Pokémon está vivo
            {
                // Aplicar efectos de estado (Dormido, Paralizado, Quemado, Envenenado) al principio del turno
                EfectuarEfecto(pokemonActual);

                // Si el Pokémon está en un estado que le permite actuar
                if (pokemonActual.Estado == 0)  // Si no está dormido ni paralizado
                {
                    string nombrePlayer = JugadorActual.Name;
                    ImpresoraDeTexto.TurnoJugador(nombrePlayer);
                    string cadena = Console.ReadLine().ToUpper();

                    if (cadena == "A")
                    {
                        Console.WriteLine("Con qué quieres atacar?");
                        // Lógica de ataque (agregar selección de ataque aquí)
                    }

                    if (cadena == "B")
                    {
                        Console.WriteLine("Puedes cambiar a los siguientes Pokemons:");
                        ImpresoraDeTexto.ImprimirEquipoDelJugador(JugadorActual.Equipo);
                        // Mostrar el equipo y permitir el cambio de Pokémon
                    }

                    if (cadena == "C")
                    {
                        Console.WriteLine("Puedes utilizar los siguientes Items:");
                        ImpresoraDeTexto.ImprimirInventario(JugadorActual.Inventario);
                        SeleccionarItem(JugadorActual);
                    }
                }
                else
                {
                    Console.WriteLine($"{pokemonActual.Name} no puede actuar este turno debido a su estado.");
                }
            }
        }

        public static bool CheckVida(IPokemon pokemonActual)
        {
            return pokemonActual.Health > 0;
        }

        public static void EfectuarEfecto(IPokemon pokemon)
        {
            int estadoPokemon = pokemon.Estado;
            int calculoDaño = 0;
            Random random = new Random();

            switch (estadoPokemon)
            {
                case 0:
                    break; // Sin efectos
                case 1: // Quemado
                    calculoDaño = (int)Math.Round(0.15 * pokemon.Health);
                    Console.WriteLine($"{pokemon.Name} está quemado y recibe {calculoDaño} de daño.");
                    pokemon.DecreaseHealth(calculoDaño);
                    break;

                case 2: // Envenenado
                    calculoDaño = (int)Math.Round(0.10 * pokemon.Health);
                    Console.WriteLine($"{pokemon.Name} está envenenado y recibe {calculoDaño} de daño.");
                    pokemon.DecreaseHealth(calculoDaño);
                    break;

                case 3: // Parálisis
                    // 25% de probabilidad de no poder actuar (no atacar)
                    if (random.NextDouble() < 0.25)
                    {
                        Console.WriteLine($"{pokemon.Name} está paralizado y no puede atacar este turno.");
                    }
                    else
                    {
                        Console.WriteLine($"{pokemon.Name} está paralizado pero puede atacar.");
                    }
                    break;

                case 4: // Dormido
                    // El Pokémon pierde el turno
                    Console.WriteLine($"{pokemon.Name} está dormido y pierde este turno.");

                    // Intentar despertar con una probabilidad de 25%
                    if (random.NextDouble() < 0.25)  // 25% de probabilidad de despertar
                    {
                        pokemon.EliminarEfectosDeEstado();   // Despierta
                        Console.WriteLine($"{pokemon.Name} se ha despertado.");
                    }
                    else
                    {
                        Console.WriteLine($"{pokemon.Name} sigue dormido.");
                    }
                    break;

                default:
                    break;
            }
        }

        public static void SeleccionarItem(IPlayer jugador)
        {
            List<IItem> inventario = jugador.Inventario;
            List<IPokemon> equipo = jugador.Equipo;

            Console.WriteLine("Selecciona un ítem para usar:");
            bool seleccionValida = false;
            while (!seleccionValida)
            {
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int indice) && indice > 0 && indice <= inventario.Count)
                {
                    IItem itemSeleccionado = inventario[indice - 1];
                    Console.WriteLine($"Has seleccionado: {itemSeleccionado.Nombre}");

                    // Llamamos a ElegirPokemon para que el jugador seleccione un Pokémon
                    IPokemon pokemonSeleccionado = ElegirPokemon(equipo);
                    if (pokemonSeleccionado != null)
                    {
                        jugador.UsarItem(indice - 1, pokemonSeleccionado);  // Usar el ítem en el Pokémon elegido
                        seleccionValida = true;  // Selección válida, terminamos el bucle
                    }
                }
                else
                {
                    Console.WriteLine("Selección de ítem inválida, por favor elige un número válido.");
                }
            }
        }

        public static IPokemon ElegirPokemon(List<IPokemon> equipo)
        {
            Console.WriteLine("Selecciona un Pokémon de tu equipo:");

            for (int i = 0; i < equipo.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {equipo[i].Name} - Salud: {equipo[i].Health}/{equipo[i].InicialHealth}");
            }

            bool seleccionValida = false;
            IPokemon pokemonSeleccionado = null;
            while (!seleccionValida)
            {
                string entradaPokemon = Console.ReadLine();
                if (int.TryParse(entradaPokemon, out int indicePokemon) && indicePokemon > 0 && indicePokemon <= equipo.Count)
                {
                    pokemonSeleccionado = equipo[indicePokemon - 1];
                    Console.WriteLine($"Has seleccionado a {pokemonSeleccionado.Name}.");
                    seleccionValida = true;
                }
                else
                {
                    Console.WriteLine("Selección de Pokémon inválida. Por favor, intenta nuevamente.");
                }
            }

            return pokemonSeleccionado;
        }
    }
}
