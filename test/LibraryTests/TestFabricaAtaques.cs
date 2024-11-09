using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class FabricaAtaqueTests
{
    [SetUp]
    public void Setup()
    {
        FabricaAtaque.Executar();  // Ejecuta la inicialización del diccionario antes de cada prueba.
    }

    [Test]
    public void GenerarAtaquesRandom1()
    {
        // Prueba el método con un tipo específico.
        string tipoEspecifico = "Planta";
        List<IAtaque> ataquesGenerados = FabricaAtaque.GenerarAtaquesRandom(tipoEspecifico);

        // Validación de la cantidad de ataques
        if (ataquesGenerados.Count != 4)
        {
            Assert.Fail("La cantidad de ataques generados no es igual a 4.");
        }

        // Validación de los tres primeros ataques del tipo especificado
        if (ataquesGenerados.Take(3).Any(ataque => ataque.Tipo != tipoEspecifico))
        {
            Assert.Fail("Los tres primeros ataques generados no son todos del tipo especificado.");
        }

        // Verificación de que el cuarto ataque puede ser de cualquier tipo
        if (!ataquesGenerados.Skip(3).FirstOrDefault()!.Tipo.Contains(tipoEspecifico))
        {
            Assert.Pass("El cuarto ataque es de cualquier tipo, como se esperaba.");
        }
    }
}