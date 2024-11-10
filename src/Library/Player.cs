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
            item.Usar(objetivo);
            Inventario.RemoveAt(indiceItem); // Elimina el ítem después de usarlo
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

    
}