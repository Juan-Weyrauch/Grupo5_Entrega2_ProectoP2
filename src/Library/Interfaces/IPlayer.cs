namespace ClassLibrary
{
    /// <summary>
    /// Define la interfaz para representar a un jugador en el juego de Pokémon,
    /// proporcionando propiedades y métodos para gestionar su equipo, inventario y Pokémon seleccionados.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Obtiene el nombre del jugador.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Obtiene la lista de items en el inventario del jugador.
        /// </summary>
        List<IItem> Inventario { get; }

        /// <summary>
        /// Obtiene la lista de Pokémon que conforman el equipo del jugador.
        /// </summary>
        List<IPokemon> Equipo { get; }

        /// <summary>
        /// Obtiene o establece el Pokémon actualmente seleccionado por el jugador.
        /// </summary>
        IPokemon SelectedPokemon { get; set; }

        /// <summary>
        /// Obtiene la lista de Pokémon debilitados (cementerio) del jugador.
        /// </summary>
        List<IPokemon> Cementerio { get; }

        /// <summary>
        /// Obtiene la cantidad de items en el inventario del jugador.
        /// </summary>
        /// <returns>El número de items en el inventario.</returns>
        int GetInventarioCount();

        /// <summary>
        /// Usa un item del inventario en un Pokémon objetivo.
        /// </summary>
        /// <param name="indiceItem">Índice del item en el inventario.</param>
        /// <param name="objetivo">El Pokémon objetivo en el que se usará el item.</param>
        void UsarItem(int indiceItem, IPokemon objetivo);
    }
}