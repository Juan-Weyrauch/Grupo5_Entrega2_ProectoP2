namespace ClassLibrary;

public static class FabricaPokemon
{
    private static Dictionary<int, IRegistroPokemon> PokedexPokemon = new();

    public static void CargarPokemons()
    {
        // Definición de algunas habilidades (IAtaque)
        IAtaque placaje = new Ataque("Placaje", 40, 100, "Normal", 0);
        IAtaque lanzallamas = new Ataque("Lanzallamas", 90, 100, "Fuego", 1);
        IAtaque latigoCepa = new Ataque("Latigo Cepa", 45, 100, "Planta", 0);
        IAtaque rayo = new Ataque("Rayo", 90, 100, "Electrico", 3);

        // Registro de Pokémon con habilidades específicas
        PokedexPokemon.Add(1, new Registro("Bulbasaur", 49, 45, 49, "Planta", new List<IAtaque> { placaje, latigoCepa }));
        PokedexPokemon.Add(2, new Registro("Charmander", 52, 43, 39, "Fuego", new List<IAtaque> { placaje, lanzallamas }));
        PokedexPokemon.Add(3, new Registro("Pikachu", 55, 40, 35, "Electrico", new List<IAtaque> { placaje, rayo }));
    }

    public static List<string> DevolverNombresPokedex()
    {
        List<string> PokemonsTotales = new List<string>();
        InfoVisitor infoVisitor = new();  // Usamos el visitor para obtener la información
    
        // Recorremos la Pokedex y extraemos los nombres usando el visitor
        for (int i = 1; i <= PokedexPokemon.Count; i++)
        {
            string nombre = PokedexPokemon[i].AcceptObtenerNombre(infoVisitor);
            PokemonsTotales.Add($"{i}) {nombre}");
        }

        return PokemonsTotales;
    }

    public static List<IPokemon> InstanciarPokes(List<int> entrada)
    {
        List<IPokemon> PokemonsTemporal = new List<IPokemon>();
        InfoVisitor infoVisitor = new();
        foreach (int numero in entrada)
        {
            IPokemon pokemonTemp = PokedexPokemon[numero].AcceptCrearPokemon(infoVisitor);
            PokemonsTemporal.Add(pokemonTemp);
        }

        return PokemonsTemporal;
    }

    public static int DevolverTotal()
    {
        return PokedexPokemon.Count;
    }
}
// Bulbasur.
// Tipo
// Ataque
// Daño 