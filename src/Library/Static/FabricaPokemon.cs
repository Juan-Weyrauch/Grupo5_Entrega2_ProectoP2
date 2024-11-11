namespace ClassLibrary;

public static class FabricaPokemon
{   /// <summary>
    /// Los registros son clases que tienen la informacion de la creacion de cada pokemon. Estos tienen un metodo que
    /// instancia los pokemons como objetos y los envia hacia las listas, se deberia hacer con visitor.
    /// </summary>
    
    private  static Dictionary<int, IRegistroPokemon> PokedexPokemon =  new() ;
    
    /// <summary>
    /// Carga los Pokémon en la Pokedex. Este método crea los registros de Pokémon y los almacena
    /// en el diccionario <c>PokedexPokemon</c> utilizando el <see cref="Registro"/> y el <see cref="FabricaAtaque"/>.
    /// </summary>
    public static void CargarPokemons()// Para entender mejor leer IRegistro y Registro. 
    {
        
       PokedexPokemon.Add(1, new Registro("Bulbasaur", 3, 3, 4, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(2, new Registro("Ivysaur", 6, 6, 6, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(3, new Registro("Venusaur", 10, 8, 8, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(4, new Registro("Charmander", 4, 2, 2, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(5, new Registro("Charmeleon", 7, 6, 6, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(6, new Registro("Charizard", 10, 9, 8, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(7, new Registro("Squirtle", 3, 4, 5, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(8, new Registro("Wartortle", 6, 6, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(9, new Registro("Blastoise", 9, 9, 10, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(10, new Registro("Caterpie", 1, 1, 1, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(11, new Registro("Metapod", 2, 1, 3, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(12, new Registro("Butterfree", 5, 4, 3, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(13, new Registro("Weedle", 2, 1, 1, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(14, new Registro("Kakuna", 2, 1, 2, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(15, new Registro("Beedrill", 6, 4, 3, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(16, new Registro("Pidgey", 2, 2, 2, "Volador", FabricaAtaque.GenerarAtaquesRandom("Volador")));
PokedexPokemon.Add(17, new Registro("Pidgeotto", 5, 5, 4, "Volador", FabricaAtaque.GenerarAtaquesRandom("Volador")));
PokedexPokemon.Add(18, new Registro("Pidgeot", 8, 7, 6, "Volador", FabricaAtaque.GenerarAtaquesRandom("Volador")));
PokedexPokemon.Add(19, new Registro("Rattata", 3, 2, 2, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(20, new Registro("Raticate", 6, 5, 5, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(21, new Registro("Spearow", 3, 3, 2, "Volador", FabricaAtaque.GenerarAtaquesRandom("Volador")));
PokedexPokemon.Add(22, new Registro("Fearow", 7, 6, 5, "Volador", FabricaAtaque.GenerarAtaquesRandom("Volador")));
PokedexPokemon.Add(23, new Registro("Ekans", 4, 3, 3, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(24, new Registro("Arbok", 8, 7, 6, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(25, new Registro("Pikachu", 5, 3, 2, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(26, new Registro("Raichu", 9, 8, 6, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(27, new Registro("Sandshrew", 4, 5, 5, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(28, new Registro("Sandslash", 7, 8, 8, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(29, new Registro("Nidoran♀", 3, 3, 3, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(30, new Registro("Nidorina", 6, 5, 5, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(31, new Registro("Nidoqueen", 9, 8, 8, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(32, new Registro("Nidoran♂", 3, 3, 3, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(33, new Registro("Nidorino", 6, 5, 5, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(34, new Registro("Nidoking", 9, 8, 8, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(35, new Registro("Clefairy", 4, 3, 4, "Hada", FabricaAtaque.GenerarAtaquesRandom("Hada")));
PokedexPokemon.Add(36, new Registro("Clefable", 8, 7, 7, "Hada", FabricaAtaque.GenerarAtaquesRandom("Hada")));
PokedexPokemon.Add(37, new Registro("Vulpix", 3, 3, 3, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(38, new Registro("Ninetales", 7, 7, 6, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(39, new Registro("Jigglypuff", 2, 2, 2, "Hada", FabricaAtaque.GenerarAtaquesRandom("Hada")));
PokedexPokemon.Add(40, new Registro("Wigglytuff", 6, 5, 5, "Hada", FabricaAtaque.GenerarAtaquesRandom("Hada")));
PokedexPokemon.Add(41, new Registro("Zubat", 3, 2, 2, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(42, new Registro("Golbat", 7, 6, 6, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(43, new Registro("Oddish", 3, 2, 3, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(44, new Registro("Gloom", 6, 5, 5, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(45, new Registro("Vileplume", 9, 7, 7, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(46, new Registro("Paras", 4, 2, 3, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(47, new Registro("Parasect", 7, 6, 5, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(48, new Registro("Venonat", 3, 3, 4, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(49, new Registro("Venomoth", 6, 5, 5, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(50, new Registro("Diglett", 2, 3, 2, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(51, new Registro("Dugtrio", 6, 7, 5, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(52, new Registro("Meowth", 3, 3, 3, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(53, new Registro("Persian", 6, 6, 5, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(54, new Registro("Psyduck", 4, 3, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(55, new Registro("Golduck", 8, 7, 6, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(56, new Registro("Mankey", 5, 4, 3, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(57, new Registro("Primeape", 9, 7, 6, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(58, new Registro("Growlithe", 5, 4, 4, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(59, new Registro("Arcanine", 9, 8, 7, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(60, new Registro("Poliwag", 3, 3, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(61, new Registro("Poliwhirl", 6, 5, 5, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(62, new Registro("Poliwrath", 9, 8, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(63, new Registro("Abra", 2, 1, 1, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(64, new Registro("Kadabra", 5, 4, 3, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(65, new Registro("Alakazam", 9, 8, 5, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(66, new Registro("Machop", 5, 4, 3, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(67, new Registro("Machoke", 8, 6, 5, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(68, new Registro("Machamp", 10, 9, 7, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(69, new Registro("Bellsprout", 3, 2, 3, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(70, new Registro("Weepinbell", 6, 5, 4, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(71, new Registro("Victreebel", 9, 7, 6, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(72, new Registro("Tentacool", 3, 4, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(73, new Registro("Tentacruel", 8, 6, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(74, new Registro("Geodude", 4, 6, 5, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(75, new Registro("Graveler", 7, 8, 7, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(76, new Registro("Golem", 10, 10, 9, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(77, new Registro("Ponyta", 5, 4, 4, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(78, new Registro("Rapidash", 9, 7, 7, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(79, new Registro("Slowpoke", 3, 4, 4, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(80, new Registro("Slowbro", 7, 8, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(81, new Registro("Magnemite", 4, 3, 3, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(82, new Registro("Magneton", 7, 6, 6, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(83, new Registro("Farfetch'd", 5, 4, 4, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(84, new Registro("Doduo", 4, 4, 3, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(85, new Registro("Dodrio", 8, 7, 6, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(86, new Registro("Seel", 4, 5, 4, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(87, new Registro("Dewgong", 8, 8, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(88, new Registro("Grimer", 3, 3, 4, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(89, new Registro("Muk", 7, 6, 6, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(90, new Registro("Shellder", 3, 4, 4, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(91, new Registro("Cloyster", 8, 9, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(92, new Registro("Gastly", 3, 2, 3, "Fantasma", FabricaAtaque.GenerarAtaquesRandom("Fantasma")));
PokedexPokemon.Add(93, new Registro("Haunter", 6, 4, 4, "Fantasma", FabricaAtaque.GenerarAtaquesRandom("Fantasma")));
PokedexPokemon.Add(94, new Registro("Gengar", 9, 7, 6, "Fantasma", FabricaAtaque.GenerarAtaquesRandom("Fantasma")));
PokedexPokemon.Add(95, new Registro("Onix", 5, 9, 5, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(96, new Registro("Drowzee", 4, 4, 4, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(97, new Registro("Hypno", 8, 7, 6, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(98, new Registro("Krabby", 4, 4, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(99, new Registro("Kingler", 8, 7, 6, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(100, new Registro("Voltorb", 4, 4, 3, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(101, new Registro("Electrode", 7, 6, 6, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(102, new Registro("Exeggcute", 3, 3, 4, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(103, new Registro("Exeggutor", 8, 8, 7, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(104, new Registro("Cubone", 4, 5, 4, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(105, new Registro("Marowak", 7, 8, 6, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(106, new Registro("Hitmonlee", 8, 5, 5, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(107, new Registro("Hitmonchan", 8, 5, 5, "Lucha", FabricaAtaque.GenerarAtaquesRandom("Lucha")));
PokedexPokemon.Add(108, new Registro("Lickitung", 5, 5, 6, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(109, new Registro("Koffing", 4, 4, 4, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(110, new Registro("Weezing", 7, 7, 6, "Veneno", FabricaAtaque.GenerarAtaquesRandom("Veneno")));
PokedexPokemon.Add(111, new Registro("Rhyhorn", 6, 7, 6, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(112, new Registro("Rhydon", 9, 9, 8, "Tierra", FabricaAtaque.GenerarAtaquesRandom("Tierra")));
PokedexPokemon.Add(113, new Registro("Chansey", 2, 10, 1, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(114, new Registro("Tangela", 5, 5, 5, "Planta", FabricaAtaque.GenerarAtaquesRandom("Planta")));
PokedexPokemon.Add(115, new Registro("Kangaskhan", 7, 7, 6, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(116, new Registro("Horsea", 4, 3, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(117, new Registro("Seadra", 7, 6, 6, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(118, new Registro("Goldeen", 4, 4, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(119, new Registro("Seaking", 7, 6, 5, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(120, new Registro("Staryu", 4, 3, 3, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(121, new Registro("Starmie", 7, 6, 6, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(122, new Registro("Mr. Mime", 6, 5, 5, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(123, new Registro("Scyther", 7, 6, 6, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(124, new Registro("Jynx", 6, 5, 4, "Hielo", FabricaAtaque.GenerarAtaquesRandom("Hielo")));
PokedexPokemon.Add(125, new Registro("Electabuzz", 7, 5, 5, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(126, new Registro("Magmar", 7, 5, 5, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(127, new Registro("Pinsir", 7, 7, 6, "Bicho", FabricaAtaque.GenerarAtaquesRandom("Bicho")));
PokedexPokemon.Add(128, new Registro("Tauros", 7, 6, 5, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(129, new Registro("Magikarp", 1, 1, 1, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(130, new Registro("Gyarados", 10, 8, 8, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(131, new Registro("Lapras", 8, 7, 8, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(132, new Registro("Ditto", 3, 3, 3, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(133, new Registro("Eevee", 4, 4, 4, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(134, new Registro("Vaporeon", 7, 7, 7, "Agua", FabricaAtaque.GenerarAtaquesRandom("Agua")));
PokedexPokemon.Add(135, new Registro("Jolteon", 7, 7, 7, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(136, new Registro("Flareon", 7, 7, 7, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(137, new Registro("Porygon", 5, 5, 5, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(138, new Registro("Omanyte", 4, 6, 4, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(139, new Registro("Omastar", 7, 8, 7, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(140, new Registro("Kabuto", 4, 5, 4, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(141, new Registro("Kabutops", 8, 7, 6, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(142, new Registro("Aerodactyl", 8, 6, 6, "Roca", FabricaAtaque.GenerarAtaquesRandom("Roca")));
PokedexPokemon.Add(143, new Registro("Snorlax", 9, 10, 10, "Normal", FabricaAtaque.GenerarAtaquesRandom("Normal")));
PokedexPokemon.Add(144, new Registro("Articuno", 10, 9, 8, "Hielo", FabricaAtaque.GenerarAtaquesRandom("Hielo")));
PokedexPokemon.Add(145, new Registro("Zapdos", 10, 9, 8, "Eléctrico", FabricaAtaque.GenerarAtaquesRandom("Eléctrico")));
PokedexPokemon.Add(146, new Registro("Moltres", 10, 9, 8, "Fuego", FabricaAtaque.GenerarAtaquesRandom("Fuego")));
PokedexPokemon.Add(147, new Registro("Dratini", 4, 4, 4, "Dragón", FabricaAtaque.GenerarAtaquesRandom("Dragón")));
PokedexPokemon.Add(148, new Registro("Dragonair", 7, 7, 7, "Dragón", FabricaAtaque.GenerarAtaquesRandom("Dragón")));
PokedexPokemon.Add(149, new Registro("Dragonite", 10, 9, 8, "Dragón", FabricaAtaque.GenerarAtaquesRandom("Dragón")));
PokedexPokemon.Add(150, new Registro("Mewtwo", 10, 10, 10, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
PokedexPokemon.Add(151, new Registro("Mew", 10, 10, 10, "Psíquico", FabricaAtaque.GenerarAtaquesRandom("Psíquico")));
// Repetir este patrón para los 151 Pokémon de la primera generación...

    }
    /// <summary>
    /// Devuelve una lista de nombres de Pokémon desde la Pokedex.
    /// Utiliza el patrón Visitor para obtener el nombre de cada Pokémon sin modificar sus clases individuales.
    /// </summary>
    /// <returns>Una lista de nombres de Pokémon en formato "número) nombre".</returns>
    public static List<string> DevolverNombresPokedex()
    {
        List<string> PokemonsTotales = new List<string>();
        InfoVisitor infoVisitor = new();  // Usamos el visitor para obtener la información
    
        // Recorremos la Pokedex y extraemos los nombres usando el visitor
        for (int i = 1; i <= PokedexPokemon.Count; i++)  // Cambié el bucle para incluir el último índice
        {
            string num = i.ToString();
            // Aquí el visitor extrae solo el nombre del registro
            string nombre = PokedexPokemon[i].AcceptObtenerNombre(infoVisitor); // esto tiene que de alguna manera dar los nombres.
            PokemonsTotales.Add($"{num}) {nombre}");
        }

        return PokemonsTotales;
    }
    /// <summary>
    /// Instancia una lista de Pokémon para un jugador específico utilizando los números de la Pokedex.
    /// Cada número de Pokémon se corresponde con un registro de la Pokedex que se instanciará como un objeto <see cref="IPokemon"/>.
    /// </summary>
    /// <param name="entrada">Lista de números de Pokémon seleccionados por el jugador.</param>
    /// <returns>Lista de objetos <see cref="IPokemon"/> correspondientes a los números proporcionados.</returns>
    public static List<IPokemon> InstanciarPokes(List<int> entrada) // Tiene que llegarle los valores del player.
    {// Falta traer la info desde jugador hacia aca. 
        List<IPokemon> PokemonsTemporal  = new List<IPokemon>();
        InfoVisitor InfoVisitor = new();
        foreach (int numero in entrada)
        {
            IPokemon pokemontemp = PokedexPokemon[numero].AcceptCrearPokemon(InfoVisitor); // Esto tiene que ir creando los Pokemons.
            PokemonsTemporal.Add(pokemontemp); // Son muchos puntos probablemente aplicar visitor
        }

        return PokemonsTemporal;

    }
    /// <summary>
    /// Devuelve el número total de Pokémon en la Pokedex.
    /// </summary>
    /// <returns>El número total de Pokémon en la Pokedex.</returns>
    public static int DevolverTotal()
    {
        return (PokedexPokemon.Count);
    }
}
// Bulbasur.
// Tipo
// Ataque
// Daño 