namespace ClassLibrary
{
    /// <summary>
    /// Define la interfaz para representar un Pokémon, proporcionando propiedades para sus atributos básicos
    /// y métodos para gestionar su salud y efectos de estado.
    /// </summary>
    public interface IPokemon
    {
        /// <summary>
        /// Obtiene el nombre del Pokémon.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Obtiene el valor de daño base del Pokémon.
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// Obtiene el valor de defensa base del Pokémon.
        /// </summary>
        int Defense { get; }

        /// <summary>
        /// Obtiene la salud actual del Pokémon.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Obtiene el estado actual del Pokémon. Los valores posibles son:
        /// 0 - Normal, 1 - Quemado, 2 - Envenenado, 3 - Paralizado, 4 - Dormido.
        /// </summary>
        int Estado { get; }

        /// <summary>
        /// Obtiene el tipo elemental o categoría del Pokémon.
        /// </summary>
        string Tipo { get; }

        /// <summary>
        /// Obtiene el valor de salud inicial del Pokémon.
        /// </summary>
        int InicialHealth { get; }

        /// <summary>
        /// Obtiene la lista de ataques disponibles para el Pokémon.
        /// </summary>
        List<IAtaque> Ataques { get; }

        /// <summary>
        /// Reduce la salud del Pokémon en una cantidad específica después de aplicar los cálculos de daño.
        /// </summary>
        /// <param name="valueAfterCalculation">La cantidad de salud a restar.</param>
        void DecreaseHealth(int valueAfterCalculation);

        /// <summary>
        /// Cura al Pokémon, restaurando su salud hasta un máximo de su salud inicial.
        /// </summary>
        /// <param name="cantidad">La cantidad de salud a restaurar.</param>
        void Curar(int cantidad);

        /// <summary>
        /// Elimina los efectos de estado actuales del Pokémon, restaurando su estado a normal (0).
        /// </summary>
        void EliminarEfectosDeEstado();
    }
}
