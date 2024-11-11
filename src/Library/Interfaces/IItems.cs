namespace ClassLibrary
{
    /// <summary>
    /// Define la interfaz para representar un item en el juego de Pokémon,
    /// proporcionando propiedades y métodos para su nombre y uso.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Obtiene el nombre del item.
        /// </summary>
        string Nombre { get; }

        /// <summary>
        /// Aplica el efecto del item en un Pokémon objetivo.
        /// </summary>
        /// <param name="pokemon">El Pokémon objetivo sobre el cual se usará el item.</param>
        void Usar(IPokemon pokemon);
    }
}
