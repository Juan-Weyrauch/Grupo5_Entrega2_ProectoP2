namespace ClassLibrary;

public interface ITipoPokemon
{
    string Name { get; }
    int damage { get; set; }
    int defense { get; set; }
    ITipoPokemon Type { get; }
}