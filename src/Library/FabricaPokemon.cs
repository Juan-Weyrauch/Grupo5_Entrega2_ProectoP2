namespace ClassLibrary;

public static class FabricaPokemon
{   
    public static Dictionary<int, IRegistroPokemon> PokedexPokemon = new Dictionary<int, IRegistroPokemon >();

    public static void CargarPokemons()
    {
        PokedexPokemon.Add(1, new Registro("Bulbasur", 3, 3,4));
        PokedexPokemon.Add(2, new Registro("ABC", 333, 333,3));
        //PokedexPokemon.Add(3, new Registro());
            
    }
    public static  void CrearPokemon(List<int> entrada)
    {
        List<IPokemon> PokemonsTemporal  = new List<IPokemon>();
        foreach (int numero in entrada)
        {
            IRegistroPokemon rElegido = PokedexPokemon[numero];
            IPokemon pokemonTemp = new Pokemon(rElegido.DevolverNombre()) ;
            PokemonsTemporal.Add();
        }
        
        
    }
}
/// Bulbasur.
/// Tipo
/// Ataque
/// Daño 