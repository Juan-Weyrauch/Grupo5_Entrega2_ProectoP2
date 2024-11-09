using System.Diagnostics.CodeAnalysis;
using Library;

namespace ClassLibrary;
using ClassLibrary;

public static class Calculator
{
    public static int GetValidatedNumber(int min, int max, int PokemonValue)
    {
        // Asegúrate de que el valor ingresado esté dentro del rango [min, max]
        while (PokemonValue < min || PokemonValue > max)
        {
            // Muestra un mensaje cuando el valor está fuera del rango
            ImpresoraDeTexto.ValorFueraDeRango();
            Console.WriteLine($"Por favor, ingresa un número entre {min} y {max}:");
        
            // Intentar leer la entrada y validar que sea un número entero
            if (int.TryParse(Console.ReadLine(), out int newValue))
            {
                PokemonValue = newValue;  // Si la entrada es válida, lo asignamos
            }
            else
            {
                // Si la entrada no es un número válido, muestra un mensaje de error
                Console.WriteLine("Entrada no válida. Asegúrate de ingresar un número entero.");
            }
        }

        return PokemonValue; // Retorna el valor validado
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="jugador1"></param>
    /// <param name="jugador2"></param>
    /// <returns>boolean</returns>
    public static bool CombatValidation([NotNull] IPlayer jugador1, [NotNull] IPlayer jugador2)
    {
        int inventarioCountEquipo1 = jugador1.GetInventarioCount();
        int inventarioCountEquipo2 = jugador2.GetInventarioCount();
    
        if ( (inventarioCountEquipo1 > 0 )&&( inventarioCountEquipo2 > 0 ) ){ return true; } 
        else{ return false; }
    }
}