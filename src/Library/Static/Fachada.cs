using ClassLibrary;
using Library;

namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Fachada</c> es el punto de entrada principal para gestionar el bucle del juego y el proceso de creación de jugadores.
    /// </summary>
    public static class Fachada
    {
        /// <summary>
        /// Inicia el bucle principal del juego. Pide al usuario que inicie un nuevo juego creando jugadores o que salga.
        /// </summary>
        public static void Start()
        {
            while (true)
            {
                ImpresoraDeTexto.StartPrint();

                if (int.TryParse(Console.ReadLine(), out int inicial))
                {
                    if (inicial == 1)
                    {
                        // Carga todos los Pokémon disponibles y crea dos jugadores.
                        FabricaPokemon.CargarPokemons();
                        List<IPlayer> players = new List<IPlayer>
                        {
                            CrearJugador(1),
                            CrearJugador(2)
                        };
                        Combate.Combatir(players[0],players[1]);
                    }
                    else if (inicial == 2)
                    {
                        ImpresoraDeTexto.EndPrint();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduce un número válido (1 o 2). Presiona cualquier tecla para intentar de nuevo...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, introduce 1 o 2.");
                }
            }
        }

        /// <summary>
        /// Crea un jugador con un número especificado, solicitando su nombre y permitiéndole seleccionar Pokémon.
        /// </summary>
        /// <param name="playerNumber">El número del jugador (1 o 2) que se está creando.</param>
        /// <returns>Un objeto <c>Player</c> que representa al jugador creado.</returns>
        public static Player CrearJugador(int playerNumber)
        {

            int n = FabricaPokemon.DevolverTotal();
            string inputName = ImpresoraDeTexto.InsertarNombre(playerNumber);
            List<int> valuesForPokemons = new List<int>();

            ImpresoraDeTexto.mostrarListaPokemons(inputName);

            for (int j = 0; j < 6; j++)
            {
                ImpresoraDeTexto.selectYourPokemon(j);
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out int numberOfPokemonSelected))
                {
                    try
                    {
                        // Valida y añade el número seleccionado del Pokémon al equipo del jugador.
                        numberOfPokemonSelected = Calculator.GetValidatedNumber(1, n, numberOfPokemonSelected);
                        valuesForPokemons.Add(numberOfPokemonSelected);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ImpresoraDeTexto.Argumentos(0);
                        j--; // Reintenta la selección actual
                    }
                    catch (FormatException)
                    {
                        ImpresoraDeTexto.Argumentos(1);
                        j--; // Reintenta la selección actual
                    }
                }
                else
                {
                    ImpresoraDeTexto.Argumentos(1); // Mensaje de formato inválido
                    j--; // Reintenta la selección actual
                }
                
            }

            List<IPokemon> pokemonsCreados = FabricaPokemon.InstanciarPokes(valuesForPokemons);
            ImpresoraDeTexto.ImprimirEquipoDelJugador(pokemonsCreados);
            int eleccion;
            while (true)
            {
                Console.WriteLine("Elige tu Pokémon inicial:");
                if (int.TryParse(Console.ReadLine(), out eleccion))
                {
                    try
                    {
                        // Valida la elección del Pokémon inicial.
                        eleccion = Calculator.GetValidatedNumber(1, pokemonsCreados.Count, eleccion);
                        ImpresoraDeTexto.ImprimirPokemonSeleccionado(eleccion, pokemonsCreados);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ImpresoraDeTexto.Argumentos(0);
                    }
                }
                else
                {
                    ImpresoraDeTexto.Argumentos(1);
                }
            }

            return new Player(inputName, pokemonsCreados, eleccion);
        }
    }
}
