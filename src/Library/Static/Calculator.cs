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

    public static double Efectividad(string tipoAtaque, string tipoPokemon)
    {
        {
            // Obtener las relaciones del tipo de Pokémon atacado
            var relaciones = TablaDeTipos.ObtenerRelaciones(tipoPokemon);

            // Determinar el multiplicador de efectividad
            if (relaciones.inmunidades.Contains(tipoAtaque))
            {
                return 0.0; // Inmune
            }
            else if (relaciones.fortalezas.Contains(tipoAtaque))
            {
                return 0.5; // Débil
            }
            else if (relaciones.debilidades.Contains(tipoAtaque))
            {
                return 2.0; // Efectivo
            }
            else
            {
                return 1.0; // Neutro
            }
        }
    }

    public static double CalcularDaño(Ataque poderAtaque, IPokemon defensaPokemon,IPokemon ataquePokemon, string tipoAtaque, string tipoPokemon)
    {
        var relaciones = TablaDeTipos.ObtenerRelaciones(tipoPokemon);
        
        var parte1 = (0.01 * Calculator.Efectividad(tipoAtaque, tipoPokemon));
        var parte2 = (0.2 * poderAtaque.Poder * ataquePokemon.Damage);
        var parte25 = ((parte2/(25 * defensaPokemon.Defense)+2));
        var parteFinal = (parte25*parte1);
        return parteFinal;
    }
}