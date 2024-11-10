namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    public List<IItem> Inventario { get; }
    public List<IPokemon> Equipo { get; }
    public IPokemon SelectedPokemon { get; set; }
    public List<IPokemon> Cementerio { get; }
    public int GetInventarioCount();
    public void UsarItem(int indiceItem, IPokemon objetivo);
    public void EliminarPokemon(IPokemon objetivo);




}