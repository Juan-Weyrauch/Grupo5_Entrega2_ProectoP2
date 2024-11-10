namespace ClassLibrary;

public interface IVisitor
{
    IPokemon visitCrearPokemon(IRegistroPokemon registroPokemon);
    string visitNombreRegistro(IRegistroPokemon registroPokemon);

    public IList<IAtaque> DevolverAtaques(IPlayer Jugador);
    // void Visit(IPokemon pokemon);
    // void Visit(Player jugador);
}
