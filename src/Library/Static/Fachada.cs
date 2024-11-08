

using ClassLibrary;

namespace ClassLibrary;

public static class Fachada
{
    public static void Start()
    {
        // maybe this should return an int and just evalueate that 
        // meaning that i just call Printer, Printer calls Calculator which returns a value to Printer
        // and I just evaluate that number here
        while (true)
        {
            ImpresoraDeTexto.startPrint();
            int inicial = Convert.ToInt32(Console.ReadLine());
            if (inicial == 1)
            {
                FabricaPokemon.CargarPokemons();
                Fachada.selecciones();
            }
            else if (inicial == 2)
            {
                ImpresoraDeTexto.endPrint();
                break;
            }
            else
            {
                Console.WriteLine("Por favor, introduce un número válido (1 o 2).");
                Console.WriteLine("Presiona cualquier tecla para intentar de nuevo...");
                Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de continuar
                continue;
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static void selecciones()
    {   
        List<IPlayer> players = new List<IPlayer>();
        players.Add(CrearJugador(1));
        players.Add(CrearJugador(2));
    }

    public static IPlayer CrearJugador(int numero)
    {
        string inputName = "";
        List<int> valuesForPokemons = new List<int>();


        //para poder llamar a 'GetValidatedNumber(1, n)'
        int n = FabricaPokemon.DevolverTotal(); // debe ser la cantidad de pokemons que mostremos en la matriz

        Console.WriteLine($"Enter the name of Player {numero}:");
        inputName = Console.ReadLine();

        // if (g == 1)
        {
            ImpresoraDeTexto.mostrarListaPokemons(inputName);
            for (int j = 0; j < 6; j++)
            {
                ImpresoraDeTexto.selectYourPokemon();
                try
                {
                    // este metodo recibe y verifica el valor ingresado
                    int numberOfPokemonSelected = Convert.ToInt32(Console.ReadLine());
                    // numberOfPokemonSelected = Calculator.GetValidatedNumber(1, n, numberOfPokemonSelected);
                    valuesForPokemons.Add(numberOfPokemonSelected);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format. Please enter a valid integer.");
                    j--;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number out of range. Please enter a number within the allowed range.");
                    j--;
                }
            }

            List<IPokemon> PokemonsCreados = FabricaPokemon.InstanciarPokes(valuesForPokemons);
            ImpresoraDeTexto.EligePokemonInicial(PokemonsCreados);
            Console.WriteLine("Elige el pokemon inicial// no es definitivo.");
            int eleccion = Convert.ToInt32(Console.ReadLine());
            IPlayer player = new Player(inputName, PokemonsCreados, /*TODO revise this attribute*/ eleccion);
            return player;
        }
    }
}