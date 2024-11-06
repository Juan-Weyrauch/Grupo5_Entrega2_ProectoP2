namespace ClassLibrary;

public class TypeTable
{
    private Dictionary<string, TipoPokemon> types;

    public TypeTable()
    {
        types = new Dictionary<string, TipoPokemon>();
        InitializeTypes();
    }

    // Inicializa todos los tipos con fortalezas, debilidades e inmunidades
    private void InitializeTypes()
    {
        // Tipo Agua
        var agua = new TipoPokemon("Agua");
        agua.Strengths.AddRange(new[] { "Fuego", "Tierra", "Roca" });
        agua.Weaknesses.AddRange(new[] { "Planta", "Eléctrico" });
        types["Agua"] = agua;

        // Tipo Fuego
        var fuego = new TipoPokemon("Fuego");
        fuego.Strengths.AddRange(new[] { "Planta", "Bicho", "Hielo"});
        fuego.Weaknesses.AddRange(new[] { "Agua", "Roca", "Tierra" });
        types["Fuego"] = fuego;

        // Tipo Planta
        var planta = new TipoPokemon("Planta");
        planta.Strengths.AddRange(new[] { "Agua", "Tierra", "Roca" });
        planta.Weaknesses.AddRange(new[] { "Fuego", "Hielo", "Veneno", "Volador", "Bicho" });
        types["Planta"] = planta;

        // Tipo Eléctrico
        var electrico = new TipoPokemon("Eléctrico");
        electrico.Strengths.AddRange(new[]{ "Agua", "Volador"});
        electrico.Weaknesses.AddRange(new[]{"Tierra"});
        types["Eléctrico"] = electrico;

        // Tipo Hielo
        var hielo = new TipoPokemon("Hielo");
        hielo.Strengths.AddRange(new[] { "Planta", "Tierra", "Volador", "Dragón" });
        hielo.Weaknesses.AddRange(new[] { "Fuego", "Lucha", "Roca"});
        types["Hielo"] = hielo;

        // Tipo Lucha
        var lucha = new TipoPokemon("Lucha");
        lucha.Strengths.AddRange(new[] { "Normal", "Hielo", "Roca"});
        lucha.Weaknesses.AddRange(new[] { "Volador", "Psíquico"});
        lucha.Immunities.AddRange(new[]{ "Fantasma" });
        types["Lucha"] = lucha;

        // Tipo Veneno
        var veneno = new TipoPokemon("Veneno");
        veneno.Strengths.AddRange(new[] { "Planta" });
        veneno.Weaknesses.AddRange(new[] { "Tierra", "Psíquico" });
        types["Veneno"] = veneno;

        // Tipo Tierra
        var tierra = new TipoPokemon("Tierra");
        tierra.Strengths.AddRange(new[] { "Fuego", "Eléctrico", "Veneno", "Roca"});
        tierra.Weaknesses.AddRange(new[] { "Agua", "Hielo", "Planta" });
        tierra.Immunities.Add("Eléctrico");
        types["Tierra"] = tierra;

        // Tipo Volador
        var flying = new TipoPokemon("Volador");
        flying.Strengths.AddRange(new[] { "Planta", "Lucha", "Bicho" });
        flying.Weaknesses.AddRange(new[] { "Eléctrico", "Hielo", "Roca" });
        flying.Immunities.AddRange(new[]{"Tierra"});
        types["Volador"] = flying;

        // Tipo Psíquico
        var psiquico = new TipoPokemon("Psíquico");
        psiquico.Strengths.AddRange(new[] { "Lucha", "Veneno" });
        psiquico.Weaknesses.AddRange(new[] { "Bicho"});
        psiquico.Immunities.AddRange(new[]{"Fantasma"});
        types["Psíquico"] = psiquico;

        // Tipo Bicho
        var bicho = new TipoPokemon("Bicho");
        bicho.Strengths.AddRange(new[] { "Planta", "Psíquico" });
        bicho.Weaknesses.AddRange(new[] { "Fuego", "Volador", "Roca" });
        types["Bicho"] = bicho;

        // Tipo Roca
        var roca = new TipoPokemon("Roca");
        roca.Strengths.AddRange(new[] { "Fuego", "Hielo", "Volador", "Bicho" });
        roca.Weaknesses.AddRange(new[] { "Agua", "Planta", "Lucha", "Tierra"});
        types["Roca"] = roca;

        // Tipo Fantasma
        var fantasma = new TipoPokemon("Fantasma");
        fantasma.Strengths.AddRange(new[] { "Psíquico", "Fantasma" });
        fantasma.Weaknesses.AddRange(new[] { "Fantasma" });
        fantasma.Immunities.AddRange(new[]{"Normal", "Lucha"});
        types["Fantasma"] = fantasma;

        // Tipo Dragón
        var dragon = new TipoPokemon("Dragón");
        dragon.Strengths.Add("Dragón");
        dragon.Weaknesses.AddRange(new[] { "Hielo", "Dragón" });
        types["Dragón"] = dragon;

        // Tipo Normal
        var normal = new TipoPokemon("Normal");
        normal.Weaknesses.Add("Lucha");
        normal.Immunities.Add("Fantasma");
        types["Normal"] = normal;
    }
}
