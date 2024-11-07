namespace ClassLibrary;

public class Pokemon : IPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public string Tipo { get; private set; }


    public Pokemon(string name, int damage, int defense, int health, string tipo)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;  
    }
}