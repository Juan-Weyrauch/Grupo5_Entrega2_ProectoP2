namespace ClassLibrary
{
    public class TablaDeTipos
    {
        // Diccionario que almacena todos los tipos de Pokémon
        private Dictionary<string, ITipoPokemon> tipos;

        public TablaDeTipos()
        {
            // Inicialización del diccionario con cada tipo de Pokémon
            tipos = new Dictionary<string, ITipoPokemon>
            {
                { "Agua", new TipoPokemon("Agua") },
                { "Fuego", new TipoPokemon("Fuego") },
                { "Planta", new TipoPokemon("Planta") },
                { "Eléctrico", new TipoPokemon("Eléctrico") },
                { "Hielo", new TipoPokemon("Hielo") },
                { "Lucha", new TipoPokemon("Lucha") },
                { "Veneno", new TipoPokemon("Veneno") },
                { "Tierra", new TipoPokemon("Tierra") },
                { "Volador", new TipoPokemon("Volador") },
                { "Psíquico", new TipoPokemon("Psíquico") },
                { "Bicho", new TipoPokemon("Bicho") },
                { "Roca", new TipoPokemon("Roca") },
                { "Fantasma", new TipoPokemon("Fantasma") },
                { "Dragón", new TipoPokemon("Dragón") },
                { "Normal", new TipoPokemon("Normal") }
            };

            // Establecer relaciones de cada tipo
            EstablecerRelaciones();
        }

        private void EstablecerRelaciones()
        {
            tipos["Agua"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon> { tipos["Fuego"], tipos["Tierra"], tipos["Roca"] },
                Debilidades: new List<ITipoPokemon> { tipos["Eléctrico"], tipos["Planta"] },
                Immnunidades: new List<ITipoPokemon>()
            );

            tipos["Fuego"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon> { tipos["Planta"], tipos["Hielo"], tipos["Bicho"] },
                Debilidades: new List<ITipoPokemon> { tipos["Agua"], tipos["Roca"], tipos["Tierra"] },
                Immnunidades: new List<ITipoPokemon>()
            );

            tipos["Planta"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon> { tipos["Agua"], tipos["Tierra"], tipos["Roca"] },
                Debilidades: new List<ITipoPokemon> { tipos["Fuego"], tipos["Volador"], tipos["Bicho"], tipos["Veneno"], tipos["Hielo"] },
                Immnunidades: new List<ITipoPokemon>()
            );

            tipos["Eléctrico"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon> { tipos["Agua"], tipos["Volador"] },
                Debilidades: new List<ITipoPokemon> { tipos["Tierra"] },
                Immnunidades: new List<ITipoPokemon>()
            );

            tipos["Hielo"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon> { tipos["Planta"], tipos["Tierra"], tipos["Dragón"], tipos["Volador"] },
                Debilidades: new List<ITipoPokemon> { tipos["Fuego"], tipos["Agua"], tipos["Lucha"], tipos["Roca"] },
                Immnunidades: new List<ITipoPokemon>()
            );

            tipos["Lucha"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon> { tipos["Normal"], tipos["Hielo"], tipos["Roca"] },
                Debilidades: new List<ITipoPokemon> { tipos["Volador"], tipos["Psíquico"] },
                Immnunidades: new List<ITipoPokemon>()
            );

            tipos["Normal"].EstablecerRelacionesElementales(
                Fortalezas: new List<ITipoPokemon>(),
                Debilidades: new List<ITipoPokemon> { tipos["Lucha"] },
                Immnunidades: new List<ITipoPokemon> { tipos["Fantasma"] }
            );

            // Repite para el resto de tipos de Pokémon...
        }

        // Método para acceder a un tipo de Pokémon por nombre
        public ITipoPokemon ObtenerTipo(string nombre)
        {
            return tipos.ContainsKey(nombre) ? tipos[nombre] : null;
        }
    }
}
