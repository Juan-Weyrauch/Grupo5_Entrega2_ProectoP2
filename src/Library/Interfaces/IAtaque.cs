namespace ClassLibrary;

public interface IAtaque
{
    string Name { get; }
    int Poder { get; }
    int Precision { get; }
    string Tipo { get; } // Cambia a pública
    int Especial { get; }
}