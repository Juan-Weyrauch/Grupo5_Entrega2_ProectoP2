namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get;  set; }
    public void Elegir(List<int> eleccionplayer);

    public void EstablecerEquipo(List<IPokemon> EquipoNuevo);
}