namespace ClassLibrary
{
    public class TablaDeTipos
    {
        // Diccionario que almacena las relaciones de fortalezas, debilidades e inmunidades para cada tipo
       static private Dictionary<string, (List<string> fortalezas, List<string> debilidades, List<string> inmunidades)> TablaTiposPokemon;

         static TablaDeTipos()
        {
            TablaTiposPokemon = new Dictionary<string, (List<string>, List<string>, List<string>)>();
            CrearTabla();
        }

        private static void CrearTabla()
        {
            // Llenado del diccionario con las relaciones de cada tipo
            TablaTiposPokemon["Agua"] = (
                fortalezas: new List<string> { "Fuego", "Tierra", "Roca" },
                debilidades: new List<string> { "Eléctrico", "Planta" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Bicho"] = (
                fortalezas: new List<string> { "Planta", "Psíquico", "Siniestro" },
                debilidades: new List<string> { "Fuego", "Roca", "Volador", "Veneno" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Dragón"] = (
                fortalezas: new List<string> { "Dragón" },
                debilidades: new List<string> { "Hielo", "Dragón" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Eléctrico"] = (
                fortalezas: new List<string> { "Agua", "Volador" },
                debilidades: new List<string> { "Tierra" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Fantasma"] = (
                fortalezas: new List<string> { "Fantasma", "Psíquico" },
                debilidades: new List<string> { "Fantasma" },
                inmunidades: new List<string> { "Normal" }
            );

            TablaTiposPokemon["Fuego"] = (
                fortalezas: new List<string> { "Planta", "Hielo", "Bicho" },
                debilidades: new List<string> { "Agua", "Roca", "Tierra" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Hielo"] = (
                fortalezas: new List<string> { "Planta", "Tierra", "Dragón", "Volador" },
                debilidades: new List<string> { "Fuego", "Lucha", "Roca" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Lucha"] = (
                fortalezas: new List<string> { "Normal", "Hielo", "Roca", "Bicho" },
                debilidades: new List<string> { "Psíquico", "Volador" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Normal"] = (
                fortalezas: new List<string>(),
                debilidades: new List<string> { "Lucha" },
                inmunidades: new List<string> { "Fantasma" }
            );

            TablaTiposPokemon["Planta"] = (
                fortalezas: new List<string> { "Agua", "Tierra", "Roca" },
                debilidades: new List<string> { "Fuego", "Volador", "Bicho", "Veneno", "Hielo" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Psíquico"] = (
                fortalezas: new List<string> { "Lucha", "Veneno" },
                debilidades: new List<string> { "Bicho", "Fantasma" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Roca"] = (
                fortalezas: new List<string> { "Fuego", "Hielo", "Volador", "Bicho" },
                debilidades: new List<string> { "Agua", "Lucha", "Planta", "Tierra" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Tierra"] = (
                fortalezas: new List<string> { "Fuego", "Eléctrico", "Veneno", "Roca" },
                debilidades: new List<string> { "Agua", "Hielo", "Planta" },
                inmunidades: new List<string> { "Eléctrico" }
            );

            TablaTiposPokemon["Veneno"] = (
                fortalezas: new List<string> { "Planta", "Hada" },
                debilidades: new List<string> { "Psíquico", "Tierra" },
                inmunidades: new List<string>()
            );

            TablaTiposPokemon["Volador"] = (
                fortalezas: new List<string> { "Planta", "Lucha", "Bicho" },
                debilidades: new List<string> { "Eléctrico", "Hielo", "Roca" },
                inmunidades: new List<string>()
            );
        }
     
        // Método para obtener las relaciones de un tipo específico
        public (List<string> fortalezas, List<string> debilidades, List<string> inmunidades) ObtenerRelaciones(string tipo)
        {
            return TablaTiposPokemon[tipo];
        }
    }
}
