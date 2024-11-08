
    // Diccionario que almacena las relaciones de fortalezas, debilidades e inmunidades para cada tipo
  

    namespace ClassLibrary
    {
        public class TablaDeTipos
        {
            // Diccionario que almacena las relaciones de fortalezas, debilidades e inmunidades para cada tipo
            static private
                Dictionary<string, (List<string> fortalezas, List<string> debilidades, List<string> inmunidades)>
                TablaTiposPokemon;

            // Método para inicializar los datos de la tabla
            public static void CrearTabla()
            {
                // Inicializa el diccionario
                TablaTiposPokemon = new Dictionary<string, (List<string>, List<string>, List<string>)>();

                // Llenado del diccionario con las relaciones de cada tipo
                TablaTiposPokemon["Agua"] = (
                    new List<string> { "Fuego", "Tierra", "Roca" }, // Fortalezas
                    new List<string> { "Eléctrico", "Planta" }, // Debilidades
                    new List<string>() // Inmunidades
                );

                TablaTiposPokemon["Bicho"] = (
                    new List<string> { "Planta", "Psíquico", "Siniestro" },
                    new List<string> { "Fuego", "Roca", "Volador", "Veneno" },
                    new List<string>()
                );

                TablaTiposPokemon["Dragón"] = (
                    new List<string> { "Dragón" },
                    new List<string> { "Hielo", "Dragón" },
                    new List<string>()
                );

                TablaTiposPokemon["Eléctrico"] = (
                    new List<string> { "Agua", "Volador" },
                    new List<string> { "Tierra" },
                    new List<string>()
                );

                TablaTiposPokemon["Fantasma"] = (
                    new List<string> { "Fantasma", "Psíquico" },
                    new List<string> { "Fantasma" },
                    new List<string> { "Normal" }
                );

                TablaTiposPokemon["Fuego"] = (
                    new List<string> { "Planta", "Hielo", "Bicho" },
                    new List<string> { "Agua", "Roca", "Tierra" },
                    new List<string>()
                );

                TablaTiposPokemon["Hielo"] = (
                    new List<string> { "Planta", "Tierra", "Dragón", "Volador" },
                    new List<string> { "Fuego", "Lucha", "Roca" },
                    new List<string>()
                );

                TablaTiposPokemon["Lucha"] = (
                    new List<string> { "Normal", "Hielo", "Roca", "Bicho" },
                    new List<string> { "Psíquico", "Volador" },
                    new List<string>()
                );

                TablaTiposPokemon["Normal"] = (
                    new List<string>(),
                    new List<string> { "Lucha" },
                    new List<string> { "Fantasma" }
                );

                TablaTiposPokemon["Planta"] = (
                    new List<string> { "Agua", "Tierra", "Roca" },
                    new List<string> { "Fuego", "Volador", "Bicho", "Veneno", "Hielo" },
                    new List<string>()
                );

                TablaTiposPokemon["Psíquico"] = (
                    new List<string> { "Lucha", "Veneno" },
                    new List<string> { "Bicho", "Fantasma" },
                    new List<string>()
                );

                TablaTiposPokemon["Roca"] = (
                    new List<string> { "Fuego", "Hielo", "Volador", "Bicho" },
                    new List<string> { "Agua", "Lucha", "Planta", "Tierra" },
                    new List<string>()
                );

                TablaTiposPokemon["Tierra"] = (
                    new List<string> { "Fuego", "Eléctrico", "Veneno", "Roca" },
                    new List<string> { "Agua", "Hielo", "Planta" },
                    new List<string> { "Eléctrico" }
                );

                TablaTiposPokemon["Veneno"] = (
                    new List<string> { "Planta", "Hada" },
                    new List<string> { "Psíquico", "Tierra" },
                    new List<string>()
                );

                TablaTiposPokemon["Volador"] = (
                    new List<string> { "Planta", "Lucha", "Bicho" },
                    new List<string> { "Eléctrico", "Hielo", "Roca" },
                    new List<string>()
                );
            }

            // Método para obtener las relaciones de un tipo específico
            public static (List<string> fortalezas, List<string> debilidades, List<string> inmunidades)
                ObtenerRelaciones(string tipo)
            {
                if (TablaTiposPokemon.ContainsKey(tipo))
                {
                    return TablaTiposPokemon[tipo];
                }
                else
                {
                    // Si el tipo no se encuentra, devolver valores predeterminados (vacíos)
                    return (new List<string>(), new List<string>(), new List<string>());
                }
            }
        }
    }