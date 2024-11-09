namespace ClassLibrary;

public class Pokemon : IPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Estado { get; private set; } // 0  es normal, 1 quemado, 2 envenanado, 3 paralizar, 4 Dormido  
    public int InicialHealth { get; private set; }
    public List<IAtaque> Ataques { get; private set; }
    public string Tipo { get; private set; }

   
    
    public Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> ataques)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;
        Ataques = ataques;
        InicialHealth = health;
        Estado = 0; // Por defecto el Estado es normal.
    }
    public void DecreaseHealth(int valueAfterCalculation) // Resta de vida despues del calculo de daño. 
    {
        Health -= valueAfterCalculation;
        if (Health < 0) Health = 0;
    }
    public void Curar(int cantidad)
    {
        Health = Math.Min(Health + cantidad, InicialHealth);
    }
    public void EliminarEfectosDeEstado()
    {
        Estado = 0;
    }
}