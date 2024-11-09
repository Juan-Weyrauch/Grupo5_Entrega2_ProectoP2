using ClassLibrary;

namespace Library.Static;

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

    public static int CalcularDañoporTipo(IPokemon PokemonActual, IPokemon PokemonRival, IAtaque AtaqueActual)
    {
        int DañoCalculado = PokemonActual.Damage + AtaqueActual.Poder - PokemonRival.Defense;
        double valorSinRedondear = TablaDeTipos.ObtenterRelacionMatematica(AtaqueActual.Tipo,PokemonRival.Tipo) * DañoCalculado;
        int valorfinal = (int)Math.Round(valorSinRedondear);
        return valorfinal;
    }
}