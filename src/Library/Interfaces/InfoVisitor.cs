namespace ClassLibrary;
z
public class InfoVisitor : IVisitor
{
    // Crear un Pokémon a partir del registro
    public IPokemon VisitCrearPoke(Registro registro)
    {
        return new Pokemon(registro.Name, registro.Damage, registro.Health, registro.Defense);
    }

    // Obtener solo el nombre del registro
    public string VisitObtenerNombre(Registro registro)
    {
        return registro.Name;
    }
    public void Visit(IPokemon pokemon){}
}
