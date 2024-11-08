
namespace ClassLibrary;

using System;
using System.Collections.Generic;


public static class FabricaAtaque
{
    static Dictionary<int, IAtaque> ataquesDiccionario = new Dictionary<int, IAtaque>();

    // Metodo estatico para ejecutar y agregar ataques al diccionario
    public static void Executar()
    {

        // Lista de algunos ataques populares de Pokemon con nombres y tipos en español (formato: nombre, poder, precisión, tipo, causaEfectoEspecial)
        List<(string, int, int, string, int)> ataquesPokemon = new List<(string, int, int, string, int)>
        {
            ("Placaje", 40, 100, "Normal", 0),
            ("Latigo Cepa", 45, 100, "Planta", 0),
            ("Lanzallamas", 90, 100, "Fuego", 1), // Puede causar quemadura
            ("Rayo", 90, 100, "Electrico", 3), // Puede paralizar
            ("Pistola de Agua", 40, 100, "Agua", 0),
            ("Terremoto", 100, 100, "Tierra", 0),
            ("Hiperrayo", 150, 90, "Normal", 0),
            ("Psiquico", 90, 100, "Psiquico", 0),
            ("Rayo Hielo", 90, 100, "Hielo", 0),
            ("Mordisco", 80, 100, "Sinistro", 0),
            ("Surf", 90, 100, "Agua", 0),
            ("Garra Dragon", 80, 100, "Dragon", 0),
            ("Cola de Hierro", 100, 75, "Acero", 0),
            ("Tormenta de Hielo", 110, 70, "Hielo", 0),
            ("Bomba Lodo", 90, 100, "Veneno", 2), // Puede envenenar
            ("Trueno", 110, 70, "Electrico", 3), // Puede paralizar
            ("Rayo Solar", 120, 100, "Planta", 0),
            ("Cargallamas", 50, 100, "Fuego", 0),
            ("Cola Aqua", 90, 90, "Agua", 0),
            ("Corte Roca", 100, 80, "Roca", 0),
            ("Deslizamiento Rocoso", 75, 90, "Roca", 0),
            ("Bomba Semilla", 80, 100, "Planta", 0),
            ("Hoja Afilada", 90, 100, "Planta", 0),
            ("Ataque Aereo", 140, 90, "Volador", 0),
            ("Golpe Cruzado", 100, 80, "Lucha", 0),
            ("Patada Baja", 60, 100, "Lucha", 0),
            ("Esfera Aura", 80, 100, "Lucha", 0),
            ("Golpes Furiosos", 18, 80, "Normal", 0),
            ("Zumbido", 90, 100, "Bicho", 4), // Puede dormir
            ("Hoja Afilada", 55, 95, "Planta", 0),
            ("Puño Hielo", 75, 100, "Hielo", 0),
            ("Puño Fuego", 75, 100, "Fuego", 0),
            ("Puño Trueno", 75, 100, "Electrico", 3), // Puede paralizar
            ("Tormenta Floral", 130, 90, "Planta", 0),
            ("Carga Salvaje", 90, 100, "Electrico", 0),
            ("Impacto Gigante", 150, 90, "Normal", 0),
            ("Combate Cercano", 120, 100, "Lucha", 0),
            ("Cabezazo Zen", 80, 90, "Psiquico", 0),
            ("Puya Nociva", 80, 100, "Veneno", 2), // Puede envenenar
            ("Erupcion de Vapor", 110, 95, "Agua", 0),
            ("Pulso Draco", 85, 100, "Dragon", 0),
            ("Bomba Destrozadora", 80, 100, "Hielo", 0),
            ("Destello Danzante", 80, 100, "Hada", 0),
            ("Meteorito Draco", 130, 90, "Dragon", 0),
            ("Juego Bruto", 90, 100, "Hada", 0),
            ("Explosión Lunar", 95, 100, "Hada", 0),
            ("Aceite Aéreo", 60, 100, "Volador", 0),
            ("Garra Sombría", 70, 100, "Fantasma", 0),
            ("V-creacion", 180, 95, "Fuego", 0),
            ("Voz Hiperrapida", 90, 100, "Normal", 0),
            ("Golpe Enfoque", 120, 70, "Lucha", 0),
            ("Disparo Abrasador", 100, 100, "Fuego", 0),
            ("Gema de Poder", 70, 100, "Roca", 0),
            ("Rugido", 0, 0, "Normal", 0),
            ("Poder Terrestre", 90, 100, "Tierra", 0),
            ("Corte Nocturno", 70, 100, "Oscuro", 0),
            ("Bola Sombra", 80, 100, "Fantasma", 0),
            ("Huracán", 110, 70, "Volador", 0),
            ("Ola de Calor", 95, 90, "Fuego", 0),
            ("Flare de Semilla", 100, 85, "Planta", 0),
            ("Llamarada", 110, 85, "Fuego", 0),
            ("Voltaje Ascendente", 70, 100, "Electrico", 0),
            ("Puño de Enfoque", 150, 100, "Lucha", 0),
            ("Perforacion Terrestre", 80, 95, "Tierra", 0),
            ("Absorción Gigante", 75, 100, "Planta", 0),
            ("Disparo de Barro", 55, 95, "Tierra", 0),
            ("Rayo de Carga", 50, 90, "Electrico", 0),
            ("Ataque Triple", 80, 100, "Normal", 0),
            ("Rebotar", 85, 85, "Volador", 0),
            ("Golpe Abajo", 65, 100, "Oscuro", 0),
            ("Rendimiento Espacial", 100, 95, "Dragon", 0),
            ("Bomba Magnetica", 60, 100, "Acero", 0),
            ("Espada Secreta", 85, 100, "Lucha", 0),
            ("Espada Behemoth", 100, 100, "Acero", 0),
            ("Planta Frenetica", 150, 90, "Planta", 0),
            ("Tormenta Hoja", 130, 90, "Planta", 0),
            ("Colmillo Psiquico", 85, 100, "Psiquico", 0),
            ("Terror Nocturno", 85, 95, "Oscuro", 0),
            ("Disparo Toxico", 120, 80, "Veneno", 2) // Puede envenenar
        };

        // Agregamos los ataques al diccionario
        for (int i = 1; i < ataquesPokemon.Count; i++)
        {
            var ataque = ataquesPokemon[i];
            ataquesDiccionario.Add(i, new Ataque(ataque.Item1, ataque.Item2, ataque.Item3, ataque.Item4, ataque.Item5));
        }

    }
}
/*

public static List<IAtaque> GenerarAtaquesRandom()
    {
        Random rand = new Random(); // Inicializa el generador de números aleatorios
        List<IAtaque> ataquesSeleccionados = new List<IAtaque>(); // Lista donde guardaremos los ataques seleccionados

        // Obtener todas las claves del diccionario (los identificadores de los ataques)
        List<int> claves = new List<int>(ataquesDiccionario.Keys);

        // Seleccionar 4 ataques aleatorios
        for (int i = 0; i < 4; i++)
        {
            // Seleccionar una clave aleatoria del diccionario
            int claveAleatoria = claves[rand.Next(claves.Count)];

            // Obtener el ataque correspondiente a esa clave
            IAtaque ataque = ataquesDiccionario[claveAleatoria];


            // Agregar el ataque a la lista de ataques seleccionados
            ataquesSeleccionados.Add(ataque);
        }

        return ataquesSeleccionados;
    }
}
*/
