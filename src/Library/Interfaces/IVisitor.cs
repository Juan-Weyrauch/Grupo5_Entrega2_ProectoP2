namespace ClassLibrary;

public interface IVisitor
{
    IPokemon visitCrearPokemon(IRegistroPokemon registroPokemon);
    string visitNombreRegistro(IRegistroPokemon registroPokemon);
    
   // void Visit(IPokemon pokemon);
   // void Visit(Player jugador);
}
