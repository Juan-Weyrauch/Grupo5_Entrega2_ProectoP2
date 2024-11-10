using System;
using System.Collections.Generic;
using ClassLibrary;

public class SuperPotionTests
{
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

    public static void RunTests()
    {
        Usar_ShouldHealPokemon_WhenHealthIsLessThanInicialHealth();
        Usar_ShouldNotHealPokemon_WhenHealthIsAtMax();
        Usar_ShouldNotHealPokemon_WhenHealthIsZero();
    }

    public static void Usar_ShouldHealPokemon_WhenHealthIsLessThanInicialHealth()
    {
        var pokemon = new TestPokemon
        {
            Name = "Bulbasaur",
            Health = 50,
            InicialHealth = 100
        };
        var superPotion = new SuperPotion();

        superPotion.Usar(pokemon);

        Console.WriteLine(pokemon.Health == 100 
            ? "Test Passed: Usar_ShouldHealPokemon_WhenHealthIsLessThanInicialHealth" 
            : "Test Failed: Usar_ShouldHealPokemon_WhenHealthIsLessThanInicialHealth");
    }

    public static void Usar_ShouldNotHealPokemon_WhenHealthIsAtMax()
    {
        var pokemon = new TestPokemon
        {
            Name = "Charmander",
            Health = 100,
            InicialHealth = 100
        };
        var superPotion = new SuperPotion();

        superPotion.Usar(pokemon);

        Console.WriteLine(pokemon.Health == 100 
            ? "Test Passed: Usar_ShouldNotHealPokemon_WhenHealthIsAtMax" 
            : "Test Failed: Usar_ShouldNotHealPokemon_WhenHealthIsAtMax");
    }

    public static void Usar_ShouldNotHealPokemon_WhenHealthIsZero()
    {
        var pokemon = new TestPokemon
        {
            Name = "Squirtle",
            Health = 0,
            InicialHealth = 100
        };
        var superPotion = new SuperPotion();

        superPotion.Usar(pokemon);

        Console.WriteLine(pokemon.Health == 0 
            ? "Test Passed: Usar_ShouldNotHealPokemon_WhenHealthIsZero" 
            : "Test Failed: Usar_ShouldNotHealPokemon_WhenHealthIsZero");
    }
}
