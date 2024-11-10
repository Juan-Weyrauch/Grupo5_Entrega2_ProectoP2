using ClassLibrary;

public class Revive : IItem
{
    public string Nombre => "Revive";

    public void Usar(IPokemon pokemon)
    {
        if (pokemon.Health == 0) // Solo revive si el Pokémon está debilitado
        {
            int vidaRevive = pokemon.InicialHealth / 2;
            pokemon.Curar(vidaRevive); // Usar Curar en lugar de modificar Health directamente
            Console.WriteLine($"{pokemon.Name} ha sido revivido con {vidaRevive} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Name} aún no está debilitado.");
        }
    }
}