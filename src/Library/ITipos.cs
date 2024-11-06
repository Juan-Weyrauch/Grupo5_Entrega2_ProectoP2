using System.Collections;
using System;
using System.Collections.Generic;

namespace ClassLibrary;

public class ITipos
{
    string Name;
    public bool Efectivo;
    public string Tipo;
}
public class PokemonType
{
    public string Name { get; set; }
    public List<string> Strengths { get; set; }       // Tipos a los que es fuerte
    public List<string> Weaknesses { get; set; }      // Tipos a los que es débil
    public List<string> Immunities { get; set; }      // Tipos a los que es inmune

    public PokemonType(string name)
    {
        Name = name;
        Strengths = new List<string>();
        Weaknesses = new List<string>();
        Immunities = new List<string>();
    }
}
