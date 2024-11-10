#nullable enable
namespace ClassLibrary
{
    /// <summary>
    /// Clase estática que maneja la impresión de mensajes en la consola relacionados con el flujo del juego.
    /// </summary>
    public static class ImpresoraDeTexto
    {
        /// <summary>
        /// Imprime el menú de inicio cuando comienza el juego.
        /// </summary>
        public static void StartPrint()
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════╗");
            Console.WriteLine("║       POKEMON       ║");
            Console.WriteLine("╠═════════════════════╣");
            Console.WriteLine("║ 1) Iniciar          ║");
            Console.WriteLine("║ 2) Salir            ║");
            Console.WriteLine("╚═════════════════════╝");
        }

        /// <summary>
        /// Imprime un mensaje de despedida cuando se elige la opción de salir del juego.
        /// </summary>
        public static void EndPrint()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════╗");
            Console.WriteLine("║  Nos vemos pronto!   ║");
            Console.WriteLine("╚══════════════════════╝");
        }

        /// <summary>
        /// Imprime un mensaje cuando el juego termina, indicando al ganador.
        /// </summary>
        /// <param name="nombreJugador">El nombre del jugador ganador.</param>
        public static void FinDelJuego(string nombreJugador)
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine("║    El juego ha terminado!   ║");
            Console.WriteLine("╚═════════════════════════════╝");

            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine($"║  El ganador es {nombreJugador}!  ║");
            Console.WriteLine("╚═════════════════════════════╝");
        }

        /// <summary>
        /// Imprime un mensaje para que el jugador ingrese su nombre.
        /// </summary>
        /// <param name="num">El número de jugador (1 o 2).</param>
        public static void PlayerName(int num)
        {
            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine($"║ Ingrese el nombre del Jugador {num}:    ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");
        }

        /// <summary>
        /// Muestra la lista de Pokémon que puede elegir el jugador.
        /// </summary>
        /// <param name="jugador">El nombre del jugador cuya lista de Pokémon se muestra.</param>
        public static void mostrarListaPokemons(string jugador)
        {
            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine($"║\tSelecciona los pokemons de {jugador}!  ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");

            int columnas = 3; // Define cuántos nombres por fila
            int contador = 0;

            foreach (string cadena in FabricaPokemon.DevolverNombresPokedex())
            {
                Console.Write(cadena + "\t");

                // Imprime un salto de línea cada "columnas" nombres
                contador++;
                if (contador % columnas == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Imprime un mensaje indicando que el jugador debe seleccionar su Pokémon en la posición indicada.
        /// </summary>
        /// <param name="posicion">La posición del Pokémon que el jugador debe seleccionar.</param>
        public static void selectYourPokemon(int posicion)
        {
            Console.WriteLine();
            Console.WriteLine($"Selecciona tu Pokemon numero {posicion + 1}: ");
        }

        /// <summary>
        /// Imprime un mensaje indicando que el valor ingresado está fuera de rango.
        /// </summary>
        public static void ValorFueraDeRango()
        {
            Console.WriteLine("El valor ingresado esta fuera del rango. ");
            Console.Write("Ingrese un numero valido: ");
        }

        /// <summary>
        /// Muestra el equipo de Pokémon del jugador.
        /// </summary>
        /// <param name="jugador">El jugador cuyo equipo de Pokémon se va a mostrar.</param>
        public static void MostrarPokemons(IPlayer jugador)
        {
            int i = 1;
            foreach (IPokemon pokemon in jugador.Equipo)
            {
                string pokemonNameForDisplay = pokemon.Name;  // Access Name directly
                Console.WriteLine($"{i}) {pokemonNameForDisplay}\n");
                i++;
            }
        }

        /// <summary>
        /// Muestra el equipo del jugador en la consola.
        /// </summary>
        /// <param name="Equipo">Lista de Pokémon en el equipo del jugador.</param>
        public static void ImprimirEquipo(List<IPokemon> Equipo)
        {
            for (int i = 0; i < Equipo.Count; i++)
            {
                Console.WriteLine($"{i}) {Equipo[i].Name}");
            }
        }

        /// <summary>
        /// Solicita y retorna el nombre del jugador.
        /// </summary>
        /// <param name="numero">El número del jugador que está ingresando su nombre.</param>
        /// <returns>El nombre del jugador como una cadena de texto.</returns>
        public static string? InsertarNombre(int numero)
        {
            string? nombre;
            Console.Write($"Ingresa el nombre del jugador {numero}:\n> ");
            nombre = Console.ReadLine();
            return nombre;
        }

        /// <summary>
        /// Imprime un mensaje de error según el argumento pasado.
        /// </summary>
        /// <param name="argument">Un valor entero que determina el tipo de error a mostrar.</param>
        public static void Argumentos(int argument)
        {
            if (argument == 0)
            {
                Console.WriteLine("Selection out of range. Please choose a valid Pokémon.");
            }
            else if (argument == 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        /// <summary>
        /// Imprime el equipo del jugador en la consola, indicando que está listo para la batalla.
        /// </summary>
        /// <param name="equipo">El equipo de Pokémon del jugador.</param>
        public static void ImprimirEquipoDelJugador(List<IPokemon> equipo)
        {
            int i = 1;
            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║  Tu equipo esta listo para la batalla!  ║");
            foreach (IPokemon pokemon in equipo)
            {
                Console.WriteLine($"\t{i}) {pokemon.Name}");
                i++;
            }
            Console.WriteLine("╚═════════════════════════════════════════╝");
        }

        /// <summary>
        /// Imprime el nombre del Pokémon seleccionado en la consola.
        /// </summary>
        /// <param name="index">El índice del Pokémon seleccionado.</param>
        /// <param name="equipo">El equipo de Pokémon del jugador.</param>
        public static void ImprimirPokemonSeleccionado(int index, List<IPokemon> equipo)
        {
            string pokemonName = equipo[index].Name;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine($"\tHas seleccionado a {pokemonName}  ");
            Console.WriteLine("╚═════════════════════════════════════════╝");
        }

        /// <summary>
        /// Devuelve la elección del jugador como una cadena de texto.
        /// </summary>
        /// <param name="jugador">El nombre del jugador.</param>
        /// <returns>La acción seleccionada por el jugador como una cadena de texto.</returns>
        public static string? TurnoJugador(string jugador)
        {
            Console.WriteLine($"Es el turno del jugador {jugador}\n" +
                              $"Selecciona lo que desees hacer\n" +
                              $"A) Atacar \n" +
                              $"B) Cambiar Pokemon \n" +
                              $"C) Usar Item \n");
            string cadena = Console.ReadLine().ToUpper();
            return cadena;
        }

        /// <summary>
        /// Imprime los ítems del jugador en la consola, agrupándolos por tipo y cantidad.
        /// </summary>
        /// <param name="items">Lista de ítems del jugador.</param>
        public static void ImprimirItems(List<IItem> items)
        {
            // Verifica si la lista de items no está vacía
            if (items.Count > 0)
            {
                // Crear un diccionario para contar la cantidad de cada tipo de item
                var itemCounts = new Dictionary<string, int>();

                // Contar los items
                foreach (IItem item in items)
                {
                    string itemName = item.Nombre; // Usamos el nombre del item como clave
                    if (itemCounts.ContainsKey(itemName))
                    {
                        itemCounts[itemName]++; // Si ya existe, incrementamos la cantidad
                    }
                    else
                    {
                        itemCounts[itemName] = 1; // Si no existe, inicializamos la cantidad
                    }
                }

                // Mostrar los items con su cantidad y su índice
                int index = 1;
                foreach (var kvp in itemCounts)
                {
                    // Imprimir el índice, nombre del item y cantidad
                    Console.WriteLine($"{index}) {kvp.Key} x{kvp.Value}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("No tienes items disponibles.");
            }
        }
    }
}
