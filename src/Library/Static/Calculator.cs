namespace ClassLibrary;
using ClassLibrary;

public static class Calculator
{
    public static int GetValidatedNumber(int min, int max){
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            throw new FormatException("Debe ingresar un numero entero"); // Si no es un numero tira esto
        }

        if (number < min || number > max)
        {
            throw new ArgumentOutOfRangeException("Fuera de rango!"); // Si esta fuera de rango
        }

        return number; // si es valido el numero, lo devuelve
    }
    
    public static bool CombatValidation(Player Jugador1, Player Jugador2)
    {
        int Equipo1 = Jugador1.getInventarioCount();
        int Equipo2 = Jugador2.getInventarioCount();
    
        if ( (Equipo1 > 0 )&&( Equipo2 > 0 ) ){ return true; } 
        else{ return false; }
    }
}