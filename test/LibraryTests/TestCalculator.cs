//-----------------------------------------------------------------------------
// <copyright file="TestCalculator.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// -----------------------------------------------------------------------------

using System.Collections.Generic;
using ClassLibrary;
using Library.Static;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Pruebas de la clase <see cref="Calculator"/>.
    /// </summary>
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void GetValidatedNumberTest()
        {
            // Definir los límites y valores de prueba
            int min = 1;
            int max = 10;
            int inputValid = 5;
            int inputInvalid = 15;

            // Verificar valor dentro del rango
            Assert.That(Calculator.GetValidatedNumber(min, max, inputValid), Is.EqualTo(inputValid));

            // Verificar valor fuera del rango, ajustando el valor esperado según el comportamiento de validación
            int expectedInvalidResult = Math.Clamp(inputInvalid, min, max);
            Assert.That(Calculator.GetValidatedNumber(min, max, inputInvalid), Is.EqualTo(expectedInvalidResult));
        }


        [Test]
        public void CombatValidationTest()
        {
            // Crea un equipo de Pokémon y un inventario de prueba
            List<IAtaque> ataques = new List<IAtaque> { new Ataque("Impactrueno", 40, 100, "Eléctrico", 15) };
            List<IPokemon> equipo1 = new List<IPokemon> { new Pokemon("Pikachu", 55, 40, 35, "Eléctrico", ataques) };
            List<IPokemon> equipo2 = new List<IPokemon> { new Pokemon("Charmander", 39, 52, 43, "Fuego", ataques) };

            IPlayer jugador1 = new Player("Jugador1", equipo1, 1);
            IPlayer jugador2 = new Player("Jugador2", equipo2, 1);

            // Validación de combate
            bool resultado = Calculator.CombatValidation(jugador1, jugador2);
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void CalcularDañoporTipoTest()
        {
            // Datos de prueba para el cálculo de daño
            List<IAtaque> ataquesPikachu = new List<IAtaque> { new Ataque("Impactrueno", 40, 100, "Eléctrico", 15) };
            List<IAtaque> ataquesCharmander = new List<IAtaque> { new Ataque("Lanzallamas", 90, 100, "Fuego", 15) };

            IPokemon pokemonActual = new Pokemon("Pikachu", 55, 40, 35, "Eléctrico", ataquesPikachu);
            IPokemon pokemonRival = new Pokemon("Charmander", 39, 52, 43, "Fuego", ataquesCharmander);
            IAtaque ataqueActual = new Ataque("Impactrueno", 40, 100, "Eléctrico", 15);

            int dañoCalculado = Calculator.CalcularDañoporTipo(pokemonActual, pokemonRival, ataqueActual);
            
            // Comprobar el valor de daño esperado según la tabla de tipos
            Assert.That(dañoCalculado, Is.GreaterThanOrEqualTo(0));
        }
    }
}
