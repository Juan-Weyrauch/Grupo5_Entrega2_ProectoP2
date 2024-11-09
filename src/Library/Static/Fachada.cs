using ClassLibrary;

namespace ClassLibrary;

public static class Fachada
{
    public static void Start()
    {
        while (true)
        {
            ImpresoraDeTexto.startPrint();

            if (int.TryParse(Console.ReadLine(), out int inicial)) // si no es valido el input no se ejecutara (else)
            {
                if (inicial == 1)
                {
                    FabricaPokemon.CargarPokemons();
                    selecciones();
                }
                else if (inicial == 2)
                {
                    ImpresoraDeTexto.endPrint();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number (1 or 2). Press any key to try again...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
            }
        }
    }

    /// <summary>
    /// selecciones crea una lista de dos jugadores
    /// </summary>
    public static void selecciones()
    {
        List<IPlayer> players = new List<IPlayer>
        {
            CrearJugador(1),
            CrearJugador(2)
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numero"></param>
    /// <returns></returns>
    public static Player CrearJugador(int numero)
    {
        string inputName;
        List<int> valuesForPokemons = new List<int>();
        int n = FabricaPokemon.DevolverTotal();

        Console.WriteLine($"Enter the name of Player {numero}:");
        inputName = Console.ReadLine();

        ImpresoraDeTexto.mostrarListaPokemons(inputName);

        for (int j = 0; j < 6; j++)
        {
            ImpresoraDeTexto.selectYourPokemon();

            if (int.TryParse(Console.ReadLine(), out int numberOfPokemonSelected))
            {
                try
                {
                    numberOfPokemonSelected = Calculator.GetValidatedNumber(1, n, numberOfPokemonSelected);
                    valuesForPokemons.Add(numberOfPokemonSelected);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number out of range. Please enter a number within the allowed range.");
                    j--;
                }
            }
            else
            {
                Console.WriteLine("Invalid format. Please enter a valid integer.");
                j--;
            }
        }

        List<IPokemon> PokemonsCreados = FabricaPokemon.InstanciarPokes(valuesForPokemons);
        ImpresoraDeTexto.EligePokemonInicial(PokemonsCreados);

        int eleccion;
        while (true)
        {
            Console.WriteLine("Choose your starting Pokémon:");
            if (int.TryParse(Console.ReadLine(), out eleccion))
            {
                try
                {
                    eleccion = Calculator.GetValidatedNumber(1, PokemonsCreados.Count, eleccion);
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Selection out of range. Please choose a valid Pokémon.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        return new Player(inputName, PokemonsCreados, eleccion);
    }
}