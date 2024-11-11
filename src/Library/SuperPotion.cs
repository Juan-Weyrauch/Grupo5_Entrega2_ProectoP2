namespace ClassLibrary
{
    /// <summary>
    /// Representa un objeto de tipo <c>SuperPotion</c>, que es un ítem que puede ser usado para curar a un Pokémon.
    /// </summary>
    public class SuperPotion : IItem
    {
        /// <summary>
        /// Obtiene el nombre del ítem, en este caso siempre será "SuperPotion".
        /// </summary>
        public string Nombre => "SuperPotion";

        /// <summary>
        /// Utiliza la <c>SuperPotion</c> para curar al <paramref name="pokemon"/>, aumentando su salud sin exceder el máximo.
        /// Si el Pokémon ya tiene la salud completa o está debilitado (salud <= 0), no se puede usar.
        /// </summary>
        /// <param name="pokemon">El Pokémon al que se le va a aplicar la curación.</param>
        public void Usar(IPokemon pokemon)
        {
            // Verifica si el Pokémon tiene salud y no está en su valor máximo
            if (pokemon.Health > 0 && pokemon.Health < pokemon.InicialHealth)
            {
                // Calcula la nueva salud del Pokémon, sin exceder el valor máximo
                int vidaNueva = Math.Min(pokemon.Health + 70, pokemon.InicialHealth); // 70 es el valor curado por la SuperPotion
                pokemon.Curar(vidaNueva - pokemon.Health); // Cura solo la diferencia, sin exceder el límite
                Console.WriteLine($"{pokemon.Name} ha sido curado a {pokemon.Health}/{pokemon.InicialHealth} puntos de vida.");
            }
            else
            {
                // Si la salud está al máximo o el Pokémon está debilitado, muestra un mensaje
                Console.WriteLine($"{pokemon.Name} ya tiene la salud máxima o está debilitado.");
            }
        }
    }
}