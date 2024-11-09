using System.Diagnostics.CodeAnalysis;
using Library;

namespace ClassLibrary;
using ClassLibrary;

public static class Calculator
{
    public static int GetValidatedNumber(int min, int max, int PokemonValue){
        //aca se lee el input del usuario 
        while (PokemonValue > max || PokemonValue < min)
        {
            ImpresoraDeTexto.ValorFueraDeRango();
            PokemonValue = Convert.ToInt16(Console.ReadLine());

        }

        return PokemonValue;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="jugador1"></param>
    /// <param name="jugador2"></param>
    /// <returns>boolean</returns>
    public static bool CombatValidation([NotNull] IPlayer jugador1, [NotNull] IPlayer jugador2)
    {
        int inventarioCountEquipo1 = jugador1.getInventarioCount();
        int inventarioCountEquipo2 = jugador2.getInventarioCount();
    
        if ( (inventarioCountEquipo1 > 0 )&&( inventarioCountEquipo2 > 0 ) ){ return true; } 
        else{ return false; }
    }
}