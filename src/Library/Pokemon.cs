namespace ClassLibrary;

public class Pokemon : IPokemon
{
    public string Name { get; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; } // Propiedad Health accesible
    public int InicialHealth { get; private set; } // Propiedad InicialHealth accesible
    public ITipoPokemon TipoPokemon { get; }

    public Pokemon(string name, int damage, int defense, int health, ITipoPokemon tipoPokemon)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        InicialHealth = health;
        TipoPokemon = tipoPokemon;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    // Método para recibir curación (solo hasta el valor de `InicialHealth`)
    public void Curar(int cantidad)
    {
        Health = Math.Min(Health + cantidad, InicialHealth);
    }

    // Método para recibir daño
    public void RecibirDanio(int cantidad)
    {
        Health = Math.Max(Health - cantidad, 0);
    }

    // Método para eliminar efectos de estado (placeholder, implementa la lógica según sea necesario)
    public void EliminarEfectosDeEstado()
    {
        Console.WriteLine($"{Name} ya no tiene efectos negativos.");
    }
}