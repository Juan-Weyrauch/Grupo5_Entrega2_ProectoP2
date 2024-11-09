namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    public List<IItem> Inventario { get; }
    public List<IPokemon> Equipo { get; }
    public IPokemon SelectedPokemon { get; }
    public int getInventarioCount();
}