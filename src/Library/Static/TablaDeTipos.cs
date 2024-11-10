
    // Diccionario que almacena las relaciones de fortalezas, debilidades e inmunidades para cada tipo
  

    namespace ClassLibrary
    {
        /// <summary>
        /// La clase <c>TablaDeTipos</c> gestiona las relaciones de fortalezas, debilidades e inmunidades
        /// entre los tipos de Pokémon. Su función es proporcionar los datos sobre las interacciones de los tipos
        /// y calcular la efectividad de un ataque según el tipo del Pokémon atacado.
        /// </summary>

        public class TablaDeTipos
        {
            // Diccionario que almacena las relaciones de fortalezas, debilidades e inmunidades para cada tipo
            /// <summary>
            /// Diccionario que almacena las relaciones de fortalezas, debilidades e inmunidades de cada tipo de Pokémon.
            /// </summary>
            static private Dictionary<string, (List<string> fortalezas, List<string> debilidades, List<string> inmunidades)> TablaTiposPokemon;

            // Método para inicializar los datos de la tabla
            /// <summary>
            /// Inicializa el diccionario <c>TablaTiposPokemon</c> con las relaciones de fortalezas, debilidades e inmunidades
            /// de los tipos de Pokémon.
            /// </summary>
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
            /// <summary>
            /// Obtiene las relaciones de un tipo específico de Pokémon, incluyendo sus fortalezas, debilidades e inmunidades.
            /// </summary>
            /// <param name="tipo">El tipo de Pokémon cuya relación se desea obtener.</param>
            /// <returns>Una tupla con tres listas: fortalezas, debilidades e inmunidades del tipo.</returns>
            public static (List<string> fortalezas, List<string> debilidades, List<string> inmunidades) ObtenerRelaciones(string tipo)
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
            /// <summary>
            /// Calcula la efectividad de un ataque basado en las relaciones de tipos. La efectividad
            /// se devuelve como un valor numérico: 0 para inmunidad, 0.5 para debilidad, 2 para fortaleza,
            /// y 1 para una relación neutral.
            /// </summary>
            /// <param name="tipoAtaque">El tipo del ataque que se está utilizando.</param>
            /// <param name="tipoPokemon">El tipo del Pokémon que está siendo atacado.</param>
            /// <returns>Devuelve un valor numérico que representa la efectividad del ataque.</returns>
            public static double ObtenterRelacionMatematica(string tipoAtaque, string tipoPokemon)
            {
                (List<string> fortalezas, List<string> debilidades, List<string> inmunidades) listaRelaciones =
                    ObtenerRelaciones(tipoPokemon);
                if (listaRelaciones.inmunidades.Contains(tipoAtaque))
                {
                    return 0;
                }

                if (listaRelaciones.debilidades.Contains(tipoAtaque))
                {
                    return 2;
                }

                if (listaRelaciones.fortalezas.Contains(tipoAtaque))
                {
                    return 0.5;
                }
                else
                {
                    return 1;
                }

            }
        }
    }