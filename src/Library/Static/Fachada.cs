using ClassLibrary;
using Library.Static;
using Library;
using System;
using ClassLibrary;

namespace ConsoleApplication
{
    public static class Fachada
    {
        public static void Start()
        {
            while (true)
            {
                ImpresoraDeTexto.StartPrint();

                if (int.TryParse(Console.ReadLine(), out int inicial))
                {
                    if (inicial == 1)
                    {
                        TablaDeTipos.CrearTabla();
                        FabricaAtaque.Ejecutar();
                        FabricaPokemon.CargarPokemons();

                        // Crear jugadores
                        List<IPlayer> players = new List<IPlayer>
                        {
                            CrearJugador(1),
                            CrearJugador(2)
                        };
                        
                        // Iniciar combate
                        Combate.DeterminarTurno(players[0], players[1]);
                    }
                    else if (inicial == 2)
                    {
                        ImpresoraDeTexto.EndPrint();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduce un número válido (1 o 2). Presiona cualquier tecla para intentar de nuevo...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, introduce 1 o 2.");
                }
            }
        }

        public static Player CrearJugador(int playerNumber)
        {
            int n = FabricaPokemon.DevolverTotal();
            string inputName = ImpresoraDeTexto.InsertarNombre(playerNumber);
            List<int> valuesForPokemons = new List<int>();

            ImpresoraDeTexto.mostrarListaPokemons(inputName);

            for (int j = 0; j < 6; j++)
            {
                ImpresoraDeTexto.selectYourPokemon(j);
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out int numberOfPokemonSelected))
                {
                    try
                    {
                        numberOfPokemonSelected = Calculator.GetValidatedNumber(1, n, numberOfPokemonSelected);
                        valuesForPokemons.Add(numberOfPokemonSelected);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ImpresoraDeTexto.Argumentos(0);
                        j--; // Reintenta la selección actual
                    }
                    catch (FormatException)
                    {
                        ImpresoraDeTexto.Argumentos(1);
                        j--; // Reintenta la selección actual
                    }
                }
                else
                {
                    ImpresoraDeTexto.Argumentos(1); // Mensaje de formato inválido
                    j--; // Reintenta la selección actual
                }
            }

            List<IPokemon> pokemonsCreados = FabricaPokemon.InstanciarPokes(valuesForPokemons);
            ImpresoraDeTexto.ImprimirEquipoDelJugador(pokemonsCreados);
            
            int eleccion;
            while (true)
            {
                Console.WriteLine("Elige tu Pokémon inicial:");
                if (int.TryParse(Console.ReadLine(), out eleccion))
                {
                    try
                    {
                        eleccion = Calculator.GetValidatedNumber(1, 6, eleccion);
                        eleccion--;
                        ImpresoraDeTexto.ImprimirPokemonSeleccionado(eleccion, pokemonsCreados);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ImpresoraDeTexto.Argumentos(0);
                    }
                }
                else
                {
                    ImpresoraDeTexto.Argumentos(1);
                }
            }

            return new Player(inputName, pokemonsCreados, eleccion);
        }

        /// <summary>
        /// Permite al jugador usar un ítem en el flujo del juego.
        /// </summary>
        public static void UsarItemEnCombate(IPlayer jugador)
        {
            Console.WriteLine("¿Qué ítem deseas usar?");
            int inventoryStatus = ImpresoraDeTexto.ImprimirItems(jugador.Inventario);

            if (inventoryStatus == 0) // Sin ítems
            {
                Console.WriteLine("No tienes ítems en tu inventario.");
                return;
            }

            if (int.TryParse(Console.ReadLine(), out int itemSeleccionado))
            {
                if (jugador.Inventario[itemSeleccionado - 1] is Revive)
                {
                    // Selecciona un Pokémon del Cementerio para revivir
                    IPokemon pokemonParaRevivir = ((Player)jugador).SeleccionarPokemonParaRevivir();
                    if (pokemonParaRevivir != null)
                    {
                        jugador.UsarItem(itemSeleccionado - 1, pokemonParaRevivir);

                        // Preguntar al usuario si quiere que el Pokémon revivido sea el nuevo titular
                        Console.WriteLine("¿Quieres que el Pokémon revivido sea el nuevo titular? (S/N)");
                        string respuesta = Console.ReadLine()?.ToUpper();
                        if (respuesta == "S")
                        {
                            jugador.SelectedPokemon = pokemonParaRevivir;
                            Console.WriteLine($"{pokemonParaRevivir.Name} ahora es el Pokémon titular.");
                        }
                    }
                }
                else
                {
                    // Seleccionar un Pokémon del equipo para aplicar otros ítems
                    IPokemon objetivo = ((Player)jugador).SeleccionarPokemonDelEquipo();
                    if (objetivo != null)
                    {
                        jugador.UsarItem(itemSeleccionado - 1, objetivo);
                    }
                }
            }
            else
            {
                Console.WriteLine("Selección de ítem no válida.");
            }
        }
    }
}
