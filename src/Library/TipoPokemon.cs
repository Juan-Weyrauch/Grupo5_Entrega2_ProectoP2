namespace ClassLibrary;

public class TipoPokemon: ITipoPokemon
{
    public string Name { get; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public ITipoPokemon Type { get; }

    public TipoPokemon(string name, int damage, int defense, ITipoPokemon type)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Type = type;
    }
}