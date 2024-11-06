using System.Collections;
using System;
using System.Collections.Generic;
namespace ClassLibrary;

public class TipoPokemon: ITipoPokemon
{
    public string Name { get; private set; }
    
   

    //Yo pienso que aca deberia ir lo que puse yo y tal vez crear un int ITipoAtaque para agregar
    //el daño a los ataques
    public List<ITipoPokemon> Strengths { get; set; }       // Tipos a los que es fuerte
    public List<ITipoPokemon> Weaknesses { get; set; }      // Tipos a los que es débil
    public List<ITipoPokemon> Immunities { get; set; }      // Tipos a los que es inmune
    

    public TipoPokemon(string name)     //esto esta mal pero no se que cambiar para no arruinar el resto
        {
            Name = name;
        }

    public void EstablecerRelacionesElementales(List<ITipoPokemon> Fortalezas, List<ITipoPokemon> Deblidades, List<ITipoPokemon> Immnunidades)
    {
        Strengths = Fortalezas;
        Weaknesses = Deblidades;
        Immunities = Immnunidades;
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