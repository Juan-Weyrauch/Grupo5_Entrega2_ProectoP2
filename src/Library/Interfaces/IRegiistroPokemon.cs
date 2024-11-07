namespace ClassLibrary;

public interface  IRegistroPokemon
{
     string Name { get; }
    int Damage { get;  }
    int Health { get;  }
    public string Tipo { get;   }
     public IPokemon CrearPokemon();

     public string AcceptObtenerNombre(IVisitor visitor);

     // Método Accept para crear un Pokémon
     public IPokemon AcceptCrearPokemon(IVisitor visitor);
}