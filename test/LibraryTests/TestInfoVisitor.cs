using System;
using ClassLibrary;
using System.Collections.Generic;

// Implementación de prueba para IPokemon
public class TestPokemon : IPokemon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Estado { get; set; }
    public int InicialHealth { get; set; }
    public List<IAtaque> Ataques { get; set; }
    public string Tipo { get; set; }

    public void DecreaseHealth(int valueAfterCalculation) { }
    public void Curar(int cantidad) { }
    public void EliminarEfectosDeEstado() { }
}

// Implementación de prueba para IRegistroPokemon
public class TestRegistroPokemon : IRegistroPokemon
{
    public string Name { get; set; }
    public IPokemon PokemonToReturn { get; set; }

    public IPokemon CrearPokemon()
    {
        return PokemonToReturn;
    }

    public List<IAtaque> Ataques { get; }
    public int Damage { get; }
    public int Defense { get; }
    public int Health { get; }
    public string Tipo { get; }

    public string AcceptObtenerNombre(IVisitor visitor) => visitor.visitNombreRegistro(this);
    public IPokemon AcceptCrearPokemon(IVisitor visitor) => visitor.visitCrearPokemon(this);
}

public class InfoVisitorTests
{
    public static void RunTests()
    {
        visitCrearPokemon_ShouldReturnCreatedPokemon();
        visitNombreRegistro_ShouldReturnName();
    }

    public static void visitCrearPokemon_ShouldReturnCreatedPokemon()
    {
        // Arrange
        var expectedPokemon = new TestPokemon { Name = "Charizard" };
        var registroPokemon = new TestRegistroPokemon { PokemonToReturn = expectedPokemon };
        var visitor = new InfoVisitor();

        // Act
        var result = visitor.visitCrearPokemon(registroPokemon);

        // Assert
        bool passed = result == expectedPokemon;
        Console.WriteLine(passed
            ? "Test Passed: visitCrearPokemon_ShouldReturnCreatedPokemon"
            : "Test Failed: visitCrearPokemon_ShouldRet
