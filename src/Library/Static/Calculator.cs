using System.Diagnostics.CodeAnalysis;

namespace Library.Static;
using ClassLibrary;

/// <summary>
/// El objetivo de esta clase es realizar cualquier tipo de cálculo y devolver el valor adecuado.
/// Esto nos sirve para simplificar la lectura del código, ya sea de la clase Combate o Fachada,
/// que son las clases que más se benefician de Calculator.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Valida que el número ingresado esté dentro del rango [min, max] y devuelve el valor adecuado.
    /// </summary>
    /// <param name="min">El valor mínimo permitido.</param>
    /// <param name="max">El valor máximo permitido.</param>
    /// <param name="PokemonValue">El valor actual del Pokémon a validar.</param>
    /// <returns>El valor validado dentro del rango permitido.</returns>
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
    /// Valida que los jugadores aún tengan Pokémon vivos para seguir jugando.
    /// </summary>
    /// <param name="jugador1">El primer jugador.</param>
    /// <param name="jugador2">El segundo jugador.</param>
    /// <returns>Devuelve <c>true</c> si ambos jugadores tienen Pokémon vivos, <c>false</c> si alguno no tiene.</returns>
    public static bool CombatValidation([NotNull] IPlayer jugador1, [NotNull] IPlayer jugador2)
    {
        int inventarioCountEquipo1 = jugador1.GetInventarioCount();
        int inventarioCountEquipo2 = jugador2.GetInventarioCount();
    
        if ((inventarioCountEquipo1 > 0) && (inventarioCountEquipo2 > 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Valida si un jugador tiene al menos un Pokémon disponible para el combate.
    /// </summary>
    /// <param name="jugador">El jugador que se va a validar.</param>
    /// <returns>Devuelve 0 si no tiene Pokémon disponibles, 1 si tiene al menos uno.</returns>
    public static int IndividualcombatValidation(List<IPokemon> jugador)
    {
        if (jugador.Count == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// Calcula el daño total de un ataque en función del tipo de Pokémon y ataque.
    /// </summary>
    /// <param name="pokemonActual">El Pokémon atacante.</param>
    /// <param name="pokemonRival">El Pokémon defensor.</param>
    /// <param name="ataqueActual">El ataque que está siendo utilizado.</param>
    /// <returns>El daño final calculado.</returns>
    public static int CalcularDañoporTipo(IPokemon pokemonActual, IPokemon pokemonRival, IAtaque ataqueActual)
    {
        int dañoCalculado = pokemonActual.Damage + ataqueActual.Poder - pokemonRival.Defense;
        double valorSinRedondear = TablaDeTipos.ObtenterRelacionMatematica(ataqueActual.Tipo, pokemonRival.Tipo) * dañoCalculado;
        int valorfinal = (int)Math.Round(valorSinRedondear);
        return valorfinal;
    }

    /// <summary>
    /// Comprueba si el Pokémon sigue vivo.
    /// </summary>
    /// <param name="vidaDelPokemon">La vida actual del Pokémon.</param>
    /// <param name="pokemonActual">El Pokémon que se va a comprobar.</param>
    /// <returns>Devuelve 0 si el Pokémon ha sido derrotado (vida = 0), de lo contrario devuelve 1.</returns>
    public static int CheckVida(int vidaDelPokemon, IPokemon pokemonActual)
    {
        if (vidaDelPokemon == 0)
        {
            return 0;
        }
        return 1;
    }
}
