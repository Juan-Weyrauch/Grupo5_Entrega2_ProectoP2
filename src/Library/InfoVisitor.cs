namespace ClassLibrary;

public class InfoVisitor : IVisitor
{
    public IPokemon
        visitCrearPokemon(IRegistroPokemon registroPokemon) // No estoy seguro que un vistor este bien que tenga un return.
    {
        return registroPokemon.CrearPokemon();
    }

    public string
        visitNombreRegistro(IRegistroPokemon registroPokemon) // No estoy seguro que un vistor este bien que tenga un return.
    {
        return registroPokemon.Name;
    }

   public  IList<IAtaque> DevolverAtaques  (IPlayer Jugador)
   {
       return Jugador.SelectedPokemon.Ataques;
   }

    // esta sin crear.
}