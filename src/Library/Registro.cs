namespace ClassLibrary;

public class Registro: IRegistroPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Health {get; private set;}
    public int Defense { get; private set; }
    public string Tipo { get; private set;}
    public List<IAtaque> Ataques { get; }
    

    public Registro(string name, int damage, int health, int defense,string tipo)
    {
        Name = name;
        Defense = defense;
        Damage = damage;
        Health = health;
        Tipo = tipo;
        Ataques = FabricaAtaque.GenerarAtaquesRandom();

        // TipoPokemon = tipoPokemon; No esta creado tipo todavia
    }

    public IPokemon CrearPokemon()
    {
        return new Pokemon(this.Name, this.Damage, this.Health, this.Defense, this.Tipo, this.Ataques);
    }
    // public DevolverMoves();

    public string AcceptObtenerNombre(IVisitor visitor)
    {
      return  visitor.visitNombreRegistro(this);
    }

    public IPokemon AcceptCrearPokemon(IVisitor visitor)
    {
        return visitor.visitCrearPokemon(this);
    }
}
