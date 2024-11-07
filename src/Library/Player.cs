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
}