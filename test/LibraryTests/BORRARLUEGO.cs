using NUnit.Framework;
using ClassLibrary;
namespace Tests;

[TestFixture]
public class TestPokemonsCreacionAtaques
{
    [Test] // Aquí es donde debe ir el atributo [Test], en un método
    public void StartTrainTest()
    {

        TablaDeTipos.CrearTabla();
        FabricaAtaque.Ejecutar();

        List<int> elementos = [1, 2, 3, 4, 5, 6];
        FabricaPokemon.CargarPokemons();
        List<IPokemon> Pokemons = FabricaPokemon.InstanciarPokes(elementos); // Asegúrate de pasar un arreglo
        Player EjemploJugador = new Player("Pedro", Pokemons, 1);

        Assert.That(EjemploJugador.Equipo[0].Name.Equals("Bulbasur")); // se debe cambiar por un visitor. 
    }
}