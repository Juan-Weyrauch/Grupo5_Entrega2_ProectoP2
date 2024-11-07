namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int Damage { get;  }
    int Defense { get;  }
    
    string Tipo { get; }
    
   // void Accept(IVisitor visitor);
}