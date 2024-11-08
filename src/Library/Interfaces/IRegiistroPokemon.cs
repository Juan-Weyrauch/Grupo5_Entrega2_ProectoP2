namespace ClassLibrary;

public interface  IRegistroPokemon
{
     string Name { get; }
    int Damage { get;  }
    int Health { get;  }
    string  Tipo { get; }
    // dic<ataques> moveset { get; set; }
     public IPokemon CrearPokemon();
     
    public string AcceptObtenerNombre(IVisitor visitor);
    
    public IPokemon AcceptCrearPokemon(IVisitor visitor);
}