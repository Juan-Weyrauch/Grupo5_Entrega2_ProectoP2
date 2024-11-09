using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class TablaDeTiposTests
    {
        public TablaDeTiposTests()
        {
            // Aseguramos que la tabla esté cargada antes de comenzar los tests
            TablaDeTipos.CrearTabla();
        }

        [Test]
        public void ObtenerRelaciones_DeberiaRetornarFortalezasCorrectas()
        {
            // Act
            var relacionesAgua = TablaDeTipos.ObtenerRelaciones("Agua");
            var relacionesFuego = TablaDeTipos.ObtenerRelaciones("Fuego");

            // Assert
            Assert.That(relacionesAgua.fortalezas, Does.Contain("Fuego"));
            Assert.That(relacionesAgua.fortalezas, Does.Contain("Tierra"));
            Assert.That(relacionesAgua.fortalezas, Does.Contain("Roca"));

            Assert.That(relacionesFuego.fortalezas, Does.Contain("Planta"));
            Assert.That(relacionesFuego.fortalezas, Does.Contain("Hielo"));
            Assert.That(relacionesFuego.fortalezas, Does.Contain("Bicho"));
        }

        [Test]
        public void ObtenerRelaciones_DeberiaRetornarDebilidadesCorrectas()
        {
            // Act
            var relacionesAgua = TablaDeTipos.ObtenerRelaciones("Agua");
            var relacionesPlanta = TablaDeTipos.ObtenerRelaciones("Planta");

            // Assert
            Assert.That(relacionesAgua.debilidades, Does.Contain("Eléctrico"));
            Assert.That(relacionesAgua.debilidades, Does.Contain("Planta"));

            Assert.That(relacionesPlanta.debilidades, Does.Contain("Fuego"));
            Assert.That(relacionesPlanta.debilidades, Does.Contain("Volador"));
        }

        [Test]
        public void ObtenerRelaciones_DeberiaRetornarInmunidadesCorrectas()
        {
            // Act
            var relacionesFantasma = TablaDeTipos.ObtenerRelaciones("Fantasma");
            var relacionesNormal = TablaDeTipos.ObtenerRelaciones("Normal");

            // Assert
            Assert.That(relacionesFantasma.inmunidades, Does.Contain("Normal"));

            Assert.That(relacionesNormal.inmunidades, Does.Contain("Fantasma"));
        }

        [Test]
        public void ObtenerRelaciones_DeberiaRetornarVacioParaTipoInexistente()
        {
            // Act
            var relacionesInexistente = TablaDeTipos.ObtenerRelaciones("TipoInexistente");

            // Assert
            Assert.That(relacionesInexistente.fortalezas, Is.Empty);
            Assert.That(relacionesInexistente.debilidades, Is.Empty);
            Assert.That(relacionesInexistente.inmunidades, Is.Empty);
        }
    }
}
