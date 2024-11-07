namespace ClassLibrary;

public class Pokemon: IPokemon
{
    public string Name { get; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    
    public string Tipo { get; private set; }

    public Pokemon(string name, int damage, int defense, int health, string tipo)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}