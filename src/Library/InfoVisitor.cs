namespace ClassLibrary;

public class InfoVisitor : IVisitor
{
    // Crear un Pokémon a partir del registro
    public IPokemon VisitCrearPoke(Registro registro)
    {
        return registro.CrearPokemon();
    }

    // Obtener solo el nombre del registro
    public string VisitObtenerNombre(Registro registro)
    {
        return registro.Name;
    }
    public void Visit(IPokemon pokemon){}
}
