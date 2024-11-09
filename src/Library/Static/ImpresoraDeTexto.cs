namespace ClassLibrary;



public static class ImpresoraDeTexto
{
    //PokemonsYHablidades pokemonsYHablidades = new PokemonsYHablidades();

    public static void startPrint() // Imprimir cuando se inicia el Juego.
    {
        Console.Clear();
        Console.WriteLine("╔═════════════════════╗");
        Console.WriteLine("║       POKEMON       ║");
        Console.WriteLine("╠═════════════════════╣");
        Console.WriteLine("║ 1) Iniciar          ║");
        Console.WriteLine("║ 2) Salir            ║");
        Console.WriteLine("╚═════════════════════╝");
    }

    public static void endPrint() // Imprimir cuando se elige la segunda opcion el Juego.
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════╗");
        Console.WriteLine("║  Nos vemos pronto!   ║");
        Console.WriteLine("╚══════════════════════╝");
    }

    public static void finDelJuego() // Imprmir cuando se termina el juego
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════╗");
        Console.WriteLine("║  El juego ha terminado!  ║");
        Console.WriteLine("╚══════════════════════════╝");
    }

    public static void playerName(int num) // Imprmir a la hora de elegir el nombre el jugador
    {
        Console.WriteLine("╔═════════════════════════════════════════╗");
        Console.WriteLine($"║ Ingrese el nombre del Jugador {num}:    ║");
        Console.WriteLine("╚═════════════════════════════════════════╝");
    }

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

    public static void selectYourPokemon()
    {
        Console.Write("Select Your Pokemon: ");
    }

    public static void ValorFueraDeRango()
    {
        Console.WriteLine("El valor ingresado esta fuera del rango. ");
        Console.Write("Ingrese un numero valido: ");
    }

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
    
    public static void EligePokemonInicial(List<IPokemon> Equipo)
    {
        for (int i = 0; i < Equipo.Count; i++)
        {
            
            Console.WriteLine($"{i}) {Equipo[i].Name}");
            
        }
    }
}