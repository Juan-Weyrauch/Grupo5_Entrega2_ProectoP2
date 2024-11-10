using ClassLibrary;
using Library.Static;

namespace Library;

/// <summary>
/// 
/// </summary>
public static class Combate
{
    static IVisitor _infoVisitor = new InfoVisitor();

    public static IPlayer _jugadorActual;
    public static IPlayer _jugadorRival;
    public static IPokemon _pokemonActual;
    public static IPokemon _pokemonRival;

    public static void Recibir(IPokemon pokemon, int damage)
    {
        pokemon.DecreaseHealth(damage);
    }

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
    /// Verifica el estado del pokemon y da la opcion a elegir otro en caso de estar muerto
    /// </summary>
    /// <param name="jugadorActual"></param>
    /// <param name="jugadorRival"></param>
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
        else if
            (pokemonActual.Health > 0 ||
             estadoDelEquipo > 0) // Si tiene salud o hay otros Pokémon en el equipo, continúa el juego.
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

            //Continua el juego con normalidad
            
            Combate.InicarAccion(jugadorActual, jugadorRival);
        }
    }
    
    //debe recibir la seleccion del jugador y al jugador con sus pokemons, eso incluye
    //al pokemon seleccionado
    private static void InicarAccion(IPlayer jugadorActual, IPlayer jugadorRival)
    { 
        //pregunta al usuario su movimiento siguiente
        string seleccion = ImpresoraDeTexto.TurnoJugador(jugadorActual.Name);
        
        // A = Atacar, B = Cambiar, C = Usar Item
        if (seleccion == "A")
        {
            Console.WriteLine("Con que deseas atacar?");
            
            ImpresoraDeTexto.MostrarAtaques(jugadorActual);
            int ataqueSeleccionado = Convert.ToInt16(Console.ReadLine());
            ataqueSeleccionado = Calculator.ValidAtackSelection(ataqueSeleccionado, jugadorActual.SelectedPokemon);
            
            IPokemon pokemonActualJugador = jugadorActual.SelectedPokemon;
            IPokemon pokemonActualRival = jugadorActual.SelectedPokemon;
            IAtaque ataquePokemon = pokemonActualJugador.Ataques[ataqueSeleccionado];
            
            int damage = Calculator.CalcularDañoPorTipo(jugadorActual.SelectedPokemon, jugadorRival.SelectedPokemon, ataquePokemon);
            //realiza el daño deseado
            pokemonActualRival.DecreaseHealth(damage);
            if (pokemonActualRival.Health == 0)
            {
                ImpresoraDeTexto.MuerteDelPokemon(pokemonActualRival);
                jugadorRival.EliminarPokemon(pokemonActualRival);
            }
            //regresa a calcular el turno
        }
        
        //B = Cambiar de Pokemon
        else if (seleccion == "B")
        {
            Console.WriteLine("A que pokemon deseas cambiar?");
            ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);
            int pokemonSeleccionado = Convert.ToInt16(Console.ReadLine());
            //actualiza el pokemonn seleccionado
            jugadorActual.SelectedPokemon = jugadorActual.Equipo[pokemonSeleccionado];
            //vuelve a preguntarle que quiere hacer
            seleccion = ImpresoraDeTexto.TurnoJugador(jugadorActual.Name);
            Combate.InicarAccion(jugadorActual, jugadorRival);
        }
        
        //C = Usar Item
        else if (seleccion == "C")
        {
            Console.WriteLine("Que item deseas usar?");
            int inventoryStatus = ImpresoraDeTexto.ImprimirItems(jugadorActual.Inventario);
            if (inventoryStatus == 0) // si no tiene items para usar
            {
                //regresa a la selccion
                Combate.InicarAccion(jugadorActual, jugadorRival);
            }
            // sino, utiliza el item seleccionado
            else if (inventoryStatus == 1)
            {
                //primero lee la seleccion del usuario
                int itemSeleccionado = Convert.ToInt16(Console.ReadLine());
                //lugo utilia el item en el pokemon seleccionado
                jugadorActual.UsarItem(itemSeleccionado, jugadorActual.SelectedPokemon);
            }
        }
        
        //ps: dejo 'Combate.' para mejorar legibilidad
        Combate.DeterminarTurno(jugadorActual, jugadorRival);
        
    }
    
}