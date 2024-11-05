namespace ClassLibrary;

public class Registro: IRegistroPokemon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Health {get; set;}
    public int Defense { get; set; }
     public  ITipoPokemon TipoPokemon { get; set; }
    // dic<ataques> moveset { get; set; }

    public Registro(string name, int damage, int health, int defense)
    {
        Name = name;
        defense = defense;
        
        Damage = damage;
        Health = health;
        
       // TipoPokemon = tipoPokemon; No esta creado tipo todavia
    }

    public string DevolverNombre()
    {
        return Name;
    }

    public int DevolverDamage()
    {
        return Damage;
    }

    public int DevolverHealth()
    { return Health;
    }

    public ITipoPokemon DevolverTipo()
    { return TipoPokemon;
    }
    // public DevolverMoves();
}
}