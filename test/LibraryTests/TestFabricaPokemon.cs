//-----------------------------------------------------------------------------
// <copyright file="TestFabricaPokemon.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Train"/>.
    /// </summary>
    [TestFixture] // Esto marca la clase como un contenedor de pruebas
    public class TestFabricaPokemon
    {
        [Test] // Aquí es donde debe ir el atributo [Test], en un método
        public void StartTrainTest()
        {
            
            List<int> elementos = [1];
            FabricaPokemon.CargarPokemons();
            List<IPokemon >Pokemons = FabricaPokemon.InstanciarPokes(elementos); // Asegúrate de pasar un arreglo
            Player EjemploJugador = new Player("Pedro", Pokemons,0);
           
            Assert.That(EjemploJugador.Equipo[0].Name.Equals("Bulbasur")); // se debe cambiar por un visitor. 
        }

        [Test]
     public void TestearImprmir(){
            
        TablaDeTipos.CrearTabla();
        var a = TablaDeTipos.ObtenerRelaciones("Planta");
        Console.WriteLine(TablaDeTipos.ObtenerRelaciones("Planta"));
     }
     /*   public void TestearTipos()
       {
           List<int> elementos = [1];
           FabricaPokemon.CargarPokemons();
           List<IPokemon >Pokemons = FabricaPokemon.InstanciarPokes(elementos); // Asegúrate de pasar un arreglo
           Player EjemploJugador = new Player("Pedro", Pokemons);
          // Quiero testear La creacion de tipos pero me resulta muy complicado.

       }*/
    }
     
}
