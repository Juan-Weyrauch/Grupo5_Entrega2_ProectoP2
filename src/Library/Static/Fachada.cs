using Library;
using ClassLibrary;

namespace ClassLibrary;

    public static class Fachada
    {
        public static void Start()
    { // maybe this should return an int and just evalueate that 
      // meaning that i just call Printer, Printer calls Calculator which returns a value to Printer
      // and I just evaluate that number here
        while (true)
        {
            ImpresoraDeTexto.startPrint();
            int inicial = Convert.ToInt32(Console.ReadLine());
            if (inicial == 1)
            {
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

    public static void selecciones()
    {
        List <IPokemon> pokemonsForPlayers = new List<IPokemon>();
        string inputName = Console.ReadLine();
        List<IPlayer> players = new List<IPlayer>(); // maybe it's better to send a list index
        
        //para poder llamar a 'GetValidatedNumber(1, n)'
        int n = FabricaPokemon.DevolverTotal(); // debe ser la cantidad de pokemons que mostremos en la matriz

        for (int i = 1; i <= 2; i++)
        {
            Console.WriteLine($"Enter the name of Player {i}:");
            inputName = Console.ReadLine();
            
            if (i == 1)
            {
                Player Jugador1 = new Player(inputName, pokemonsForPlayers, /*TODO revise this attribute*/ 1);
                ImpresoraDeTexto.mostrarListaPokemons(inputName);
                for (int j = 0; j <= 6; j++)
                {
                    ImpresoraDeTexto.selectYourPokemon();
                    try
                    {
                        int numberOfPokemonSelected = Calculator.GetValidatedNumber(1, n);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid format. Please enter a valid integer.");
                        i--;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Number out of range. Please enter a number within the allowed range.");
                    }
                }
            }
        }
    }
}