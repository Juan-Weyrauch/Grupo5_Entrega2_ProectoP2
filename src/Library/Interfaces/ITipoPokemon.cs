namespace ClassLibrary;

public interface ITipoPokemon
{
    string Name { get; }

    public void EstablecerRelacionesElementales(List<ITipoPokemon> Fortalezas, List<ITipoPokemon> Debilidades,
        List<ITipoPokemon> Immnunidades);
}