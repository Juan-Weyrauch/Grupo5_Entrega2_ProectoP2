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
            Player EjemploJugador = new Player();
            FabricaPokemon.CargarPokemons();
            FabricaPokemon.InstanciarPokes( [1], EjemploJugador); // Asegúrate de pasar un arreglo
            Assert.That(EjemploJugador.Equipo[0].Name.Equals("Bulbasur")); // se debe cambiar por un visitor. 
        }
    }
}
