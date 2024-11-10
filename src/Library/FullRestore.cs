namespace ClassLibrary
{
    /// <summary>
    /// Representa un objeto de tipo <c>FullRestore</c>, que es un ítem utilizado para restaurar completamente la salud de un Pokémon 
    /// y eliminar cualquier efecto de estado negativo que pueda tener.
    /// </summary>
    public class FullRestore : IItem
    {
        /// <summary>
        /// Obtiene el nombre del ítem, en este caso siempre será "FullRestore".
        /// </summary>
        public string Nombre => "FullRestore";

        /// <summary>
        /// Utiliza el <c>FullRestore</c> para restaurar completamente la salud del Pokémon y eliminar cualquier efecto negativo de estado.
        /// Solo se puede usar si el Pokémon está vivo (su salud es mayor a 0).
        /// </summary>
        /// <param name="pokemon">El Pokémon al que se le va a aplicar el FullRestore.</param>
        public void Usar(IPokemon pokemon)
        {
            // Verifica si el Pokémon está vivo (salud mayor a 0)
            if (pokemon.Health > 0)
            {
                // Elimina los efectos negativos de estado del Pokémon (como parálisis, veneno, etc.)
                pokemon.EliminarEfectosDeEstado();
                Console.WriteLine($"{pokemon.Name} ha sido restaurado completamente y se han eliminado los efectos negativos.");
            }
            else
            {
                // Si el Pokémon está debilitado, no se puede usar FullRestore
                Console.WriteLine($"{pokemon.Name} está debilitado y no puede usar Full Restore.");
            }
        }
    }
}