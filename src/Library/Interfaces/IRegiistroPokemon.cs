namespace ClassLibrary;

public interface IRegistroPokemon
{
    string Name { get; set; }
    int Damage { get; set; }
    int Health { get; set; }
    ITipoPokemon TipoPokemon { get; set; }
    // dic<ataques> moveset { get; set; }
    public IPokemon CrearPokemon();
}