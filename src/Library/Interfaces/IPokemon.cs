namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int Damage { get;  }
    int Defense { get;  }
    ITipoPokemon TipoPokemon { get; }
    
   // void Accept(IVisitor visitor);
}