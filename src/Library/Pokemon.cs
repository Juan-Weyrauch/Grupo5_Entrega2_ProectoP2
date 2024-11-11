namespace ClassLibrary;

public class Pokemon : IPokemon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Estado { get; private set; } // 0  es normal, 1 quemado, 2 envenanado, 3 paralizar, 4 Dormido  
    public int TurnosDormido { get; set; } // Para llevar cuenta de los turnos de sueño
    public int InicialHealth { get; private set; }
    public List<IAtaque> Ataques { get; private set; }
    public string Tipo { get; private set; }
    public int ContadorEspecial { get; set; }



    public Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> ataques)
    {
        Name = name;
        Damage = damage;
        Defense = defense;
        Health = health;
        Tipo = tipo;
        Ataques = ataques;
        InicialHealth = health;
        Estado = 0; // Por defecto el Estado es normal.
        ContadorEspecial = 2;
        TurnosDormido = 0;
    }

    public void DecreaseHealth(int valueAfterCalculation) // Resta de vida despues del calculo de daño. 
    {
        Health -= valueAfterCalculation;
        if (Health < 0) Health = 0;
    }

    public void Curar(int cantidad)
    {
        Health = Math.Min(Health + cantidad, InicialHealth);
    }

    public void EliminarEfectosDeEstado()
    {
        Estado = 0;
        TurnosDormido = 0;
    }

    public void DecrementarContadorEspecial()
    {
        ContadorEspecial--;
    }

    public void CambiarEstado(int nuevoEstado)
    {
        Estado = nuevoEstado; // Cambia el estado del Pokémon
        if (Estado == 4) // Si está dormido, inician los turnos de sueño
        {
            TurnosDormido = 4; // O el número de turnos que deseas que esté dormido
        }
        else
        {
            TurnosDormido = 0; // Si no está dormido, reinicia los turnos
        }
    }
    public bool PuedeAtacar()
    {
        if (Estado == 3) // Paralizado
        {
            Random rnd = new Random();
            // 25% de probabilidades de no poder atacar
            if (rnd.Next(1, 5) == 1) 
            {
                Console.WriteLine($"{Name} está paralizado y no puede atacar.");
                return false;
            }
            else
            {
                Console.WriteLine($"{Name} puede atacar a pesar de estar paralizado.");
                return true;
            }
        }

        if (Estado == 4 && TurnosDormido > 0) // Dormido
        {
            Random rnd = new Random();
            // 50% de probabilidades de despertar
            if (rnd.Next(1, 3) == 1)
            {
                Console.WriteLine($"{Name} se despierta y puede atacar.");
                TurnosDormido = 0; // El Pokémon se despierta
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} sigue dormido y no puede atacar.");
                TurnosDormido--;
                return false;
            }
        }

        // Si no está paralizado ni dormido, puede atacar
        return true;
    }

}