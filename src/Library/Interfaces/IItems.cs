namespace ClassLibrary;

public interface IItem
{
    string Nombre { get; }
    void Usar(IPokemon pokemon);
}