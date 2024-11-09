#nullable enable
namespace ClassLibrary;



public static class ImpresoraDeTexto
{
    //PokemonsYHablidades pokemonsYHablidades = new PokemonsYHablidades();

    /// <summary>
    /// 
    /// </summary>
    public static void StartPrint() // Imprimir cuando se inicia el Juego.
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
    /// 
    /// </summary>
    public static void EndPrint() // Imprimir cuando se elige la segunda opcion el Juego.
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════╗");
        Console.WriteLine("║  Nos vemos pronto!   ║");
        Console.WriteLine("╚══════════════════════╝");
    }

    /// <summary>
    /// 
    /// </summary>
    public static void FinDelJuego() // Imprmir cuando se termina el juego
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════╗");
        Console.WriteLine("║  El juego ha terminado!  ║");
        Console.WriteLine("╚══════════════════════════╝");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    public static void PlayerName(int num) // Imprmir a la hora de elegir el nombre el jugador
    {
        Console.WriteLine("╔═════════════════════════════════════════╗");
        Console.WriteLine($"║ Ingrese el nombre del Jugador {num}:    ║");
        Console.WriteLine("╚═════════════════════════════════════════╝");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jugador"></param>
    public static void mostrarListaPokemons(string jugador) // Se muestra lo mismo para el rival que para el jugador.
    {
        
        Console.WriteLine("╔═════════════════════════════════════════╗");
        Console.WriteLine($"║        Selecciona los pokemons de {jugador} !    ║");
        Console.WriteLine("╚═════════════════════════════════════════╝");
        /// Aca Ahora debe mostrar los registros de la Pokedex en la factory.
        
        
        

        int columnas = 3;  // Define cuántos nombres por fila
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
    /// 
    /// </summary>
    public static void selectYourPokemon()
    {
        Console.Write("Select Your Pokemon: ");
    }

    /// <summary>
    /// 
    /// </summary>
    public static void ValorFueraDeRango()
    {
        Console.WriteLine("El valor ingresado esta fuera del rango. ");
        Console.Write("Ingrese un numero valido: ");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jugador"></param>
    public static void MostrarPokemons(Player jugador)
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
    /// 
    /// </summary>
    /// <param name="Equipo"></param>
    public static void EligePokemonInicial(List<IPokemon> Equipo)
    {
        for (int i = 0; i < Equipo.Count; i++)
        {
            
            Console.WriteLine($"{i}) {Equipo[i].Name}");
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numero"></param>
    public static string InsertarNombre(int numero)
    {
        string nombre;
        Console.WriteLine($"Enter the name of Player {numero}:");
        nombre = Console.ReadLine();
        return (nombre);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="argument"></param>
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

    public static void ImprimirEquipoDelJugador(Player? player)
    {
        List<IPokemon> equipo = player.GetEquipo();
    }
}