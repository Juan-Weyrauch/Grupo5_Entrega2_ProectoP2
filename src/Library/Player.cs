namespace ClassLibrary;

public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get; private set; }
    public IPokemon SelectedPokemon {get; set;}
    public List<IItem> Inventario { get; private set; }
    public List<IPokemon> Cementerio { get; private set; }

    public Player(string name, List<IPokemon> equipo, int EleccionEquipo)
    {
        Name = name;
        Equipo = equipo;
        SelectedPokemon = Equipo[EleccionEquipo]; // Esto permite elegir a el pokemon de una manera que tenga sentido.
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
  public  void UsarItem(int indiceItem, IPokemon objetivo)
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
            Console.WriteLine("Ítem no válido.");
        }
        
    }

    public int GetInventarioCount() // Esto tendria que ser un visitor...
    {
        return Inventario.Count();
    }

    public void EliminarPokemon(IPokemon objetivo)
    {
        if (objetivo == null || Equipo == null || Cementerio == null)
            return; // Evitar la excepción si alguno es nulo

        if (Equipo.Contains(objetivo))
        {
            Equipo.Remove(objetivo);
            Cementerio.Add(objetivo); // Agregar al Cementerio
        }
    }

}