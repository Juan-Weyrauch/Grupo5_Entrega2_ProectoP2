namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get;   }
    List<int> EleccionPokemon { get; }
    public void EstablecerEquipo(List<IPokemon> EquipoNuevo);
}