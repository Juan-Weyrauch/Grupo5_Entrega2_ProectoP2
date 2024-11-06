using Library;

namespace ClassLibrary;

public static class Fachada
{
    public static void Start()
    {
        while (true)
        {
            ImpresoraDeTexto.startPrint();
            int inicial = Convert.ToInt32(Console.ReadLine());
            if (inicial == 1)
            {
                //deberia ser SistemaDeCombate.Combatir();
            }
            else if (incial == 2)
            {
                ImpresoraDeTexto.printEnd();
                break;
            }
            else
            {
                Console.WriteLine("Por favor, introduce un número válido (1 o 2).");
                Console.WriteLine("Presiona cualquier tecla para intentar de nuevo...");
                Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de continuar
                continue;
            }
            
        }
    }
}