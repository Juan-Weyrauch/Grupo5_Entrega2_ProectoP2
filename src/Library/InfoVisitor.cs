namespace ClassLibrary;

public class InfoVisitor : IVisitor
{
    public void Visit(IRegistroPokemon registroPokemon)
    {
        //Lo que necesitemos que haga con los resigtros
    }

    public void Visit(IPokemon pokemon)
    {
        //Lo que necesitemos que haga el visitor 
    }
}