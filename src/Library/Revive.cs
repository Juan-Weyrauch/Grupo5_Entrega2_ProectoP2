namespace ClassLibrary
{
    /// <summary>
    /// Representa un objeto de tipo <c>Revive</c>, que es un ítem que puede ser usado para revivir a un Pokémon debilitado.
    /// </summary>
    public class Revive : IItem
    {
        /// <summary>
        /// Obtiene el nombre del ítem, en este caso siempre será "Revive".
        /// </summary>
        public string Nombre => "Revive";

        /// <summary>
        /// Utiliza el <c>Revive</c> para revivir al <paramref name="pokemon"/> si está debilitado (salud = 0).
        /// El Pokémon es revivido con el 50% de su salud inicial.
        /// </summary>
        /// <param name="pokemon">El Pokémon al que se le va a aplicar el revivir.</param>
        public void Usar(IPokemon pokemon)
        {
            // Verifica si el Pokémon está debilitado (salud = 0)
            if (pokemon.Health == 0)
            {
                // Calcula la cantidad de salud para revivir al Pokémon con el 50% de su salud inicial
                int vidaRevive = pokemon.InicialHealth / 2;
                pokemon.Curar(vidaRevive); // Cura al Pokémon con la cantidad calculada
                Console.WriteLine($"{pokemon.Name} ha sido revivido con {vidaRevive} puntos de vida.");
            }
            else
            {
                // Si el Pokémon no está debilitado, muestra un mensaje indicando que no puede ser revivido
                Console.WriteLine($"{pokemon.Name} aún no está debilitado.");
            }
        }
    }
}