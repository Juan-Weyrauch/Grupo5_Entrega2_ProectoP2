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
        InfoVisitor InfoVisitor = new();
        for (int i = 1; i != PokedexPokemon.Count; i++)
        {
            PokemonsTotales.Add($"{i}) " + InfoVisitor.VisitNombreRegistro(PokedexPokemon[i]));
        }

        return PokemonsTotales;
    }
    public static List<IPokemon> InstanciarPokes( List<int> entrada) // Tiene que llegarle los valores del player.
    {// Falta traer la info desde jugador hacia aca. 
        List<IPokemon> PokemonsTemporal  = new List<IPokemon>();
        InfoVisitor InfoVisitor = new();
        foreach (int numero in entrada)
        {
            IPokemon pokemontemp = InfoVisitor.Visit(PokedexPokemon[numero]);
            PokemonsTemporal.Add(pokemontemp); // Son muchos puntos probablemente aplicar visitor
        }

        return PokemonsTemporal; // Esto esta bien no? No interfiere como tal en el comportamiento


    }
}
// Bulbasur.
// Tipo
// Ataque
// Daño 