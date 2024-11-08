namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int Damage { get;  }
    int Defense { get;  }
    int Estado { get; } // 0  es normal, 1 quemado, 2 envenanado, 3 paralizar, 4 Dormido  
    string Tipo { get; }
    
   // void Accept(IVisitor visitor);
}