namespace ClassLibrary;

public static class FabricaPokemon
{   /// <summary>
    /// Los registros son clases que tienenl la informacion de la creacion de cada pokemon. Estos tienen un metodo que
    /// instancia los pokemons como objetos y los envia hacia las listas, se deberia hacer con visitor.
    /// </summary>
    public  static Dictionary<int, IRegistroPokemon> PokedexPokemon = new();

    
    /// <summary>
    /// Implementar el patrón Visitor nos permite definir operaciones en las clases de los Pokémon sin modificar sus clases individuales.
    /// </summary>
    public static void CargarPokemons()// Para entender mejor leer IRegistro y Registro. 
    {
        PokedexPokemon.Add(1, new Registro("Bulbasur", 3, 3,4));
        PokedexPokemon.Add(2, new Registro("ABC", 333, 333,3));
        //PokedexPokemon.Add(3, new Registro());
    }

    public static List<string> DevolverNombresPokedex()
    {
        List<string> PokemonsTotales = new List<string>();
        InfoVisitor infoVisitor = new();  // Usamos el visitor para obtener la información
    
        // Recorremos la Pokedex y extraemos los nombres usando el visitor
        for (int i = 1; i <= PokedexPokemon.Count; i++)  // Cambié el bucle para incluir el último índice
        {
            // Aquí el visitor extrae solo el nombre del registro
            string nombre = PokedexPokemon[i].AcceptObtenerNombre(infoVisitor); // esto tiene que de alguna manera dar los nombres.
            PokemonsTotales.Add($"{i}) {nombre}");
        }

        return PokemonsTotales;
    }

    public static List<IPokemon> InstanciarPokes(List<int> entrada, IPlayer Jugador) // Tiene que llegarle los valores del player.
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
}
// Bulbasur.
// Tipo
// Ataque
// Daño 