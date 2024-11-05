namespace ClassLibrary;

public interface ITipoPokemon
{
    string Name { get; }
    int Damage { get;  }
    int Defense { get;  }
    ITipoPokemon Type { get; }
}