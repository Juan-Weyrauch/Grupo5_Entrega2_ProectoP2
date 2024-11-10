using System.Diagnostics.CodeAnalysis;

namespace Library.Static;
using ClassLibrary;

/// <summary>
/// El objetivo de esta calse es realizar cualquier tipo de calculo y devolver el valor adecuado.
/// Esto nos sirve para simplificar la lectura del codigo, ya sea de la calse Combate o Fachada,
/// que son las clases que mas se fenefician de Calculator. 
/// </summary>
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
    /// Valida que los jugadores aun tengan pokemones vivios para seguir jugando
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

    public static int IndividualcombatValidation(List<IPokemon> jugador)
    {
        if (jugador.Count == 0){ return 0; }
        else { return 1; }
    }

    /// <summary>
    /// Calcula el daño total de un ataque. 
    /// </summary>
    /// <param name="pokemonActual"></param>
    /// <param name="pokemonRival"></param>
    /// <param name="ataqueActual"></param>
    /// <returns></returns>
    public static int CalcularDañoPorTipo(IPokemon pokemonActual, IPokemon pokemonRival, IAtaque ataqueActual)
    {
        int dañoCalculado = pokemonActual.Damage + ataqueActual.Poder - pokemonRival.Defense;
        double valorSinRedondear = TablaDeTipos.ObtenterRelacionMatematica(ataqueActual.Tipo,pokemonRival.Tipo) * dañoCalculado;
        int valorfinal = (int)Math.Round(valorSinRedondear);
        return valorfinal;
    }
    
    /// <summary>
    /// Calcula y devuelve si el pokeom aun sigue con vida.
    /// </summary>
    /// <param name="pokemonActual"></param>
    /// <returns></returns>
    public static int CheckVida(int vidaDelPokemon, IPokemon pokemonActual)
    {
        if (vidaDelPokemon == 0)
        {
            return 0;
        }
        return 0;
    }

    public static int ValidAtackSelection(int ataque, IPokemon pokemon)
    {
        // Ajustar el valor si el ataque es igual al número total de ataques
        if (ataque == pokemon.Ataques.Count)
        {
            ataque--;
        }

        // Verificar si el ataque está fuera del rango válido
        while (ataque < 0 || ataque >= pokemon.Ataques.Count)
        {
            Console.WriteLine("Ingrese un número válido!.");
        
            // Intentar convertir la entrada del usuario a un número entero
            if (int.TryParse(Console.ReadLine(), out int nuevoAtaque))
            {
                ataque = nuevoAtaque;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
        
        return ataque;
    }

    public static int ChequearEstado(IPokemon pokemon)
    {
        int estado = pokemon.Estado;
        if (estado == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    

}