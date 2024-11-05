namespace ClassLibrary;

public interface IVisitor
{
    void Visit(IRegistroPokemon registroPokemon);
    void Visit(IPokemon pokemon);
}