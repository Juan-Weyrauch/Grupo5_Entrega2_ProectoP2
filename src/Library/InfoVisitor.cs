namespace ClassLibrary
{
    /// <summary>
    /// Implementa el patrón de diseño Visitor para proporcionar información sobre el objeto <see cref="IRegistroPokemon"/>.
    /// </summary>
    public class InfoVisitor : IVisitor
    {
        /// <summary>
        /// Crea un Pokémon basado en el registro proporcionado.
        /// </summary>
        /// <param name="registroPokemon">El objeto <see cref="IRegistroPokemon"/> que contiene la información necesaria para crear un Pokémon.</param>
        /// <returns>Un objeto <see cref="IPokemon"/> que representa al Pokémon creado.</returns>
        public IPokemon visitCrearPokemon(IRegistroPokemon registroPokemon)
        {
            // Se utiliza el método CrearPokemon del registro para crear el Pokémon.
            return registroPokemon.CrearPokemon();
        }

        /// <summary>
        /// Obtiene el nombre del registro de Pokémon.
        /// </summary>
        /// <param name="registroPokemon">El objeto <see cref="IRegistroPokemon"/> que contiene la información del registro.</param>
        /// <returns>El nombre del registro como una cadena de texto.</returns>
        public string visitNombreRegistro(IRegistroPokemon registroPokemon)
        {
            // Devuelve el nombre del registro de Pokémon.
            return registroPokemon.Name;
        }

        // Aquí puedes agregar más métodos relacionados con otras operaciones que el Visitor debería realizar sobre objetos IRegistroPokemon.
    }
}