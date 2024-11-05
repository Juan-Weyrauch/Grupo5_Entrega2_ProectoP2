namespace ClassLibrary;

public interface IVisitor
{
    // Obtener nombre del Pokémon
    string VisitObtenerNombre(Registro registro);

    // Crear un Pokémon
    IPokemon VisitCrearPoke(Registro registro);
    public void Visit(IPokemon pokemon);

}