namespace ClassLibrary
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public List<IPokemon> Equipo { get; private set; }
        public IPokemon SelectedPokemon { get; set; }
        public List<IItem> Inventario { get; private set; }
        public List<IPokemon> Cementerio { get; private set; }

        public Player(string name, List<IPokemon> equipo, int EleccionEquipo)
        {
            Name = name;
            Equipo = equipo;
            SelectedPokemon = Equipo[EleccionEquipo]; 
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

        public void UsarItem(int indiceItem, IPokemon objetivo)
        {
            if (indiceItem >= 0 && indiceItem < Inventario.Count)
            {
                IItem item = Inventario[indiceItem];

                if (item is SuperPotion || item is FullRestore)
                {
                    // El jugador puede elegir un Pokémon vivo
                    if (objetivo == null || objetivo.IsDead) 
                        objetivo = SeleccionarPokemon(Equipo.Where(p => p.Health > 0).ToList());
                }
                else if (item is Revive)
                {
                    // El jugador selecciona un Pokémon del cementerio
                    if (objetivo == null || !Cementerio.Contains(objetivo))
                        objetivo = SeleccionarPokemon(Cementerio);

                    if (objetivo != null && Cementerio.Contains(objetivo))
                    {
                        item.Usar(objetivo);  
                        Cementerio.Remove(objetivo);  
                        Equipo.Add(objetivo);  
                        Console.WriteLine($"{objetivo.Name} ha sido revivido y ahora tiene {objetivo.Health}/{objetivo.InicialHealth} HP.");
                    }
                    else
                    {
                        Console.WriteLine("No hay Pokémon muertos en el cementerio o selección inválida.");
                        return; 
                    }
                }

                // Si el objetivo no es nulo, usamos el ítem
                if (objetivo != null)
                {
                    item.Usar(objetivo);
                    Inventario.RemoveAt(indiceItem); 
                }
                else
                {
                    Console.WriteLine("Selección de Pokémon no válida.");
                }
            }
            else
            {
                Console.WriteLine("Ítem no válido.");
            }
        }

        private IPokemon SeleccionarPokemon(List<IPokemon> listaPokemons)
        {
            if (listaPokemons.Count == 0)
            {
                Console.WriteLine("No hay Pokémon disponibles.");
                return null;
            }

            // Mostrar la lista de Pokémon disponibles para elegir
            Console.WriteLine("Selecciona un Pokémon:");
            for (int i = 0; i < listaPokemons.Count; i++)
            {
                var pokemon = listaPokemons[i];
                Console.WriteLine($"{i + 1}) {pokemon.Name} {pokemon.Health}/{pokemon.InicialHealth} HP");
            }

            // Esperar la entrada del usuario
            int eleccion = int.Parse(Console.ReadLine()) - 1;

            if (eleccion >= 0 && eleccion < listaPokemons.Count)
            {
                return listaPokemons[eleccion];
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                return null;
            }
        }

        public void EliminarPokemon(IPokemon objetivo)
        {
            if (objetivo == null || Equipo == null || Cementerio == null)
                return;

            if (Equipo.Contains(objetivo))
            {
                Equipo.Remove(objetivo);
                Cementerio.Add(objetivo); // Agregar al Cementerio

                if (SelectedPokemon == objetivo && Equipo.Count > 0)
                {
                    SelectedPokemon = SeleccionarPokemon(Equipo);
                    Console.WriteLine($"{Name} ha seleccionado un nuevo Pokémon: {SelectedPokemon.Name}");
                }
            }
        }

        public int GetInventarioCount() 
        {
            return Inventario.Count();
        }
    }
}
