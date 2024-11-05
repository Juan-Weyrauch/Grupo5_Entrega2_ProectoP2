namespace ClassLibrary;

public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get;  set; }
    public void Elegir(List<int> eleccionplayer)
    {
        // Visitor a FabricaPokemon
    }

    public void EstablecerEquipo(List<IPokemon> EquipoNuevo)
    {
        Equipo = EquipoNuevo;
    }
}