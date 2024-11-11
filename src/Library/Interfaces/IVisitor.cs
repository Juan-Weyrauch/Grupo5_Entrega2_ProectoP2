namespace ClassLibrary
{
    /// <summary>
    /// Define la interfaz para la implementación del patrón Visitor, permitiendo que los visitantes realicen operaciones
    /// sobre diferentes elementos de tipo <see cref="IRegistroPokemon"/>.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Visita un registro de Pokémon para crear un nuevo objeto <see cref="IPokemon"/>.
        /// </summary>
        /// <param name="registroPokemon">El registro de Pokémon a partir del cual se creará un Pokémon.</param>
        /// <returns>Un nuevo objeto <see cref="IPokemon"/> creado a partir del registro.</returns>
        IPokemon visitCrearPokemon(IRegistroPokemon registroPokemon);

        /// <summary>
        /// Visita un registro de Pokémon y obtiene el nombre del mismo.
        /// </summary>
        /// <param name="registroPokemon">El registro de Pokémon del cual se obtendrá el nombre.</param>
        /// <returns>El nombre del registro de Pokémon.</returns>
        string visitNombreRegistro(IRegistroPokemon registroPokemon);

        // Otros métodos comentados que podrían implementar visitas adicionales, por ejemplo:
        // void Visit(IPokemon pokemon);
        // void Visit(Player jugador);
    }
}