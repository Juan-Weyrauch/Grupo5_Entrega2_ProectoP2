using System.Collections;
using System;
using System.Collections.Generic;
namespace ClassLibrary;

public class TipoPokemon: ITipoPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set;  }
    public int Defense { get; private set;   }
    public ITipoPokemon Type { get; private set; }

    //Yo pienso que aca deberia ir lo que puse yo y tal vez crear un int ITipoAtaque para agregar
    //el daño a los ataques
    public List<string> Strengths { get; set; }       // Tipos a los que es fuerte
    public List<string> Weaknesses { get; set; }      // Tipos a los que es débil
    public List<string> Immunities { get; set; }      // Tipos a los que es inmune
    public TipoPokemon(string name, int damage, int defense, ITipoPokemon type)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Type = type;
        public TipoPokemon(string name)     //esto esta mal pero no se que cambiar para no arruinar el resto
        {
            Name = name;
            Strengths = new List<string>();
            Weaknesses = new List<string>();
            Immunities = new List<string>();
        }
    }


    /*
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
    }*/
}