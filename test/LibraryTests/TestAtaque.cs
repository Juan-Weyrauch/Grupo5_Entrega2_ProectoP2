using NUnit.Framework;
using ClassLibrary;

public class TestAtaque
{
     [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string name = "Lanzallamas";
            int poder = 90;
            int precision = 100;
            string tipo = "Fuego";
            int especial = 1;

            // Act
            var ataque = new Ataque(name, poder, precision, tipo, especial);

            // Assert
            Assert.AreEqual(name, ataque.Name, "El nombre del ataque no se ha inicializado correctamente.");
            Assert.AreEqual(poder, ataque.Poder, "El poder del ataque no se ha inicializado correctamente.");
            Assert.AreEqual(precision, ataque.Precision, "La precisión del ataque no se ha inicializado correctamente.");
            Assert.AreEqual(tipo, ataque.Tipo, "El tipo del ataque no se ha inicializado correctamente.");
            Assert.AreEqual(especial, ataque.Especial, "La propiedad especial del ataque no se ha inicializado correctamente.");
        }

        [Test]
        public void Constructor_WithInvalidPrecision_ShouldInitializeCorrectly()
        {
            // Arrange
            string name = "Rayo";
            int poder = 80;
            int precision = -10;  // valor atípico para verificar si se acepta o se valida de alguna manera
            string tipo = "Eléctrico";
            int especial = 0;

            // Act
            var ataque = new Ataque(name, poder, precision, tipo, especial);

            // Assert
            Assert.AreEqual(precision, ataque.Precision, "La precisión no coincide con el valor proporcionado.");
        }

        [Test]
        public void Constructor_WithEdgeCaseValues_ShouldInitializeCorrectly()
        {
            // Arrange
            string name = "Mega Impacto";
            int poder = int.MaxValue;
            int precision = int.MaxValue;
            string tipo = "Normal";
            int especial = int.MaxValue;

            // Act
            var ataque = new Ataque(name, poder, precision, tipo, especial);

            // Assert
            Assert.AreEqual(name, ataque.Name);
            Assert.AreEqual(poder, ataque.Poder);
            Assert.AreEqual(precision, ataque.Precision);
            Assert.AreEqual(tipo, ataque.Tipo);
            Assert.AreEqual(especial, ataque.Especial);
        }
    }
}