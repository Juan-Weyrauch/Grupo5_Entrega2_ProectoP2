namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int damage { get;  }
    int defense { get;  }
    ITipoPokemon TipoPokemon { get; }
    
    void Accept(IVisitor visitor);
}