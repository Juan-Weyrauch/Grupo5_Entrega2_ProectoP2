using ClassLibrary;
using Library.Static;

namespace Library;

public static class Combate
{
    static IVisitor InfoVisitor = new InfoVisitor();

    //public void Combatir(Player juagor1, Player, jugador2)
    // {}
    static IPlayer JugadorActual;
    static IPlayer JugadorRival;
    static IPokemon PokemonActual;
    static IPokemon PokemonRival;

    public static void EfectuarEfecto(IPokemon pokemon)
    {
        int estadoPokemon = pokemon.Estado;
        int calculoDaño = 0;
        switch (estadoPokemon)
        {


            case 0:
                break;
            case 1: // Quemado
                calculoDaño = (int)Math.Round(0.15 * pokemon.Health);

                break;

            case 2: // Envenenado
                calculoDaño = (int)Math.Round(0.10 * pokemon.Health);
                break;

            case 3: // Parálisis (Ejemplo, puedes definir lo que debe hacer en este caso)

                break;

            // Agregar otros estados de Pokémon según sea necesario
            default:
                // Si no se corresponde con ningún estado, no hace nada
                break;
        }

        pokemon.DecreaseHealth(calculoDaño);

    }

    public static void Recibir(IPokemon pokemon, int damage)
    {
        pokemon.DecreaseHealth(damage);
    }

    public static void Combatir(IPlayer Jugador1, IPlayer Jugador2)
    {
        int turno = 0;


        while (Calculator.CombatValidation(Jugador1, Jugador2))
        {
            if (turno % 2 == 0) // Sistema sencillo que permite detectar cuando es el turno de cada jugador.
            {
                JugadorActual = Jugador1;

                JugadorRival = Jugador2;

            }
            else
            {
                JugadorActual = Jugador2;
                JugadorRival = Jugador1;
            }


            if (turno < 2)
            {
                ImpresoraDeTexto.MostrarPokemons(JugadorActual);
            }

            Turno(JugadorActual, JugadorRival);

            turno++;
        }

    }

    public static void Turno(IPlayer JugadorActual, IPlayer JugadorRival)
    {
        IPokemon pokemonActual = JugadorActual.SelectedPokemon;
        IPokemon pokemonRival = JugadorRival.SelectedPokemon;
        if (CheckVida(PokemonActual))
        {

            string nombrePlayer = Combate.JugadorActual.Name;
            ImpresoraDeTexto.TurnoJugador(nombrePlayer);
            string cadena = Console.ReadLine().ToUpper();

            if (cadena == "A")
            {
                Console.WriteLine("Con qué quieres atacar");
                // Meter una funcion que muestre los ataques posibles: 
                // int AtaqueElegido =  int.TryParse(Console.ReadLine())
                // Hacer el ataque con el Pokemon Actual a el Pokemon Rival.
                    
            }

            if (cadena == "B")
            {
                Console.WriteLine("Puedes cambiar a los siguentes Pokemons:");
                ImpresoraDeTexto.ImprimirEquipoDelJugador(JugadorActual.Equipo); // Hay que cambiar Imprimir Equipo Del Jugador.
                // Mostrar el equipo Pokemon del Jugador para luego permitirle cambiar en el equipo.
            }

            if (cadena == "C")
            {
                Console.WriteLine("Puedes utilizar los siguientes  Items:");
                ImpresoraDeTexto.ImprimirInventario(JugadorActual.Inventario);
                // ha 
            }
        }
    }

    public static bool CheckVida(IPokemon PokemonActual)
    {
        if (PokemonActual.Health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}