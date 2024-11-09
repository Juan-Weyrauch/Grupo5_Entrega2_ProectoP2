namespace ClassLibrary;

public interface IAtaque
{
    string Name { get; }
    int Poder { get;  }
    int Precision { get;  }
    
    string Tipo { get; }
    bool Especial { get; }
} 