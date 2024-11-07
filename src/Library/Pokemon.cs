namespace ClassLibrary;

public class Pokemon: IPokemon
{
    public string Name { get; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public ITipoPokemon TipoPokemon { get; }

    public Pokemon(string name, int damage, int defense, int health)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health; 
        //ITipoPokemon tipoPokemon = tipoPokemon;
    }
    
    /*public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }*/
}