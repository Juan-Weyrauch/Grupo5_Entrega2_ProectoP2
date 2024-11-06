using ClassLibrary;

namespace Library;

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

    public static void mostrarListaPokemons() // Se muestra lo mismo para el rival que para el jugador.
    {
        Console.WriteLine("╔═════════════════════════════════════════╗");
        Console.WriteLine("║        Selecciona los pokemons!         ║");
        Console.WriteLine("╚═════════════════════════════════════════╝");
        /// Aca Ahora debe mostrar los registros de la Pokedex en la factory.
        
        List<string> nombresPokemons = FabricaPokemon.DevolverNombresPokedex();

        foreach (var nombrePokemon in nombresPokemons) /// Aca se tiene que implementar la logica de matrices.
        {
            Console.WriteLine(nombrePokemon); 
        }
    }
}
    
