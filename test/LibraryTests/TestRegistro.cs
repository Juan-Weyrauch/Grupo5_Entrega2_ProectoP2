using System;
using System.Collections.Generic;
using ClassLibrary;

public class ReviveTests
{
    private class TestPokemon : IPokemon
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

    public static void RunTests()
    {
        Usar_ShouldRevivePokemon_WhenHealthIsZero();
        Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero();
    }

    public static void Usar_ShouldRevivePokemon_WhenHealthIsZero()
    {
        var pokemon = new TestPokemon
        {
            Name = "Charizard",
            Health = 0,
            InicialHealth = 100
        };
        var revive = new Revive();

        revive.Usar(pokemon);

        Console.WriteLine(pokemon.Health == 50 
            ? "Test Passed: Usar_ShouldRevivePokemon_WhenHealthIsZero" 
            : "Test Failed: Usar_ShouldRevivePokemon_WhenHealthIsZero");
    }

    public static void Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero()
    {
        var pokemon = new TestPokemon
        {
            Name = "Pikachu",
            Health = 30,
            InicialHealth = 100
        };
        var revive = new Revive();

        revive.Usar(pokemon);

        Console.WriteLine(pokemon.Health == 30 
            ? "Test Passed: Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero" 
            : "Test Failed: Usar_ShouldNotRevivePokemon_WhenHealthIsGreaterThanZero");
    }
}


