namespace ClassLibrary
{
    /// <summary>
    /// Representa un Pokémon en el juego, con atributos como su nombre, daño, defensa, salud, estado, tipo y ataques disponibles.
    /// </summary>
    public class Pokemon : IPokemon
    {
        /// <summary>
        /// Obtiene el nombre del Pokémon.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Obtiene el daño base del Pokémon.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Obtiene la defensa base del Pokémon.
        /// </summary>
        public int Defense { get; private set; }

        /// <summary>
        /// Obtiene la cantidad actual de salud del Pokémon.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Obtiene el estado actual del Pokémon. Los valores posibles son:
        /// 0 - Normal, 1 - Quemado, 2 - Envenenado, 3 - Paralizado, 4 - Dormido.
        /// </summary>
        public int Estado { get; private set; }

        /// <summary>
        /// Obtiene la salud máxima inicial del Pokémon.
        /// </summary>
        public int InicialHealth { get; private set; }

        /// <summary>
        /// Obtiene la lista de ataques disponibles para el Pokémon.
        /// </summary>
        public List<IAtaque> Ataques { get; private set; }

        /// <summary>
        /// Obtiene el tipo del Pokémon (por ejemplo, fuego, agua, planta, etc.).
        /// </summary>
        public string Tipo { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <c>Pokemon</c> con los valores de nombre, daño, defensa, salud, tipo y lista de ataques.
        /// El estado se inicializa como normal (0) y la salud inicial se establece al valor de la salud total.
        /// </summary>
        /// <param name="name">El nombre del Pokémon.</param>
        /// <param name="damage">El daño base del Pokémon.</param>
        /// <param name="defense">La defensa base del Pokémon.</param>
        /// <param name="health">La salud total del Pokémon.</param>
        /// <param name="tipo">El tipo del Pokémon (por ejemplo, fuego, agua, planta, etc.).</param>
        /// <param name="ataques">La lista de ataques disponibles para el Pokémon.</param>
        public Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> ataques)
        {
            Name = name;
            Damage = damage;
            Defense = defense;
            Health = health;
            Tipo = tipo;
            Ataques = ataques;
            InicialHealth = health;
            Estado = 0; // Por defecto el estado es normal.
        }

        /// <summary>
        /// Disminuye la salud del Pokémon después de un cálculo de daño.
        /// Si la salud es menor que 0, se establece a 0.
        /// </summary>
        /// <param name="valueAfterCalculation">La cantidad de daño calculado que se restará de la salud del Pokémon.</param>
        public void DecreaseHealth(int valueAfterCalculation)
        {
            Health -= valueAfterCalculation;
            if (Health < 0) Health = 0; // Si la salud baja de 0, se ajusta a 0.
        }

        /// <summary>
        /// Cura al Pokémon, aumentando su salud en una cantidad específica sin exceder la salud máxima.
        /// </summary>
        /// <param name="cantidad">La cantidad de salud que se restaurará al Pokémon.</param>
        public void Curar(int cantidad)
        {
            Health = Math.Min(Health + cantidad, InicialHealth); // La salud no puede exceder la salud máxima.
        }

        /// <summary>
        /// Elimina todos los efectos de estado actuales del Pokémon, devolviendo su estado a normal (0).
        /// </summary>
        public void EliminarEfectosDeEstado()
        {
            Estado = 0; // Restablece el estado a normal.
        }
    }
}
