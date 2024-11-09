using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;
namespace ClassLibrary.Tests
{
    [TestFixture]
    public class TestCombate
    {
        [Test]
        public void TestCombatir()
        {
            // Crear Pokémon para el jugador 1 y 2
            var pokemonJugador1 = new Pokemon { Name = "Bulbasaur", Health = 100, InicialHealth = 100, Damage = 40, Defense = 20, Tipo = Tipo.Planta };
            var pokemonJugador2 = new Pokemon { Name = "Charmander", Health = 100, InicialHealth = 100, Damage = 50, Defense = 15, Tipo = Tipo.Fuego };

            // Crear jugadores
            var jugador1 = new Player
            {
                Name = "Jugador 1",
                Equipo = new List<IPokemon> { pokemonJugador1 },
                Inventario = new List<IItem>(), // Sin items para simplificar
                SelectedPokemon = pokemonJugador1
            };

            var jugador2 = new Player
            {
                Name = "Jugador 2",
                Equipo = new List<IPokemon> { pokemonJugador2 },
                Inventario = new List<IItem>(),
                SelectedPokemon = pokemonJugador2
            };

            // Guardar la salud inicial de ambos Pokémon antes de iniciar el combate
            int saludInicialJugador1 = pokemonJugador1.Health;
            int saludInicialJugador2 = pokemonJugador2.Health;

            // Llamar al método Combatir
            Combate.Combatir(jugador1, jugador2);

            // Verificar que al menos uno de los Pokémon ha recibido daño
            Assert.That(pokemonJugador1.Health, Is.Not.EqualTo(saludInicialJugador1), "El Pokémon del jugador 1 no ha recibido daño.");
            Assert.That(pokemonJugador2.Health, Is.Not.EqualTo(saludInicialJugador2), "El Pokémon del jugador 2 no ha recibido daño.");

            // También podemos verificar que no se han quedado con salud 0
            Assert.That(pokemonJugador1.Health, Is.GreaterThan(0), "El Pokémon del jugador 1 debería tener salud mayor que 0.");
            Assert.That(pokemonJugador2.Health, Is.GreaterThan(0), "El Pokémon del jugador 2 debería tener salud mayor que 0.");
        }
    }
}
