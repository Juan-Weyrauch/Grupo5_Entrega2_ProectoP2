namespace ClassLibrary;

public class TablaDeTipos
{
       
    Dictionary<string, (List<string>, List<string>, List<string>)> TablaTiposPokemon =  new Dictionary<string, (List<string>, List<string>, List<string>)>();

    public void CrearTabla()
    {
        // Llenado del diccionario con algunos datos
        TablaTiposPokemon["Tipo1"] = (
            new List<string> { "valor1_1", "valor1_2", "valor1_3" }, // Primera lista
            new List<string> { "valor2_1", "valor2_2", "valor2_3" }, // Segunda lista
            new List<string> { "valor3_1", "valor3_2", "valor3_3" }  // Tercera lista
        );
    }
      
}
// Establecer las relaciones elementales