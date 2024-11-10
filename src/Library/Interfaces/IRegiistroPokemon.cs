namespace ClassLibrary
{
    /// <summary>
    /// Define la interfaz para los registros de Pokémon, proporcionando propiedades para sus atributos básicos
    /// y métodos para crear y obtener información del Pokémon usando el patrón Visitor.
    /// </summary>
    public interface IRegistroPokemon
    {
        /// <summary>
        /// Obtiene el nombre del registro de Pokémon.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Obtiene el valor de daño base del Pokémon en el registro.
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// Obtiene el valor de salud base del Pokémon en el registro.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Obtiene el tipo elemental o categoría del Pokémon en el registro.
        /// </summary>
        string Tipo { get; }

        /// <summary>
        /// Obtiene la lista de ataques disponibles para el Pokémon en el registro.
        /// </summary>
        List<IAtaque> Ataques { get; }

        /// <summary>
        /// Crea un nuevo objeto <see cref="IPokemon"/> basado en los atributos del registro actual.
        /// </summary>
        /// <returns>Un objeto <see cref="IPokemon"/> creado a partir de este registro.</returns>
        IPokemon CrearPokemon();

        /// <summary>
        /// Acepta un objeto Visitor para obtener el nombre del registro mediante el patrón Visitor.
        /// </summary>
        /// <param name="visitor">El objeto Visitor que realizará la operación.</param>
        /// <returns>El nombre del registro de Pokémon.</returns>
        string AcceptObtenerNombre(IVisitor visitor);

        /// <summary>
        /// Acepta un objeto Visitor para crear un Pokémon a partir del registro mediante el patrón Visitor.
        /// </summary>
        /// <param name="visitor">El objeto Visitor que realizará la operación.</param>
        /// <returns>Un nuevo objeto <see cref="IPokemon"/> creado por el Visitor.</returns>
        IPokemon AcceptCrearPokemon(IVisitor visitor);
    }
}
