namespace ClassLibrary
{
    /// <summary>
    /// Representa un jugador en el juego, con un nombre, equipo de Pokémon, Pokémon seleccionado, inventario de ítems y un cementerio de Pokémon debilitados.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Obtiene el nombre del jugador.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Obtiene o establece el equipo de Pokémon del jugador.
        /// </summary>
        public List<IPokemon> Equipo { get; private set; }

        /// <summary>
        /// Obtiene o establece el Pokémon seleccionado por el jugador para luchar.
        /// </summary>
        public IPokemon SelectedPokemon { get; set; }

        /// <summary>
        /// Obtiene o establece el inventario de ítems del jugador.
        /// </summary>
        public List<IItem> Inventario { get; private set; }

        /// <summary>
        /// Obtiene o establece el cementerio de Pokémon debilitados del jugador.
        /// </summary>
        public List<IPokemon> Cementerio { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <c>Player</c> con el nombre, equipo de Pokémon y la elección de un Pokémon inicial.
        /// También asigna un inventario predeterminado de ítems.
        /// </summary>
        /// <param name="name">El nombre del jugador.</param>
        /// <param name="equipo">La lista de Pokémon que conforman el equipo del jugador.</param>
        /// <param name="EleccionEquipo">El índice del Pokémon elegido como inicial.</param>
        public Player(string name, List<IPokemon> equipo, int EleccionEquipo)
        {
            Name = name;
            Equipo = equipo;
            SelectedPokemon = Equipo[EleccionEquipo]; // Esto permite elegir al Pokémon de una manera lógica.
            Inventario = new List<IItem>
            {
                new SuperPotion(),
                new SuperPotion(),
                new SuperPotion(),
                new SuperPotion(),
                new Revive(),
                new FullRestore(),
                new FullRestore()
            };
        }

        /// <summary>
        /// Permite al jugador usar un ítem de su inventario en un Pokémon objetivo.
        /// El ítem es eliminado del inventario después de ser utilizado.
        /// </summary>
        /// <param name="indiceItem">El índice del ítem que el jugador quiere usar.</param>
        /// <param name="objetivo">El Pokémon sobre el cual se va a usar el ítem.</param>
        public void UsarItem(int indiceItem, IPokemon objetivo)
        {
            // Verifica si el índice del ítem es válido
            if (indiceItem >= 0 && indiceItem < Inventario.Count)
            {
                IItem item = Inventario[indiceItem];
                item.Usar(objetivo); // Usa el ítem en el Pokémon objetivo
                Inventario.RemoveAt(indiceItem); // Elimina el ítem después de usarlo
            }
            else
            {
                // Si el índice es inválido, muestra un mensaje
                Console.WriteLine("Ítem no válido.");
            }
        }

        /// <summary>
        /// Obtiene la cantidad de ítems en el inventario del jugador.
        /// </summary>
        /// <returns>La cantidad de ítems en el inventario.</returns>
        public int GetInventarioCount()
        {
            return Inventario.Count();
        }
    }
}
