namespace ClassLibrary
{
    public interface IPokemon
    {
        string Name { get; }
        int Damage { get; }
        int Defense { get; }
        int Health { get; }
        Estado EstadoActual { get; set; }  // Cambio a Estado en lugar de int
        int TurnosDormido { get; set; }  // Cuenta de los turnos dormido
        string Tipo { get; }
        int ContadorEspecial { get; set; }
        int InicialHealth { get; }
        List<IAtaque> Ataques { get; }
        void DecrementarContadorEspecial();
        bool PuedeAtacar();
        bool IsDead { get; }

        void DecreaseHealth(int valueAfterCalculation);
        void Curar(int cantidad);
        void EliminarEfectosDeEstado();
        void CambiarEstado(int estado);  // Uso del enum Estado
        void AplicarEfectos();
    }
}