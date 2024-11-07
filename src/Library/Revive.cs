public class Revive : IItem
{
    public string Nombre => "Revive";

    public void Usar(IPokemon pokemon)
    {
        if (pokemon.Health == 0)  // Solo revive si el Pokémon está debilitado
        {
            int vidaRevive = pokemon.InicialHealth / 2;
            pokemon.Curar(vidaRevive);
            Console.WriteLine($"{pokemon.Name} ha sido revivido con {pokemon.Health}/{pokemon.InicialHealth} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Name} aún no está debilitado.");
        }
    }
}

public class FullRestore : IItem
{
    public string Nombre => "FullRestore";

    public void Usar(IPokemon pokemon)
    {
        if (pokemon.Health > 0) // Solo puede usarse si el Pokémon está activo
        {
            pokemon.EliminarEfectosDeEstado();
            pokemon.Curar(pokemon.InicialHealth - pokemon.Health); // Restaura toda la vida
            Console.WriteLine($"{pokemon.Name} ha sido restaurado completamente.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Name} está debilitado y no puede usar Full Restore.");
        }
    }
}