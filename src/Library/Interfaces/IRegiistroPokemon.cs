namespace ClassLibrary;

public interface  IRegistroPokemon
{
     string Name { get; }
    int Damage { get;  }
    int Health { get;  }
    string  Tipo { get; }
    public List<IAtaque> Habilidades { get; } // Nueva propiedad para las habilidades
     public IPokemon CrearPokemon();
     
    public string AcceptObtenerNombre(IVisitor visitor);
    
    public IPokemon AcceptCrearPokemon(IVisitor visitor);
}