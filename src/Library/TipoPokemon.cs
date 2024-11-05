namespace ClassLibrary;

public class TipoPokemon: ITipoPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set;  }
    public int Defense { get; private set;   }
    public ITipoPokemon Type { get; private set; }

    public TipoPokemon(string name, int damage, int defense, ITipoPokemon type)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Type = type;
    }
}