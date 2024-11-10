namespace ClassLibrary
{
    /// <summary>
    /// Define la interfaz para representar un ataque en el juego de Pokémon,
    /// proporcionando propiedades para sus atributos, como el nombre, poder, precisión, tipo y si es un ataque especial.
    /// </summary>
    public interface IAtaque
    {
        /// <summary>
        /// Obtiene el nombre del ataque.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Obtiene el poder del ataque, que determina su impacto en la salud del oponente.
        /// </summary>
        int Poder { get; }

        /// <summary>
        /// Obtiene la precisión del ataque, que representa la probabilidad de éxito.
        /// </summary>
        int Precision { get; }

        /// <summary>
        /// Obtiene el tipo del ataque, como "Fuego", "Agua", etc., que afecta la efectividad según el tipo del oponente.
        /// </summary>
        string Tipo { get; }

        /// <summary>
        /// Indica si el ataque es especial (valor mayor que cero), lo cual puede afectar cómo interactúa con las defensas del oponente.
        /// </summary>
        int Especial { get; }
    }
}