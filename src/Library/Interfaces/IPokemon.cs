namespace ClassLibrary;

public interface IPokemon
{
    string Name { get; }
    int Damage { get;  }
    int Defense { get;  } 
    int Health { get;  }
    int Estado { get; } // 0  es normal, 1 quemado, 2 envenanado, 3 paralizar, 4 Dormido
    int TurnosDormido { get; set; } // Para llevar cuenta de los turnos de sueño
    string Tipo { get; }
    int ContadorEspecial { get; set; }
    int InicialHealth { get; }
    public List<IAtaque> Ataques { get;  }
    void DecrementarContadorEspecial();
    bool PuedeAtacar();



    public void DecreaseHealth(int valueAfterCalculation);
    // void Accept(IVisitor visitor);
    void Curar(int cantidad);
    void EliminarEfectosDeEstado();
    public void CambiarEstado(int estado);
}