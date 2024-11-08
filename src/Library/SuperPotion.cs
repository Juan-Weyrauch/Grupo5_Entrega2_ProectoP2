namespace ClassLibrary;
public class SuperPotion : IItem
{
    public string Nombre => "SuperPotion";

    public void Usar(IPokemon pokemon)
    {
        if (pokemon.Health > 0 && pokemon.Health < pokemon.InicialHealth)
        {
            int vidaNueva = Math.Min(pokemon.Health + 70, pokemon.InicialHealth); // Por qué 70?
            pokemon.Curar(vidaNueva - pokemon.Health); // Curar solo lo necesario sin exceder
            Console.WriteLine($"{pokemon.Name} ha sido curado a {pokemon.Health}/{pokemon.InicialHealth} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Name} ya tiene la salud máxima o está debilitado.");
        }
    }
}
