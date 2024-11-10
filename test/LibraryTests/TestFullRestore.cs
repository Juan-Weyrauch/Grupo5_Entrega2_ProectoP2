using NUnit.Framework;
using Moq;
using ClassLibrary;

namespace ClassLibraryTests
{
    [TestFixture]
    public class FullRestoreTests
    {
        [Test]
        public void Usar_ShouldRemoveStatusEffects_WhenPokemonHealthIsGreaterThanZero()
        {
            // Arrange
            var pokemonMock = new Mock<IPokemon>();
            pokemonMock.Setup(p => p.Health).Returns(100); // Simula que el Pokémon tiene salud
            var fullRestore = new FullRestore();

            // Act
            fullRestore.Usar(pokemonMock.Object);

            // Assert
            pokemonMock.Verify(p => p.EliminarEfectosDeEstado(), Times.Once, "EliminarEfectosDeEstado no fue llamado cuando la salud es mayor que cero.");
        }

        [Test]
        public void Usar_ShouldNotRemoveStatusEffects_WhenPokemonIsFainted()
        {
            // Arrange
            var pokemonMock = new Mock<IPokemon>();
            pokemonMock.Setup(p => p.Health).Returns(0); // Simula que el Pokémon está debilitado
            var fullRestore = new FullRestore();

            // Act
            fullRestore.Usar(pokemonMock.Object);

            // Assert
            pokemonMock.Verify(p => p.EliminarEfectosDeEstado(), Times.Never, "EliminarEfectosDeEstado fue llamado aunque el Pokémon está debilitado.");
        }
    }
}