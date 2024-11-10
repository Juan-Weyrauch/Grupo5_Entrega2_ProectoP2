namespace ClassLibrary;

public static class FabricaPokemon
{   /// <summary>
    /// Los registros son clases que tienen la informacion de la creacion de cada pokemon. Estos tienen un metodo que
    /// instancia los pokemons como objetos y los envia hacia las listas, se deberia hacer con visitor.
    /// </summary>
    
    private  static Dictionary<int, IRegistroPokemon> PokedexPokemon =  new() ;
    
    /// <summary>
    /// Carga los Pokémon en la Pokedex. Este método crea los registros de Pokémon y los almacena
    /// en el diccionario <c>PokedexPokemon</c> utilizando el <see cref="Registro"/> y el <see cref="FabricaAtaque"/>.
    /// </summary>
    public static void CargarPokemons()// Para entender mejor leer IRegistro y Registro. 
    {
        
        PokedexPokemon.Add(1, new Registro("Bulbasur", 3, 3,4,"Planta",FabricaAtaque.GenerarAtaquesRandom("Planta")));
        PokedexPokemon.Add(2, new Registro("ABC", 333, 333,3,"Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
        //PokedexPokemon.Add(3, new Registro());
    }
    /// <summary>
    /// Devuelve una lista de nombres de Pokémon desde la Pokedex.
    /// Utiliza el patrón Visitor para obtener el nombre de cada Pokémon sin modificar sus clases individuales.
    /// </summary>
    /// <returns>Una lista de nombres de Pokémon en formato "número) nombre".</returns>
    public static List<string> DevolverNombresPokedex()
    {
        List<string> PokemonsTotales = new List<string>();
        InfoVisitor infoVisitor = new();  // Usamos el visitor para obtener la información
    
        // Recorremos la Pokedex y extraemos los nombres usando el visitor
        for (int i = 1; i <= PokedexPokemon.Count; i++)  // Cambié el bucle para incluir el último índice
        {
            string num = i.ToString();
            // Aquí el visitor extrae solo el nombre del registro
            string nombre = PokedexPokemon[i].AcceptObtenerNombre(infoVisitor); // esto tiene que de alguna manera dar los nombres.
            PokemonsTotales.Add($"{num}) {nombre}");
        }

        return PokemonsTotales;
    }
    /// <summary>
    /// Instancia una lista de Pokémon para un jugador específico utilizando los números de la Pokedex.
    /// Cada número de Pokémon se corresponde con un registro de la Pokedex que se instanciará como un objeto <see cref="IPokemon"/>.
    /// </summary>
    /// <param name="entrada">Lista de números de Pokémon seleccionados por el jugador.</param>
    /// <returns>Lista de objetos <see cref="IPokemon"/> correspondientes a los números proporcionados.</returns>
    public static List<IPokemon> InstanciarPokes(List<int> entrada) // Tiene que llegarle los valores del player.
    {// Falta traer la info desde jugador hacia aca. 
        List<IPokemon> PokemonsTemporal  = new List<IPokemon>();
        InfoVisitor InfoVisitor = new();
        foreach (int numero in entrada)
        {
            IPokemon pokemontemp = PokedexPokemon[numero].AcceptCrearPokemon(InfoVisitor); // Esto tiene que ir creando los Pokemons.
            PokemonsTemporal.Add(pokemontemp); // Son muchos puntos probablemente aplicar visitor
        }

        return PokemonsTemporal;

    }
    /// <summary>
    /// Devuelve el número total de Pokémon en la Pokedex.
    /// </summary>
    /// <returns>El número total de Pokémon en la Pokedex.</returns>
    public static int DevolverTotal()
    {
        return (PokedexPokemon.Count);
    }
}
// Bulbasur.
// Tipo
// Ataque
// Daño 