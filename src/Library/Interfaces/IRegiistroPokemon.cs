namespace ClassLibrary;

public interface IRegistroPokemon
{
    string Name { get; set; }
    int Damage { get; set; }
    int health { get; set; }
    ITipoPokemon TipoPokemon { get; set; }
    // dic<ataques> moveset { get; set; }
    public string DevolverNombre();
    public int DevolverDamage();
    public int DevolverHealth();
    public ITipoPokemon DevolverTipo();
    // public DevolverMoves();
}