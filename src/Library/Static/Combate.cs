using ClassLibrary;
using Library.Static;

namespace Library;

/// <summary>
/// Esta clase maneja la lógica del combate entre dos jugadores, gestionando el turno de los jugadores, la selección de Pokémon y la ejecución de ataques.
/// </summary>
public static class Combate
{
    static IVisitor _infoVisitor = new InfoVisitor();

    public static IPlayer _jugadorActual;
    public static IPlayer _jugadorRival;
    public static IPokemon _pokemonActual;
    public static IPokemon _pokemonRival;

    /// <summary>
    /// Recibe el daño que un Pokémon debe restar a su salud.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplica el daño.</param>
    /// <param name="damage">El daño que el Pokémon recibirá.</param>
    public static void Recibir(IPokemon pokemon, int damage)
    {
        pokemon.DecreaseHealth(damage);
    }

    /// <summary>
    /// Determina el turno entre los dos jugadores y maneja la lógica del combate entre ellos.
    /// Se alterna entre el jugador 1 y el jugador 2, realizando el combate hasta que uno de los jugadores no tenga Pokémon disponibles.
    /// </summary>
    /// <param name="Jugador1">El primer jugador del combate.</param>
    /// <param name="Jugador2">El segundo jugador del combate.</param>
    public static void DeterminarTurno(IPlayer Jugador1, IPlayer Jugador2)
    {
        int turno = 0;

        while (Calculator.CombatValidation(Jugador1, Jugador2))
        {
            if (turno % 2 == 0) // Sistema sencillo que permite detectar cuando es el turno de cada jugador.
            {
                _jugadorActual = Jugador1;
                _jugadorRival = Jugador2;
            }
            else
            {
                _jugadorActual = Jugador2;
                _jugadorRival = Jugador1;
            }

            if (turno < 2)
            {
                ImpresoraDeTexto.MostrarPokemons(_jugadorActual);
            }

            Combatir(_jugadorActual, _jugadorRival);

            turno++;
        }
    }

    /// <summary>
    /// Ejecuta la lógica de combate entre los Pokémon seleccionados de los jugadores actuales.
    /// Si un Pokémon es derrotado, se le permite al jugador seleccionar otro Pokémon si tiene disponible.
    /// Si un jugador pierde todos sus Pokémon, termina el juego.
    /// </summary>
    /// <param name="jugadorActual">El jugador cuyo Pokémon está en combate.</param>
    /// <param name="jugadorRival">El jugador rival cuyo Pokémon está en combate.</param>
    private static void Combatir(IPlayer jugadorActual, IPlayer jugadorRival)
    {
        IPokemon pokemonActual = jugadorActual.SelectedPokemon;
        IPokemon pokemonRival = jugadorRival.SelectedPokemon;

        // Chequeo si aun tiene pokemons
        int estadoDelEquipo = Calculator.IndividualcombatValidation(jugadorActual.Equipo);

        if (pokemonActual.Health == 0 && estadoDelEquipo == 0) // Si no puede seguir jugando, termina el juego.
        {
            ImpresoraDeTexto.FinDelJuego(jugadorRival.Name);
        }
        else if (pokemonActual.Health > 0 || estadoDelEquipo > 0) // Si tiene salud o hay otros Pokémon en el equipo, continúa el juego.
        {
            if (pokemonActual.Health == 0) // Si el Pokémon actual está fuera de combate, debe elegir otro.
            {
                Console.WriteLine($"Tu Pokémon {pokemonActual.Name} ha sido derrotado.");
                Console.WriteLine("Debes seleccionar otro Pokémon: ");
                ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);
                int pokemonSeleccionado;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out pokemonSeleccionado) &&
                        pokemonSeleccionado >= 0 && pokemonSeleccionado < jugadorActual.Equipo.Count &&
                        jugadorActual.Equipo[pokemonSeleccionado].Health > 0)
                    {
                        jugadorActual.SelectedPokemon = jugadorActual.Equipo[pokemonSeleccionado];
                        break;
                    }
                    else
                    {
                        Console.WriteLine(
                            "Selección no válida. Ingresa un número correspondiente a un Pokémon con salud.");
                    }
                }
            }

            // Continúa el juego con normalidad
            string seleccion = ImpresoraDeTexto.TurnoJugador(jugadorActual.Name);
            Combate.InicarAccion(seleccion);
        }
    }

    /// <summary>
    /// Inicia la acción seleccionada por el jugador durante su turno.
    /// </summary>
    /// <param name="seleccion">La opción seleccionada por el jugador, como "A" para atacar.</param>
    private static void InicarAccion(string seleccion)
    {
        if (seleccion == "A")
        {
            // Aquí se gestionaría la acción de ataque
        }
    }
}
