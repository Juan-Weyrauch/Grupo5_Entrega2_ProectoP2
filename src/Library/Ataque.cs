namespace ClassLibrary
{
    /// <summary>
    /// Representa un ataque en el juego, con propiedades que definen su nombre, poder, precisión, tipo y atributos especiales.
    /// Esta clase implementa la interfaz <c>IAtaque</c> y se utiliza para definir los ataques que pueden ser utilizados por los Pokémon.
    /// </summary>
    public class Ataque : IAtaque
    {
        /// <summary>
        /// Obtiene el nombre del ataque.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Obtiene el poder del ataque, que determina la cantidad de daño que inflige.
        /// </summary>
        public int Poder { get; private set; }

        /// <summary>
        /// Obtiene la precisión del ataque, que indica la probabilidad de que el ataque tenga éxito.
        /// </summary>
        public int Precision { get; private set; }

        /// <summary>
        /// Obtiene el tipo del ataque (por ejemplo, Fuego, Agua, Eléctrico, etc.).
        /// </summary>
        public string Tipo { get; private set; }

        /// <summary>
        /// Obtiene el valor especial del ataque, que puede estar relacionado con efectos adicionales o características específicas del ataque.
        /// </summary>
        public int Especial { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <c>Ataque</c> con los valores proporcionados.
        /// </summary>
        /// <param name="name">El nombre del ataque.</param>
        /// <param name="poder">El poder del ataque, que determina el daño infligido.</param>
        /// <param name="precision">La precisión del ataque, que indica la probabilidad de éxito.</param>
        /// <param name="tipo">El tipo de ataque (por ejemplo, Fuego, Agua, Eléctrico, etc.).</param>
        /// <param name="especial">El valor especial del ataque, relacionado con efectos adicionales.</param>
        public Ataque(string name, int poder, int precision, string tipo, int especial)
        {
            Name = name;
            Poder = poder;
            Precision = precision;
            Tipo = tipo;
            Especial = especial;
        }
    }
}
