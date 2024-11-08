namespace ClassLibrary;

public class InfoVisitor : IVisitor
{
    public IPokemon
        Visit(IRegistroPokemon registroPokemon) // No estoy seguro que un vistor este bien que tenga un return.
    {
        return registroPokemon.CrearPokemon();
    }

    public string
        VisitNombreRegistro(
            IRegistroPokemon registroPokemon) // No estoy seguro que un vistor este bien que tenga un return.
    {
        return registroPokemon.Name;
    }

    // esta sin crear.
}