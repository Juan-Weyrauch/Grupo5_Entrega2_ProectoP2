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
    public void Curar(int cantidad) { Health = Math.Min(Health + cantidad, InicialHealth); }
    public void EliminarEfectosDeEstado() { }
}

public class TestItem : IItem
{
    public string Nombre => "TestItem";
    public bool Usado { get; private set; } = false;

    public void Usar(IPokemon pokemon)
    {
        Usado = true;
    }
}

public class PlayerTests
{
    public static void RunTests()
    {
        Constructor_ShouldInitializePropertiesCorrectly();
        UsarItem_ShouldUseItemOnPokemonAndRemoveFromInventory();
        UsarItem_ShouldNotUseItem_WhenIndexIsInvalid();
        GetInventarioCount_ShouldReturnCorrectItemCount();
    }

    public static void Constructor_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var name = "Ash";
        var equipo = new List<IPokemon> { new TestPokemon(), new TestPokemon() };
        int eleccionEquipo = 1;

        // Act
        var player = new Player(name, equipo, eleccionEquipo);

        // Assert
        bool passed = player.Name == name &&
                      player.Equipo == equipo &&
                      player.SelectedPokemon == player.Equipo[eleccionEquipo - 1] &&
                      player.Inventario.Count == 7;

        Console.WriteLine(passed
            ? "Test Passed: Constructor_ShouldInitializePropertiesCorrectly"
            : "Test Failed: Constructor_ShouldInitializePropertiesCorrectly");
    }

    public static void UsarItem_ShouldUseItemOnPokemonAndRemoveFromInventory()
    {
        // Arrange
        var pokemon = new TestPokemon { Health = 50, InicialHealth = 100 };
        var item = new TestItem();
        
        var player = new Player("Ash", new List<IPokemon> { pokemon }, 1);
        player.Inventario = new List<IItem> { item };

        // Act
        player.UsarItem(0, pokemon);

        // Assert
        bool passed = item.Usado && player.Inventario.Count == 0;

        Console.WriteLine(passed
            ? "Test Passed: UsarItem_ShouldUseItemOnPokemonAndRemoveFromInventory"
            : "Test Failed: UsarItem_ShouldUseItemOnPokemonAndRemoveFromInventory");
    }

    public static void UsarItem_ShouldNotUseItem_WhenIndexIsInvalid()
    {
        // Arrange
        var pokemon = new TestPokemon();
        var player = new Player("Ash", new List<IPokemon> { pokemon }, 1);

        // Act
        bool noExceptionThrown = true;
        try
        {
            player.UsarItem(-1, pokemon);
            player.UsarItem(player.Inventario.Count, pokemon);
        }
        catch
        {
            noExceptionThrown = false;
        }

        // Assert
        bool passed = noExceptionThrown && player.Inventario.Count == 7;

        Console.WriteLine(passed
            ? "Test Passed: UsarItem_ShouldNotUseItem_WhenIndexIsInvalid"
            : "Test Failed: UsarItem_ShouldNotUseItem_WhenIndexIsInvalid");
    }

    public static void GetInventarioCount_ShouldReturnCorrectItemCount()
    {
        // Arrange
        var player = new Player("Ash", new List<IPokemon> { new TestPokemon() }, 1);

        // Act
        int itemCount = player.GetInventarioCount();

        // Assert
        bool passed = itemCount == 7;

        Console.WriteLine(passed
            ? "Test Passed: GetInventarioCount_ShouldReturnCorrectItemCount"
            : "Test Failed: GetInventarioCount_ShouldReturnCorrectItemCount");
    }
}
