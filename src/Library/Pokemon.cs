namespace ClassLibrary
{
    public enum Estado
    {
        Normal = 0,
        Quemado = 1,
        Envenenado = 2,
        Paralizado= 3,
        Dormido = 4
    }

    public class Pokemon : IPokemon
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int Defense { get; private set; }
        public int Health { get; private set; }
        public Estado EstadoActual { get; set; }  // Cambio de int a Estado
        public int TurnosDormido { get; set; }
        public int InicialHealth { get; private set; }
        public List<IAtaque> Ataques { get; private set; }
        public string Tipo { get; private set; }
        public int ContadorEspecial { get; set; }

        public bool IsDead => Health <= 0;

        public Pokemon(string name, int damage, int defense, int health, string tipo, List<IAtaque> ataques)
        {
            Name = name;
            Damage = damage;
            Defense = defense;
            Health = health;
            Tipo = tipo;
            Ataques = ataques;
            InicialHealth = health;
            EstadoActual = Estado.Normal;  // Asignación con el enum
            ContadorEspecial = 2;
            TurnosDormido = 0;
        }

        public void DecreaseHealth(int valueAfterCalculation)
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
            EstadoActual = Estado.Normal;  // Cambiar a "Normal"
            TurnosDormido = 0;
        }

        public void DecrementarContadorEspecial()
        {
            ContadorEspecial--;
        }

        public void CambiarEstado(int nuevoEstado)
        {
            EstadoActual = (Estado)nuevoEstado;
        }

        public void AplicarEfectos()
        {
            // Daño por quemaduras
            if (EstadoActual == Estado.Quemado) 
            {
                DecreaseHealth(10);
                Console.WriteLine($"{Name} sufre daño por quemaduras.");
            }
            // Daño por envenenamiento
            else if (EstadoActual == Estado.Envenenado) 
            {
                DecreaseHealth(15);
                Console.WriteLine($"{Name} sufre daño por envenenamiento.");
            }
        }

        public bool PuedeAtacar()
        {
            AplicarEfectos();

            if (EstadoActual == Estado.Paralizado) 
            {
                Random rnd = new Random();
                if (rnd.Next(1, 5) == 1)
                {
                    Console.WriteLine($"{Name} está paralizado y no puede atacar.");
                    return false;
                }
            }

            if (EstadoActual == Estado.Dormido && TurnosDormido > 0) 
            {
                Random rnd = new Random();
                if (rnd.Next(1, 3) == 1)
                {
                    Console.WriteLine($"{Name} se despierta y puede atacar.");
                    TurnosDormido = 0;
                    return true;
                }
                else
                {
                    Console.WriteLine($"{Name} sigue dormido y no puede atacar.");
                    TurnosDormido--;
                    return false;
                }
            }

            return true;
        }
    }
}
