namespace ClassLibrary;

public class Registro : IRegistroPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Health { get; private set; }
    public int Defense { get; private set; }
    public string Tipo { get; private set; }
    public List<IAtaque> Habilidades { get; private set; } // Nueva propiedad para las habilidades

    public Registro(string name, int damage, int health, int defense, string tipo, List<IAtaque> habilidades)
    {
        Name = name;
        Damage = damage;
        Health = health;
        Defense = defense;
        Tipo = tipo;
        Habilidades = habilidades;
    }

    public IPokemon CrearPokemon()
    {
        return new Pokemon(this.Name, this.Damage, this.Defense, this.Health, this.Tipo, new List<IAtaque>(this.Habilidades));
    }

    public string AcceptObtenerNombre(IVisitor visitor)
    {
        return visitor.visitNombreRegistro(this);
    }

    public IPokemon AcceptCrearPokemon(IVisitor visitor)
    {
        return visitor.visitCrearPokemon(this);
    }
}