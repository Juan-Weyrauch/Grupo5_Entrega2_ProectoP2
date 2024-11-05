namespace ClassLibrary;

public interface IVisitor
{
    IPokemon Visit(IRegistroPokemon registroPokemon);
    string VisitNombreRegistro(IRegistroPokemon registroPokemon);
    void Visit(IPokemon pokemon);
    void Visit(Player jugador);
}
