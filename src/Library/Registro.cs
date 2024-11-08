namespace ClassLibrary;

public class Registro: IRegistroPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Health {get; private set;}
    public int Defense { get; private set; }
    public string Tipo { get; private set;}
    
    // dic<ataques> moveset { get; set; }

    public Registro(string name, int damage, int health, int defense,string tipo)
    {
        Name = name;
        Defense = defense;
        Damage = damage;
        Health = health;
        Tipo = tipo;
        
       // TipoPokemon = tipoPokemon; No esta creado tipo todavia
    }

    public IPokemon CrearPokemon()
    {
        return new Pokemon(this.Name, this.Damage, this.Health, this.Defense, this.Tipo);
    }
    // public DevolverMoves();
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
