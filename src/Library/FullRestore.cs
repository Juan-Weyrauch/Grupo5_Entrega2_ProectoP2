namespace Library;

public class FullRestore : IItems
{
    public string Nombre => "FullRestore";

    public void Usar(IPokemon pokemon)
    {
        if (pokemon.Health > 0)
        {
            pokemon.EliminarEfectosDeEstado(); // Método que asume que elimina todos los efectos de estado
            Console.WriteLine($"{pokemon.Name} ha sido restaurado completamente y se han eliminado los efectos negativos.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Name} está debilitado y no puede usar Full Restore.");
        }
    }
}
