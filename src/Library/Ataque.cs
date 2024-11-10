namespace ClassLibrary;

public class Ataque : IAtaque
{
    public string Name { get; private set; }
    public int Poder { get; private set; }
    public int Precision { get; private set; }
    public string Tipo { get; private set; }
    public int Especial { get; private set;}

    public Ataque(string name, int poder, int precision, string tipo, int especial)
    {
        Name = name;
        Poder = poder;
        Precision = precision;
        Tipo = tipo;
        Especial = especial;
        
    }
    public IAtaque Clonar()
    {
        return new Ataque(Name, Poder, Precision, Tipo, Especial);
    }
}