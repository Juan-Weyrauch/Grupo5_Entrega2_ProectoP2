namespace ClassLibrary;

public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get; private set; }
    public IPokemon SelectedPokemon {get; private set;}
    public List<IItem> Inventario { get; private set; }
    public List<IPokemon> Cementerio { get; private set; }

    public Player(string name, List<IPokemon> equipo, int EleccionEquipo)
    {
        Name = name;
        Equipo = equipo;
        SelectedPokemon = Equipo[EleccionEquipo-1]; // Esto permite elegir a el pokemon de una manera que tenga sentido.
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

            if (item is Revive && objetivo.Health == 0)
            {
                // Usa Revive en un Pokémon debilitado
                item.Usar(objetivo);
                Inventario.RemoveAt(indiceItem);
            }
            else if (item is FullRestore && objetivo.Health > 0 && objetivo.Health < objetivo.InicialHealth)
            {
                // Usa FullRestore en un Pokémon vivo pero no completamente curado
                item.Usar(objetivo);
                Inventario.RemoveAt(indiceItem);
            }
            else if (item is SuperPotion && objetivo.Health > 0 && objetivo.Health < objetivo.InicialHealth)
            {
                // Usa SuperPotion en un Pokémon vivo pero no completamente curado
                item.Usar(objetivo);
                Inventario.RemoveAt(indiceItem);
            }
            else
            {
                // Si las condiciones no se cumplen, muestra un mensaje
                Console.WriteLine("No puedes usar ese ítem en este Pokémon.");
            }
        }
        else
        {
            Console.WriteLine("Índice de ítem no válido.");
        }
    }

    public void ActualizarEquipo()
    {
        foreach (var pokemon in Equipo.ToList()) // Usar ToList() para evitar modificar la lista mientras se itera
        {
            if (pokemon.Health == 0)
            {
                Cementerio.Add(pokemon);
                Equipo.Remove(pokemon);
                Console.WriteLine($"{pokemon.Name} ha sido movido al cementerio.");
            }
        }
    }
    public void SeleccionarProximoPokemon()
    {
        // Busca el primer Pokémon en el equipo que aún esté con vida
        SelectedPokemon = Equipo.FirstOrDefault(pokemon => pokemon.Health > 0);

        if (SelectedPokemon == null)
        {
            Console.WriteLine("Todos los Pokémon han sido debilitados.");
            // Aquí se podría manejar la lógica de derrota
        }
        else
        {
            Console.WriteLine($"Ahora está en combate {SelectedPokemon.Name}.");
        }
    }
    public bool TienePokemonVivos()
    {
        return Equipo.Any(pokemon => pokemon.Health > 0);
    }
    
    public int GetInventarioCount() // Esto tendria que ser un visitor...
    {
        return Inventario.Count();
    }

    
}