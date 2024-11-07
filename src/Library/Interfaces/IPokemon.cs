namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int Damage { get; }    // Usa mayúsculas para mantener consistencia
    int Defense { get; }
    int Health { get; }
    int InicialHealth { get; }
    ITipoPokemon TipoPokemon { get; }
    
    void Accept(IVisitor visitor);
    void Curar(int cantidad);        // Agrega si necesitas que los ítems usen este método
    void RecibirDanio(int cantidad); // Agrega si necesitas que los ítems usen este método
    void EliminarEfectosDeEstado();  // Agrega si necesitas que los ítems usen este método
}