
namespace ClassLibrary;

using System;
using System.Collections.Generic;


public static class FabricaAtaque
{
    // Metodo estatico para ejecutar y agregar ataques al diccionario
    public static void Executar()
    {
        Dictionary<int, IAtaque> ataquesDiccionario = new Dictionary<int, IAtaque>();

        // Lista de algunos ataques populares de Pokemon con nombres y tipos en español (formato: nombre, poder, precisión, tipo, causaEfectoEspecial)
        List<(string, int, int, string, bool)> ataquesPokemon = new List<(string, int, int, string, bool)>
        {
            ("Placaje", 40, 100, "Normal", false),
            ("Latigo Cepa", 45, 100, "Planta", false),
            ("Lanzallamas", 90, 100, "Fuego", true),  // Puede causar quemadura
            ("Rayo", 90, 100, "Electrico", true),  // Puede paralizar
            ("Pistola de Agua", 40, 100, "Agua", false),
            ("Terremoto", 100, 100, "Tierra", false),
            ("Bola Sombra", 80, 100, "Fantasma", false),
            ("Hiperrayo", 150, 90, "Normal", false),
            ("Psiquico", 90, 100, "Psiquico", false),
            ("Rayo Hielo", 90, 100, "Hielo", false),
            ("Mordisco", 80, 100, "Sinistro", false),
            ("Surf", 90, 100, "Agua", false),
            ("Garra Dragon", 80, 100, "Dragon", false),
            ("Cola de Hierro", 100, 75, "Acero", false),
            ("Tormenta de Hielo", 110, 70, "Hielo", false),  
            ("Bomba Lodo", 90, 100, "Veneno", true),  // Puede envenenar
            ("Trueno", 110, 70, "Electrico", true),  // Puede paralizar
            ("Rayo Solar", 120, 100, "Planta", false),
            ("Cargallamas", 50, 100, "Fuego", false),
            ("Cola Aqua", 90, 90, "Agua", false),
            ("Corte Roca", 100, 80, "Roca", false),
            ("Deslizamiento Rocoso", 75, 90, "Roca", false),
            ("Bomba Semilla", 80, 100, "Planta", false),
            ("Hoja Afilada", 90, 100, "Planta", false),
            ("Ataque Aereo", 140, 90, "Volador", false),
            ("Golpe Cruzado", 100, 80, "Lucha", false),
            ("Patada Baja", 60, 100, "Lucha", false),
            ("Esfera Aura", 80, 100, "Lucha", false),
            ("Golpes Furiosos", 18, 80, "Normal", false),
            ("Zumbido", 90, 100, "Bicho", true),  // Puede dormir
            ("Hoja Afilada", 55, 95, "Planta", false),
            ("Puño Hielo", 75, 100, "Hielo", false),  
            ("Puño Fuego", 75, 100, "Fuego", false),
            ("Puño Trueno", 75, 100, "Electrico", true),  // Puede paralizar
            ("Tormenta Floral", 130, 90, "Planta", false),
            ("Carga Salvaje", 90, 100, "Electrico", false),
            ("Impacto Gigante", 150, 90, "Normal", false),
            ("Combate Cercano", 120, 100, "Lucha", false),
            ("Cabezazo Zen", 80, 90, "Psiquico", false),
            ("Puya Nociva", 80, 100, "Veneno", true),  // Puede envenenar
            ("Erupcion de Vapor", 110, 95, "Agua", false),
            ("Pulso Draco", 85, 100, "Dragon", false),
            ("Bomba Destrozadora", 80, 100, "Hielo", false),
            ("Destello Danzante", 80, 100, "Hada", false),
            ("Meteorito Draco", 130, 90, "Dragon", false),
            ("Juego Bruto", 90, 100, "Hada", false),
            ("Explosión Lunar", 95, 100, "Hada", false),
            ("Aceite Aéreo", 60, 100, "Volador", false),
            ("Garra Sombría", 70, 100, "Fantasma", false),
            ("V-creacion", 180, 95, "Fuego", false),
            ("Voz Hiperrapida", 90, 100, "Normal", false),
            ("Golpe Enfoque", 120, 70, "Lucha", false),
            ("Disparo Abrasador", 100, 100, "Fuego", false),
            ("Gema de Poder", 70, 100, "Roca", false),
            ("Rugido", 0, 0, "Normal", false),
            ("Poder Terrestre", 90, 100, "Tierra", false),
            ("Corte Nocturno", 70, 100, "Oscuro", false),
            ("Bola Sombra", 80, 100, "Fantasma", false),
            ("Huracán", 110, 70, "Volador", false),
            ("Ola de Calor", 95, 90, "Fuego", false),
            ("Flare de Semilla", 100, 85, "Planta", false),
            ("Llamarada", 110, 85, "Fuego", false),
            ("Voltaje Ascendente", 70, 100, "Electrico", false),
            ("Puño de Enfoque", 150, 100, "Lucha", false),
            ("Perforacion Terrestre", 80, 95, "Tierra", false),
            ("Absorción Gigante", 75, 100, "Planta", false),
            ("Disparo de Barro", 55, 95, "Tierra", false),
            ("Rayo de Carga", 50, 90, "Electrico", false),
            ("Ataque Triple", 80, 100, "Normal", false),
            ("Rebotar", 85, 85, "Volador", false),
            ("Golpe Abajo", 65, 100, "Oscuro", false),
            ("Rendimiento Espacial", 100, 95, "Dragon", false),
            ("Bomba Magnetica", 60, 100, "Acero", false),
            ("Espada Secreta", 85, 100, "Lucha", false),
            ("Espada Behemoth", 100, 100, "Acero", false),
            ("Planta Frenetica", 150, 90, "Planta", false),
            ("Tormenta Hoja", 130, 90, "Planta", false),
            ("Colmillo Psiquico", 85, 100, "Psiquico", false),
            ("Terror Nocturno", 85, 95, "Oscuro", false),
            ("Disparo Toxico", 120, 80, "Veneno", true)  // Puede envenenar
        };

        // Agregamos los ataques al diccionario
        for (int i = 0; i < ataquesPokemon.Count; i++)
        {
            var ataque = ataquesPokemon[i];
            ataquesDiccionario.Add(i, new Ataque(ataque.Item1, ataque.Item2, ataque.Item3, ataque.Item4, ataque.Item5));
        }
    }
}
