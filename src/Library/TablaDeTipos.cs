namespace ClassLibrary;

public class TypeTable
{
    private Dictionary<string, PokemonType> types;

    public TypeTable()
    {
        types = new Dictionary<string, PokemonType>();
        InitializeTypes();
    }

    // Inicializa todos los tipos con fortalezas, debilidades e inmunidades
    private void InitializeTypes()
    {
        // Tipo Agua
        var agua = new PokemonType("Agua");
        agua.Strengths.AddRange(new[] { "Fuego", "Tierra", "Roca" });
        agua.Weaknesses.AddRange(new[] { "Planta", "Eléctrico" });
        types["Agua"] = agua;

        // Tipo Fuego
        var fuego = new PokemonType("Fuego");
        fuego.Strengths.AddRange(new[] { "Planta", "Bicho", "Hielo"});
        fuego.Weaknesses.AddRange(new[] { "Agua", "Roca", "Tierra" });
        types["Fuego"] = fuego;

        // Tipo Planta
        var planta = new PokemonType("Planta");
        planta.Strengths.AddRange(new[] { "Agua", "Tierra", "Roca" });
        planta.Weaknesses.AddRange(new[] { "Fuego", "Hielo", "Veneno", "Volador", "Bicho" });
        types["Planta"] = planta;

        // Tipo Eléctrico
        var electrico = new PokemonType("Eléctrico");
        electrico.Strengths.AddRange(new[]{ "Agua", "Volador"});
        electrico.Weaknesses.AddRange(new[]{"Tierra"});
        types["Eléctrico"] = electrico;

        // Tipo Hielo
        var hielo = new PokemonType("Hielo");
        hielo.Strengths.AddRange(new[] { "Planta", "Tierra", "Volador", "Dragón" });
        hielo.Weaknesses.AddRange(new[] { "Fuego", "Lucha", "Roca"});
        types["Hielo"] = hielo;

        // Tipo Lucha
        var lucha = new PokemonType("Lucha");
        lucha.Strengths.AddRange(new[] { "Normal", "Hielo", "Roca"});
        lucha.Weaknesses.AddRange(new[] { "Volador", "Psíquico"});
        lucha.Immunities.AddRange(new[]{ "Fantasma" });
        types["Lucha"] = lucha;

        // Tipo Veneno
        var veneno = new PokemonType("Veneno");
        veneno.Strengths.AddRange(new[] { "Planta" });
        veneno.Weaknesses.AddRange(new[] { "Tierra", "Psíquico" });
        types["Veneno"] = veneno;

        // Tipo Tierra
        var tierra = new PokemonType("Tierra");
        tierra.Strengths.AddRange(new[] { "Fuego", "Eléctrico", "Veneno", "Roca"});
        tierra.Weaknesses.AddRange(new[] { "Agua", "Hielo", "Planta" });
        tierra.Immunities.Add("Eléctrico");
        types["Tierra"] = tierra;

        // Tipo Volador
        var flying = new PokemonType("Volador");
        flying.Strengths.AddRange(new[] { "Planta", "Lucha", "Bicho" });
        flying.Weaknesses.AddRange(new[] { "Eléctrico", "Hielo", "Roca" });
        flying.Immunities.AddRange(new[]{"Tierra"});
        types["Volador"] = flying;

        // Tipo Psíquico
        var psiquico = new PokemonType("Psíquico");
        psiquico.Strengths.AddRange(new[] { "Lucha", "Veneno" });
        psiquico.Weaknesses.AddRange(new[] { "Bicho"});
        psiquico.Immunities.AddRange(new[]{"Fantasma"});
        types["Psíquico"] = psiquico;

        // Tipo Bicho
        var bicho = new PokemonType("Bicho");
        bicho.Strengths.AddRange(new[] { "Planta", "Psíquico" });
        bicho.Weaknesses.AddRange(new[] { "Fuego", "Volador", "Roca" });
        types["Bicho"] = bicho;

        // Tipo Roca
        var roca = new PokemonType("Roca");
        roca.Strengths.AddRange(new[] { "Fuego", "Hielo", "Volador", "Bicho" });
        roca.Weaknesses.AddRange(new[] { "Agua", "Planta", "Lucha", "Tierra"});
        types["Roca"] = roca;

        // Tipo Fantasma
        var fantasma = new PokemonType("Fantasma");
        fantasma.Strengths.AddRange(new[] { "Psíquico", "Fantasma" });
        fantasma.Weaknesses.AddRange(new[] { "Fantasma" });
        fantasma.Immunities.AddRange(new[]{"Normal", "Lucha"});
        types["Fantasma"] = fantasma;

        // Tipo Dragón
        var dragon = new PokemonType("Dragón");
        dragon.Strengths.Add("Dragón");
        dragon.Weaknesses.AddRange(new[] { "Hielo", "Dragón" });
        types["Dragón"] = dragon;

        // Tipo Normal
        var normal = new PokemonType("Normal");
        normal.Weaknesses.Add("Lucha");
        normal.Immunities.Add("Fantasma");
        types["Normal"] = normal;
    }
}
