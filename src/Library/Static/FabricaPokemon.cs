namespace ClassLibrary;

public static class FabricaPokemon
{   /// <summary>
    /// Los registros son clases que tienen la informacion de la creacion de cada pokemon. Estos tienen un metodo que
    /// instancia los pokemons como objetos y los envia hacia las listas, se deberia hacer con visitor.
    /// </summary>
    
    private  static Dictionary<int, IRegistroPokemon> PokedexPokemon =  new() ;
    
    /// <summary>
    /// Implementar el patrón Visitor nos permite definir operaciones en las clases de los Pokémon sin modificar sus clases individuales.
    /// </summary>
    public static void CargarPokemons()
    {
        PokedexPokemon.Add(1, new Registro(
            "Bulbasaur", 
            3, 
            3, 
            4, 
            "Planta", 
            FabricaAtaque.GenerarAtaquesRandom("Planta")
        ));
    
        PokedexPokemon.Add(2, new Registro(
            "Charmander", 
            4, 
            3, 
            3, 
            "Fuego", 
            FabricaAtaque.GenerarAtaquesRandom("Fuego")
        ));
    
        PokedexPokemon.Add(3, new Registro(
            "Squirtle", 
            3, 
            4, 
            5, 
            "Agua", 
            FabricaAtaque.GenerarAtaquesRandom("Agua")
        ));
    
        PokedexPokemon.Add(4, new Registro(
            "Pikachu", 
            5, 
            3, 
            3, 
            "Eléctrico", 
            FabricaAtaque.GenerarAtaquesRandom("Eléctrico")
        ));
    
        PokedexPokemon.Add(5, new Registro(
            "Jigglypuff", 
            2, 
            5, 
            2, 
            "Normal", 
            FabricaAtaque.GenerarAtaquesRandom("Normal")
        ));
    
        PokedexPokemon.Add(6, new Registro(
            "Geodude", 
            4, 
            5, 
            5, 
            "Roca", 
            FabricaAtaque.GenerarAtaquesRandom("Roca")
        ));
    
        PokedexPokemon.Add(7, new Registro(
            "Gastly", 
            6, 
            2, 
            3, 
            "Fantasma", 
            FabricaAtaque.GenerarAtaquesRandom("Fantasma")
        ));
    
        PokedexPokemon.Add(8, new Registro(
            "Onix", 
            3, 
            6, 
            7, 
            "Tierra", 
            FabricaAtaque.GenerarAtaquesRandom("Tierra")
        ));
    
        PokedexPokemon.Add(9, new Registro(
            "Gengar", 
            7, 
            4, 
            5, 
            "Fantasma", 
            FabricaAtaque.GenerarAtaquesRandom("Fantasma")
        ));
    
        PokedexPokemon.Add(10, new Registro(
            "Eevee", 
            3, 
            4, 
            3, 
            "Normal", 
            FabricaAtaque.GenerarAtaquesRandom("Normal")
        ));
    }


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
    
    public static int DevolverTotal()
    {
        return (PokedexPokemon.Count);
    }
}
// Bulbasur.
// Tipo
// Ataque
// Daño 