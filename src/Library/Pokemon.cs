namespace ClassLibrary;

public class Pokemon : IPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Estado { get; private set; } // 0  es normal, 1 quemado, 2 envenanado, 3 paralizar, 4 Dormido  
    public string Tipo { get; private set; }


    public Pokemon(string name, int damage, int defense, int health, string tipo)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;
        Estado = 0; // Por defecto el Estado es normal.
    }
}