namespace ClassLibrary;

public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get;  set; }
    
    // Agrega el inventario de ítems
    public List<IItem> Inventario { get; private set; }
    
    public Player(string name)
    {
        Name = name;
        Equipo = new List<IPokemon>();
            
        // Inicializar el inventario con los ítems requeridos
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
    public void Elegir(List<int> eleccionplayer)
    {
        // Visitor a FabricaPokemon
    }

    public void EstablecerEquipo(List<IPokemon> EquipoNuevo)
    {
        Equipo = EquipoNuevo;
    }
    public class Player : IPlayer
    {
        public string Name { get; }
        public List<IPokemon> Equipo { get; set; }
        public List<IItem> Inventario { get; private set; }

        public Player(string name)
        {
            Name = name;
            Equipo = new List<IPokemon>();
            Inventario = new List<IItem>
            {
                new SuperPotion(),
                new Revive(),
                new FullRestore()
            };
        }

        public void UsarItem(int indiceItem, IPokemon objetivo)
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
    }

}