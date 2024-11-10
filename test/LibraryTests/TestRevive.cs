using System;
using System.Collections.Generic;
using ClassLibrary;

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

    public void Curar(int cantidad)
    {
        Health = Math.Min(Health + cantidad, InicialHealth);
    }

    public void EliminarEfectosDeEstado() { }
}

public class ReviveTests
{
    public static void RunTests()
    {
        Usar_ShouldRevivePokemon_WhenHealthIsZero();
        Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero();
    }

    public static void Usar_ShouldRevivePokemon_WhenHealthIsZero()
    {
        // Arrange
        var pokemon = new TestPokemon
        {
            Name = "Charizard",
            Health = 0,  // El Pokémon está debilitado
            InicialHealth = 100
        };
        var revive = new Revive();

        // Act
        revive.Usar(pokemon);

        // Assert
        Console.WriteLine(pokemon.Health == 50 
            ? "Test Passed: Usar_ShouldRevivePokemon_WhenHealthIsZero" 
            : "Test Failed: Usar_ShouldRevivePokemon_WhenHealthIsZero");
    }

    public static void Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero()
    {
        // Arrange
        var pokemon = new TestPokemon
        {
            Name = "Pikachu",
            Health = 30,  // El Pokémon no está debilitado
            InicialHealth = 100
        };
        var revive = new Revive();

        // Act
        revive.Usar(pokemon);

        // Assert
        Console.WriteLine(pokemon.Health == 30 
            ? "Test Passed: Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero" 
            : "Test Failed: Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero");
    }
}
