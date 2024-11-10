public class Pokemon : IPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Estado { get; private set; } // Mantener privado o internal si se usa InternalsVisibleTo
    public int InicialHealth { get; private set; }
    public List<IAtaque> Ataques { get; private set; }
    public string Tipo { get; private set; }

    // Constructor principal
    public Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> ataques)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;
        Ataques = ataques;
        InicialHealth = health;
        Estado = 0; // Estado inicial por defecto
    }

    // Constructor adicional para pruebas, que incluye el estado inicial
    internal Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> ataques, int estadoInicial)
        : this(name, damage, defense, health, tipo, ataques) // Llama al constructor principal
    {
        Estado = estadoInicial; // Asigna el estado inicial proporcionado
    }

    public void DecreaseHealth(int valueAfterCalculation)
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
public static void EliminarEfectosDeEstado_ShouldResetEstadoToNormal()
{
    // Usa el constructor adicional para pruebas para asignar Estado
    var pokemon = new Pokemon("Pikachu", 50, 30, 100, "Eléctrico", new List<IAtaque>(), 2); // Estado envenenado

    pokemon.EliminarEfectosDeEstado();

    Console.WriteLine(pokemon.Estado == 0 
        ? "Test Passed: EliminarEfectosDeEstado_ShouldResetEstadoToNormal" 
        : "Test Failed: EliminarEfectosDeEstado_ShouldResetEstadoToNormal");
}

