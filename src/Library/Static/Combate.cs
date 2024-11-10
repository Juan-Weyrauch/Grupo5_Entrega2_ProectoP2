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

    public static void DeterminarTurno(IPlayer jugador1, IPlayer jugador2)
    {
        int turno = 0;
        while (Calculator.CombatValidation(jugador1, jugador2))
        {
            if (turno % 2 == 0) // Sistema sencillo que permite detectar cuando es el turno de cada jugador.
            {
                _jugadorActual = jugador1;
                _jugadorRival = jugador2;
            }
            else
            {
                _jugadorActual = jugador2;
                _jugadorRival = jugador1;
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
        int contadorEAtaquesEspeciales;
        IPokemon pokemonActual = jugadorActual.SelectedPokemon;
        IPokemon pokemonRival = jugadorRival.SelectedPokemon;
        int estadoDelPokemon = Calculator.ChequearEstado(pokemonActual);

        // Chequeo si aun tiene pokemons
        int estadoDelEquipo = Calculator.IndividualcombatValidation(jugadorActual.Equipo);

        if (pokemonActual.Health == 0 && estadoDelEquipo == 0) // Si no puede seguir jugando, termina el juego.
        {
            ImpresoraDeTexto.FinDelJuego(jugadorRival.Name);
        }
        else if
            
            ((pokemonActual.Health > 0 ||   // Si tiene salud 
             estadoDelEquipo > 0)           // o hay otros Pokémon en el equipo
             && estadoDelPokemon == 0) // y el estado es normal
            // Continúa el juego.
        {
            
            if (pokemonActual.Health == 0) // Si el Pokémon actual está fuera de combate, debe elegir otro.
            {
                Console.WriteLine($"Tu Pokémon {pokemonActual.Name} ha sido derrotado.");
                Console.WriteLine("Debes seleccionar otro Pokémon: ");
                ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);
                

                while (true)
                {
                    
                    Console.WriteLine("Por favor seleccione una pokemon: ");
                    if (int.TryParse(Console.ReadLine(), out pokemonSeleccionado) &&
                        pokemonSeleccionado >= 0 && pokemonSeleccionado < jugadorActual.Equipo.Count &&
                        jugadorActual.Equipo[pokemonSeleccionado].Health > 0
                        && estadoDelPokemon == 0)
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
            else if (estadoDelPokemon != 0)
            {
                
            }

            //Continua el juego con normalidad
            //TODO
            //!!!Debe chequear el estado del pokemon y mostrarlo antes de darle las opciones
            Combate.InicarAccion(jugadorActual, jugadorRival);
        }
    }
    
    //debe recibir la seleccion del jugador y al jugador con sus pokemons, eso incluye
    //al pokemon seleccionado
    private static void InicarAccion(IPlayer jugadorActual, IPlayer jugadorRival)
    {
        int contadorAtaquesEspeciales;
        IPokemon pokemonActualJugador = jugadorActual.SelectedPokemon;
        IPokemon pokemonActualRival = jugadorActual.SelectedPokemon;
        //pregunta al usuario su movimiento siguiente
        string seleccion = ImpresoraDeTexto.TurnoJugador(jugadorActual.Name);
        
        // A = Atacar, B = Cambiar, C = Usar Item
        if (seleccion == "A")
        {
            Console.WriteLine("Con que deseas atacar?");
            
            ImpresoraDeTexto.MostrarAtaques(jugadorActual);
            int ataqueSeleccionado = Convert.ToInt16(Console.ReadLine());
            //Validar que sea posible seleccionar ese ataque
            ataqueSeleccionado = Calculator.ValidAtackSelection(ataqueSeleccionado, jugadorActual.SelectedPokemon);
            //Validar que el ataque, de ser especial, este disponible
            
            IAtaque ataquePokemon = pokemonActualJugador.Ataques[ataqueSeleccionado];
            
            //si no es especial ataca directamente
            if (ataquePokemon.Especial == 0)
            {
                int estado = 0;
                int damage = Calculator.CalcularDañoPorTipo(jugadorActual.SelectedPokemon, jugadorRival.SelectedPokemon, ataquePokemon, estado);
                //realiza el daño deseado
                pokemonActualRival.DecreaseHealth(damage);
                if (pokemonActualRival.Health == 0)
                {
                    ImpresoraDeTexto.MuerteDelPokemon(pokemonActualRival);
                    jugadorRival.EliminarPokemon(pokemonActualRival);
                }
            }
            //sino, efectua el ataque especial
            else
            {
                Combate.EfectuarAtaqueEspecial(jugadorActual, jugadorRival, ataquePokemon);
                int damage = Calculator.CalcularDañoPorTipo(jugadorActual.SelectedPokemon, jugadorRival.SelectedPokemon, ataquePokemon, estado);

            }
            //regresa a calcular el turno
        }
        
        //B = Cambiar de Pokemon !!!Debe chequear el estado del pokemon antes de atacar
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

    /// <summary>
    /// Este metodo setea el estado del pokemon rival solamente si el ataque utilizado es 'especial'
    /// </summary>
    /// <param name="jugadorActual"></param>
    /// <param name="jugadorRival"></param>
    /// <param name="ataque"></param>
    private static void EfectuarAtaqueEspecial(IPlayer jugadorActual, IPlayer jugadorRival, IAtaque ataque)
    {
        // 1 = Quemar, 2 = Envenenar, 3 = Paralizar, 4 = Dormir
        IAtaque ataqueActual = ataque;
        int tipo = ataqueActual.Especial;
        //determinar el random
        Random rnd = new Random();
        int randomTiming = rnd.Next(1, 10);
        
        if (tipo == 1)
        {
            //ataca con veneno (pierde 10% de hp en cada turno)
            int damage = (int)Math.Round(_pokemonRival.Health * 0.90);
            _pokemonRival.DecreaseHealth(damage);
        }
        else if (tipo == 2)
        {
            //ataca con veneno (pierde 5% de hp en cada turno)
            int damage = (int)Math.Round(_pokemonRival.Health * 0.95);
            _pokemonRival.DecreaseHealth(damage);
            
        }
        else if (tipo == 3)
        {
            //paraliza al enemigo (puede atacar o no aleatorio)
            if (randomTiming == 3 || randomTiming == 7)
            {
                _pokemonRival.CambiarEstado(0);
            }
            else
            {
                Console.WriteLine("El pokemon ha sido paralizado");
                _pokemonRival.CambiarEstado(3);
            }
            
        }
        else if (tipo == 4)
        {
            //duerme al enemigo (entre 1 y 4 turnos) 
            randomTiming = rnd.Next(1, 4);
            if (randomTiming == 2 || randomTiming == 4)
            {
                Console.WriteLine($"El pokemon {_pokemonRival.Name} esta despierto!");
                _pokemonRival.CambiarEstado(0);
            }
            else
            {
                Console.WriteLine($"El pokemon {_pokemonRival.Name} esta dormido!");
                _pokemonRival.CambiarEstado(4);
            }
            
            
        }
        /* Clase con la funcionalidad el ataque Pokemon.
        public static void Atacar(IPokemon atacante, IPokemon defensor, IAtaque ataque)
        {
            // Obtener el tipo del ataque y el tipo del defensor
            string tipoAtaque = ataque.Tipo;
            string tipoDefensor = defensor.Tipo;

            // Calcular la efectividad del ataque
            double multiplicador = Calculator.Efectividad(tipoAtaque, tipoDefensor);

            // Calcular el daño final
            int dañoFinal = (int)Math.Round(ataque.Poder * multiplicador);

            // Mostrar mensajes sobre el ataque
            Console.WriteLine($"{atacante.Name} usa {ataque.Name} sobre {defensor.Name}.");
            if (multiplicador == 0.0)
            {
                Console.WriteLine("¡No tuvo efecto!");
            }
            else if (multiplicador == 2.0)
            {
                Console.WriteLine("¡Es muy efectivo!");
            }
            else if (multiplicador == 0.5)
            {
                Console.WriteLine("No es muy efectivo...");
            }

            // Reducir la salud del defensor
            Recibir(defensor, dañoFinal);
            Console.WriteLine($"Recibio  {defensor.Name} recibio {dañoFinal} ahora tiene {defensor.Health} puntos de vida.");
        }*/
        
    }
    
    
    
}