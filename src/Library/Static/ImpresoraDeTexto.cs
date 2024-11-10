
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
        Console.WriteLine($"║\tSelecciona los pokemons de {jugador}!  ║");
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
    public static void selectYourPokemon(int posicion)
    {
        Console.WriteLine();
        Console.WriteLine($"Seleccciona tu Pokemon numero {posicion + 1}: ");
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
    public static string? InsertarNombre(int numero)
    {
        string? nombre;
        Console.Write($"Ingresa el nomber del jugador {numero}:\n> ");
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

    public static void ImprimirEquipoDelJugador(List<IPokemon> equipo )
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

    public static void ImprimirPokemonSeleccionado(int index, List<IPokemon> equipo)
    {
        string pokemonName;
        pokemonName = equipo[index].Name;
        
        Console.WriteLine("╔═════════════════════════════════════════╗");
        Console.WriteLine($"\tHas seleccionado a {pokemonName}  ");
        Console.WriteLine("╚═════════════════════════════════════════╝");

        
    }

    public static void TurnoJugador( string jugador)
    {
        Console.WriteLine($"Es el turno del jugador {jugador}\n" +
                          $"A) Atacar" +
                          $"B) Cambiar Pokemon" +
                          $"C) Usar Item");
    }

    public static void ImprimirInventario(List<IItem> items)
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
            Console.WriteLine("El inventario está vacío.");
        }
    }
 public  static void ImprimirElegirAPokemon(List<IPokemon> equipo)
    {
        for (int i = 1; i < equipo.Count+1; i++)
        {
            Console.WriteLine($"{i}) {equipo[i].Name}");
        }
    }
    public  static void ImprimirElegirAtaques(List<IAtaque> ataques)
    {
        for (int i = 0; i < ataques.Count; i++)
        {
            Console.WriteLine($"{i+1}) + {ataques[i].Name}");
        }
    }

}