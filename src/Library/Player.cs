namespace ClassLibrary;
/// <summary>
/// Unicamente se Crea a el Player cuando se tenga todos los datos para crearlo.
/// Es decir luego de haberle preguntado, su nombre, Eleccion de equipo y su pokemon en el campo.
/// </summary>
public class Player : IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get; private set; }
    public IPokemon SelectedPokemon {get; private set;} 

    public Player(string name, List<IPokemon> equipo, int EleccionEquipo)
    {
        Name = name;
        Equipo = equipo;
        SelectedPokemon = Equipo[EleccionEquipo-1]; // Esto permite elegir a el pokemon de una manera que tenga sentido.
    }   
}