// TestPokemon.cs
using System;
using System.Collections.Generic;
using ClassLibrary;

public class TestPokemonss : IPokemon
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
    public void GetInventarioCount_ShouldReturnCorrectItemCount(){ }
}
