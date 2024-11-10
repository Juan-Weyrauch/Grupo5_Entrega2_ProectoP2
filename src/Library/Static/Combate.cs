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
    /// 
    /// </summary>
    /// <param name="jugadorActual"></param>
    /// <param name="jugadorRival"></param>
    private static void Combatir(IPlayer jugadorActual, IPlayer jugadorRival)
    {
        IPokemon pokemonActual = jugadorActual.SelectedPokemon;
        IPokemon pokemonRival = jugadorRival.SelectedPokemon;
        
        /*Chequeo si aun tiene pokemons*/ int estadoDelEquipo = Calculator.IndividualcombatValidation(jugadorActual.Equipo);

        if (pokemonActual.Health == 0 && estadoDelEquipo == 0) // Si no puede seguir jugando termina!
        {
            ImpresoraDeTexto.FinDelJuego(_jugadorRival.Name);
        }
        else if (pokemonActual.Health > 0 && estadoDelEquipo > 0) // En caso contrario continua el juego!
        {
            if (pokemonActual.Health == 0)
            {
                Console.WriteLine($"Tu pokemon {pokemonActual.Name} ha muerto!");
                Console.WriteLine("Debes seleccionar otro pokemon: ");
                ImpresoraDeTexto.ImprimirEquipo(jugadorActual.Equipo);
                int pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
                jugadorActual.Equipo[pokemonSeleccionado - 1 ];
            }


            // Aplicar efectos de estado (Dormido, Paralizado, Quemado, Envenenado) al principio del turno
            EfectuarEfecto(pokemonActual);

            if (pokemonActual.Estado == 0) // Si no está dormido ni paralizado
            {
                string nombrePlayer = jugadorActual.Name;
                
                string cadena = ImpresoraDeTexto.TurnoJugador(nombrePlayer);
                
                
                // Selecciona Atacar
                if (cadena == "A")
                {
                    Console.WriteLine("Con qué quieres atacar?");
                    // Lógica de ataque (agregar selección de ataque aquí)
                }
                
                // Mostrar el equipo y permitir el cambio de Pokémon
                else if (cadena == "B")
                {
                    Console.WriteLine("Puedes cambiar a los siguientes Pokemons, selecciona el tuyo!:");
                    ImpresoraDeTexto.ImprimirEquipoDelJugador(jugadorActual.Equipo);
                    // en este punto ya mostro el equipo
                    IPokemon pokemonAUsar = jugadorActual.Equipo[Convert.ToInt16(Console.ReadLine())];
                    
                }
                
                // Usar Item
                else if (cadena == "C")
                {
                    Console.WriteLine("Puedes utilizar los siguientes Items:");
                    ImpresoraDeTexto.ImprimirInventario(jugadorActual.Inventario);
                    SeleccionarItem(jugadorActual);
                }
            }
            else
            {
                Console.WriteLine($"{pokemonActual.Name} no puede actuar este turno debido a su estado.");
            }
        }
    }


    public static void EfectuarEfecto(IPokemon pokemon)
    {
        int estadoPokemon = pokemon.Estado;
        int calculoDaño = 0;
        Random random = new Random();

        switch (estadoPokemon)
        {
            case 0:
                break; // Sin efectos
            case 1: // Quemado
                calculoDaño = (int)Math.Round(0.15 * pokemon.Health);
                Console.WriteLine($"{pokemon.Name} está quemado y recibe {calculoDaño} de daño.");
                pokemon.DecreaseHealth(calculoDaño);
                break;

            case 2: // Envenenado
                calculoDaño = (int)Math.Round(0.10 * pokemon.Health);
                Console.WriteLine($"{pokemon.Name} está envenenado y recibe {calculoDaño} de daño.");
                pokemon.DecreaseHealth(calculoDaño);
                break;

            case 3: // Parálisis
                // 25% de probabilidad de no poder actuar (no atacar)
                if (random.NextDouble() < 0.25)
                {
                    Console.WriteLine($"{pokemon.Name} está paralizado y no puede atacar este turno.");
                }
                else
                {
                    Console.WriteLine($"{pokemon.Name} está paralizado pero puede atacar.");
                }

                break;

            case 4: // Dormido
                // El Pokémon pierde el turno
                Console.WriteLine($"{pokemon.Name} está dormido y pierde este turno.");

                // Intentar despertar con una probabilidad de 25%
                if (random.NextDouble() < 0.25) // 25% de probabilidad de despertar
                {
                    pokemon.EliminarEfectosDeEstado(); // Despierta
                    Console.WriteLine($"{pokemon.Name} se ha despertado.");
                }
                else
                {
                    Console.WriteLine($"{pokemon.Name} sigue dormido.");
                }

                break;

            default:
                break;
        }
    }

    public static void SeleccionarItem(IPlayer jugador)
    {
        List<IItem> inventario = jugador.Inventario;
        List<IPokemon> equipo = jugador.Equipo;

        Console.WriteLine("Selecciona un ítem para usar:");
        bool seleccionValida = false;
        while (!seleccionValida)
        {
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int indice) && indice > 0 && indice <= inventario.Count)
            {
                IItem itemSeleccionado = inventario[indice - 1];
                Console.WriteLine($"Has seleccionado: {itemSeleccionado.Nombre}");

                // Llamamos a ElegirPokemon para que el jugador seleccione un Pokémon
                IPokemon pokemonSeleccionado = ElegirPokemon(equipo);
                if (pokemonSeleccionado != null)
                {
                    jugador.UsarItem(indice - 1, pokemonSeleccionado); // Usar el ítem en el Pokémon elegido
                    seleccionValida = true; // Selección válida, terminamos el bucle
                }
            }
            else
            {
                Console.WriteLine("Selección de ítem inválida, por favor elige un número válido.");
            }
        }
    }

    public static IPokemon ElegirPokemon(List<IPokemon> equipo)
    {
        Console.WriteLine("Selecciona un Pokémon de tu equipo:");

        for (int i = 0; i < equipo.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {equipo[i].Name} - Salud: {equipo[i].Health}/{equipo[i].InicialHealth}");
        }

        bool seleccionValida = false;
        IPokemon pokemonSeleccionado = null;
        while (!seleccionValida)
        {
            string entradaPokemon = Console.ReadLine();
            if (int.TryParse(entradaPokemon, out int indicePokemon) && indicePokemon > 0 &&
                indicePokemon <= equipo.Count)
            {
                pokemonSeleccionado = equipo[indicePokemon - 1];
                Console.WriteLine($"Has seleccionado a {pokemonSeleccionado.Name}.");
                seleccionValida = true;
            }
            else
            {
                Console.WriteLine("Selección de Pokémon inválida. Por favor, intenta nuevamente.");
            }
        }

        return pokemonSeleccionado;
    }
}