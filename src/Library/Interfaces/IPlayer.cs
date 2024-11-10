namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    public List<IItem> Inventario { get; }
    public List<IPokemon> Equipo { get; }
    public IPokemon SelectedPokemon { get; }
    public List<IPokemon> Cementerio { get; }
    public int GetInventarioCount();
   
    public void UsarItem(int indiceItem, IPokemon objetivo);
    public IList<IAtaque> DevolverAtaques();



}