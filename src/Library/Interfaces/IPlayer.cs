namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public List <IPokemon> Equipo { get;  set; }
    List<int> EleccionPokemon { get; set; }
}