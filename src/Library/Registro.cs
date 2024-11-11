namespace ClassLibrary
{
    /// <summary>
    /// Representa un registro de un Pokémon, que contiene los atributos y ataques necesarios para crear un Pokémon.
    /// </summary>
    public class Registro : IRegistroPokemon
    {
        /// <summary>
        /// Obtiene el nombre del Pokémon registrado.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Obtiene el daño base del Pokémon registrado.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Obtiene la salud base del Pokémon registrado.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Obtiene la defensa base del Pokémon registrado.
        /// </summary>
        public int Defense { get; private set; }

        /// <summary>
        /// Obtiene el tipo de Pokémon registrado.
        /// </summary>
        public string Tipo { get; private set; }

        /// <summary>
        /// Obtiene la lista de ataques del Pokémon registrado.
        /// </summary>
        public List<IAtaque> Ataques { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Registro"/> con los valores proporcionados.
        /// </summary>
        /// <param name="name">El nombre del Pokémon.</param>
        /// <param name="damage">El daño base del Pokémon.</param>
        /// <param name="health">La salud base del Pokémon.</param>
        /// <param name="defense">La defensa base del Pokémon.</param>
        /// <param name="tipo">El tipo del Pokémon.</param>
        /// <param name="ataques">La lista de ataques del Pokémon.</param>
        public Registro(string name, int damage, int health, int defense, string tipo, List<IAtaque> ataques)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Defense = defense;
            Tipo = tipo;
            Ataques = ataques;
        }

        /// <summary>
        /// Crea un nuevo objeto <see cref="IPokemon"/> basado en el registro de Pokémon actual.
        /// </summary>
        /// <returns>Un objeto <see cref="IPokemon"/> con los atributos del registro.</returns>
        public IPokemon CrearPokemon()
        {
            return new Pokemon(this.Name, this.Damage, this.Health, this.Defense, this.Tipo, this.Ataques);
        }

        /// <summary>
        /// Acepta un visitante que obtiene el nombre del registro de Pokémon.
        /// </summary>
        /// <param name="visitor">El visitante que realiza la operación.</param>
        /// <returns>El nombre del registro de Pokémon.</returns>
        public string AcceptObtenerNombre(IVisitor visitor)
        {
            return visitor.visitNombreRegistro(this);
        }

        /// <summary>
        /// Acepta un visitante que crea un Pokémon basado en el registro de Pokémon.
        /// </summary>
        /// <param name="visitor">El visitante que realiza la operación.</param>
        /// <returns>Un objeto <see cref="IPokemon"/> creado a partir del registro.</returns>
        public IPokemon AcceptCrearPokemon(IVisitor visitor)
        {
            return visitor.visitCrearPokemon(this);
        }
    }
}
