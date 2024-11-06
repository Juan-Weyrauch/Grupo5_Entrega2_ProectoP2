using ClassLibrary;

namespace Library;

public class CalculadoraDaño
{
    static double CalcularEfectividad(string tipoAtaque, string tipo1, string tipo2)
    {
        double multiplicador = 1.0;

        // Verificar si el ataque es fuerte contra el primer tipo
        if (TablaDeTipos[tipoAtaque].fortalezas.Contains(tipo1))
        {
            multiplicador *= 2.0;
        }
        else if (TablaDeTipos[tipoAtaque].debilidades.Contains(tipo1))
        {
            multiplicador *= 0.5;
        }
        else if (TablaDeTipos[tipoAtaque].inmunidades.Contains(tipo1))
        {
            multiplicador *= 0.0;
        }
        else
        {
            multiplicador *= 1.0;
        }

        // Verificar si el ataque es fuerte contra el segundo tipo
        if (TablaDeTipos[tipoAtaque].fortalezas.Contains(tipo2))
        {
            multiplicador *= 2.0;
        }
        else if (TablaDeTipos[tipoAtaque].debilidades.Contains(tipo2))
        {
            multiplicador *= 0.5;
        }
        else if (TablaDeTipos[tipoAtaque].inmunidades.Contains(tipo1))
        {
            multiplicador *= 0.0;
        }
        else
        {
            multiplicador *= 1.0;
        }

        return multiplicador;
    }
}