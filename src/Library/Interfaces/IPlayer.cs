namespace ClassLibrary;

public interface IPlayer
{
    public string Name { get; }
    // inventario quizas? Aca? 
    public IPokemon SelectedPokemon {get;} 
    public List <IPokemon> Equipo { get;   }
}