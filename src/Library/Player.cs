namespace ClassLibrary
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public List<IPokemon> Equipo { get; private set; }
        public IPokemon SelectedPokemon { get; set; }
        public List<IItem> Inventario { get; private set; }
        public List<IPokemon> Cementerio { get; private set; }

        public Player(string name, List<IPokemon> equipo, int eleccionEquipo)
        {
            Name = name;
            Equipo = equipo;
            SelectedPokemon = Equipo[eleccionEquipo];
            Cementerio = new List<IPokemon>();
            Inventario = new List<IItem>
            {
                new SuperPotion(),
                new SuperPotion(),
                new SuperPotion(),
                new SuperPotion(),
                new Revive(),
                new FullRestore(),
                new FullRestore()
            };
        }

        /// <summary>
        /// Usa un ítem del inventario en el Pokémon objetivo.
        /// </summary>
        /// <param name="indiceItem">Índice del ítem en el inventario.</param>
        /// <param name="objetivo">El Pokémon en el cual se usará el ítem.</param>
        public void UsarItem(int indiceItem, IPokemon objetivo = null)
        {
            if (indiceItem < 0 || indiceItem >= Inventario.Count)
            {
                Console.WriteLine("Ítem no válido.");
                return;
            }

            IItem item = Inventario[indiceItem];

            if (item is Revive)
            {
                // Selecciona un Pokémon del Cementerio para revivir
                IPokemon pokemonParaRevivir = SeleccionarPokemonParaRevivir();
                if (pokemonParaRevivir != null && pokemonParaRevivir.Health == 0)
                {
                    Console.WriteLine($"Usando Revive en {pokemonParaRevivir.Name} con {pokemonParaRevivir.Health} puntos de salud.");
                    item.Usar(pokemonParaRevivir);  // Aplica el Revive
                    Cementerio.Remove(pokemonParaRevivir);  // Elimina el Pokémon del Cementerio
                    Equipo.Add(pokemonParaRevivir);  // Devuelve el Pokémon al Equipo
                    Inventario.RemoveAt(indiceItem); // Elimina el ítem del inventario tras su uso
                }
                else
                {
                    Console.WriteLine("No hay Pokémon seleccionable para revivir.");
                }
            }
            else if ((item is FullRestore || item is SuperPotion) && objetivo != null && objetivo.Health > 0 && objetivo.Health < objetivo.InicialHealth)
            {
                Console.WriteLine($"Usando {item.Nombre} en {objetivo.Name} con {objetivo.Health}/{objetivo.InicialHealth} puntos de salud.");
                item.Usar(objetivo);
                Inventario.RemoveAt(indiceItem);
            }
            else
            {
                Console.WriteLine("No puedes usar ese ítem en este Pokémon.");
            }
        }






        /// <summary>
        /// Devuelve el conteo de ítems en el inventario.
        /// </summary>
        public int GetInventarioCount()
        {
            return Inventario.Count;
        }

        public void EliminarPokemon(IPokemon objetivo)
        {
            if (objetivo == null || Equipo == null || Cementerio == null)
                return;

            if (Equipo.Contains(objetivo) && objetivo.Health == 0) // Verifica que el Pokémon esté en el Equipo y tenga Health = 0
            {
                Equipo.Remove(objetivo);       // Elimina el Pokémon del Equipo
                Cementerio.Add(objetivo);      // Agrega el Pokémon al Cementerio
                Console.WriteLine($"{objetivo.Name} ha sido movido al Cementerio.");
            }
        }


        private void SeleccionarNuevoTitular()
        {
            if (Equipo.Count == 0)
            {
                Console.WriteLine("No tienes más Pokémon en el equipo.");
                return;
            }

            Console.WriteLine("Selecciona un nuevo Pokémon titular:");
            for (int i = 0; i < Equipo.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Equipo[i].Name} - Salud: {Equipo[i].Health}/{Equipo[i].InicialHealth}");
            }

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > Equipo.Count)
            {
                Console.WriteLine("Opción no válida. Selecciona un número de la lista.");
            }

            SelectedPokemon = Equipo[opcion - 1];
            Console.WriteLine($"{SelectedPokemon.Name} ahora es tu Pokémon titular.");
        }


        /// <summary>
        /// Selecciona un Pokémon del cementerio para revivir.
        /// </summary>
        public IPokemon SeleccionarPokemonParaRevivir()
        {
            if (Cementerio.Count == 0)
            {
                Console.WriteLine("No hay Pokémon debilitados para revivir.");
                return null;
            }

            Console.WriteLine("Selecciona un Pokémon para revivir:");
            for (int i = 0; i < Cementerio.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Cementerio[i].Name} - Salud: {Cementerio[i].Health}");
            }

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > Cementerio.Count)
            {
                Console.WriteLine("Opción no válida. Selecciona un número de la lista.");
            }

            return Cementerio[opcion - 1];
        }




        /// <summary>
        /// Selecciona un Pokémon vivo del equipo para usar un ítem en él.
        /// </summary>
        public IPokemon SeleccionarPokemonDelEquipo()
        {
            if (Equipo.Count == 0)
            {
                Console.WriteLine("No hay Pokémon en el equipo para seleccionar.");
                return null;
            }

            Console.WriteLine("Selecciona un Pokémon del equipo:");
            for (int i = 0; i < Equipo.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Equipo[i].Name} - Salud: {Equipo[i].Health}/{Equipo[i].InicialHealth}");
            }

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > Equipo.Count)
            {
                Console.WriteLine("Opción no válida. Selecciona un número de la lista.");
            }

            return Equipo[opcion - 1];
        }
    }
}
