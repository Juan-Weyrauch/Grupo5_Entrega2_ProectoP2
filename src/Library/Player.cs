namespace ClassLibrary;

public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get;  set; }
    public void EstablecerEquipo(List<int> eleccionplayer)
    {
        
    }
}