namespace ClassLibrary;

public class Pokemon : IPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Estado { get; private set; }
    public int InicialHealth { get; private set; }
    public string Tipo { get; private set; }
    public List<IAtaque> Habilidades { get; private set; }

    public Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> habilidades)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;
        InicialHealth = health;
        Estado = 0; // Estado inicial como normal
        Habilidades = habilidades;
    }

    // Método para disminuir la salud del Pokémon
    public void DecreaseHealth(int valueAfterCalculation)
    {
        Health -= valueAfterCalculation;
        if (Health < 0) Health = 0;
    }

    // Método para curar al Pokémon
    public void Curar(int cantidad)
    {
        Health = Math.Min(Health + cantidad, InicialHealth);
    }

    // Método para eliminar efectos de estado
    public void EliminarEfectosDeEstado()
    {
        Estado = 0; // Estado vuelve a '0' (normal)
        Console.WriteLine($"{Name} ya no tiene efectos negativos.");
    }
}