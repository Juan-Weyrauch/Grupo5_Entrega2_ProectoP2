namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int damage { get; set; }
    int defense { get; set; }
    ITipoPokemon TipoPokemon { get; }
    
    void Accept(IVisitor visitor);
}