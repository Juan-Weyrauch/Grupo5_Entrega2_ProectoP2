namespace ClassLibrary;

public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get; private set; }

    public Player(string name, List<IPokemon> equipo)
    {
        Name = name;
        Equipo = equipo;
    } 
    public void EstablecerEquipo(List<IPokemon> EquipoNuevo) // creo que esto deberia ser de la fabrica
    {
        Equipo = EquipoNuevo;
    }
}