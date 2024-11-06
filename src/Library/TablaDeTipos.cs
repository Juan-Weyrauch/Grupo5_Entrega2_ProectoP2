namespace ClassLibrary;

public class TablaDeTipos
{
    ITipoPokemon agua = new TipoPokemon("Agua");
    ITipoPokemon fuego = new TipoPokemon("Fuego");
    ITipoPokemon planta = new TipoPokemon("Planta");
    ITipoPokemon electrico = new TipoPokemon("Eléctrico");
    ITipoPokemon hielo = new TipoPokemon("Hielo");
    ITipoPokemon lucha = new TipoPokemon("Lucha");
    ITipoPokemon veneno = new TipoPokemon("Veneno");
    ITipoPokemon tierra = new TipoPokemon("Tierra");
    ITipoPokemon volador = new TipoPokemon("Volador");
    ITipoPokemon psiquico = new TipoPokemon("Psíquico");
    ITipoPokemon bicho = new TipoPokemon("Bicho");
    ITipoPokemon roca = new TipoPokemon("Roca");
    ITipoPokemon fantasma = new TipoPokemon("Fantasma");
    ITipoPokemon dragon = new TipoPokemon("Dragón");
    ITipoPokemon normal = new TipoPokemon("Normal");
 public void EstablecerRelaciones()
    {
        agua.EstablecerRelacionesElementales([fuego, tierra, roca], [agua, electrico, planta], []); // Agua es fuerte contra Fuego, Tierra, Roca; débil contra Agua, Eléctrico, Planta
fuego.EstablecerRelacionesElementales([planta, hielo, bicho], [agua, roca, tierra], []); // Fuego es fuerte contra Planta, Hielo, Bicho, Acero; débil contra Agua, Roca, Tierra
planta.EstablecerRelacionesElementales([agua, tierra, roca], [fuego, volador, bicho, veneno, hielo], []); // Planta es fuerte contra Agua, Tierra, Roca; débil contra Fuego, Volador, Bicho, Veneno, Hielo
electrico.EstablecerRelacionesElementales([agua, volador], [tierra], []); // Eléctrico es fuerte contra Agua y Volador; débil contra Tierra
hielo.EstablecerRelacionesElementales([planta, tierra, dragon, volador], [fuego, agua, lucha, roca], []); // Hielo es fuerte contra Planta, Tierra, Dragón, Volador; débil contra Fuego, Agua, Lucha, Acero, Roca
lucha.EstablecerRelacionesElementales([normal, hielo, roca ], [volador, psiquico], []); // Lucha es fuerte contra Normal, Hielo, Roca, Acero; débil contra Volador, Psíquico, Hada
veneno.EstablecerRelacionesElementales([planta], [agua, tierra, psiquico], []); // Veneno es fuerte contra Planta y Hada; débil contra Agua, Tierra, Psíquico
tierra.EstablecerRelacionesElementales([fuego, electrico, veneno, roca], [agua, planta, hielo], []); // Tierra es fuerte contra Fuego, Eléctrico, Veneno, Roca, Acero; débil contra Agua, Planta, Hielo
volador.EstablecerRelacionesElementales([planta, lucha, bicho], [electrico, roca, hielo], []); // Volador es fuerte contra Planta, Lucha, Bicho; débil contra Eléctrico, Roca, Hielo
psiquico.EstablecerRelacionesElementales([lucha, veneno], [], []); // Psíquico es fuerte contra Lucha y Veneno; débil contra Siniestro y Acero
bicho.EstablecerRelacionesElementales([planta, psiquico], [fuego, volador, roca], []); // Bicho es fuerte contra Planta, Psíquico, y Siniestro; débil contra Fuego, Volador, Roca
roca.EstablecerRelacionesElementales([fuego, hielo, volador, bicho], [agua, planta, tierra, lucha], []); // Roca es fuerte contra Fuego, Hielo, Volador, Bicho; débil contra Agua, Planta, Tierra, Lucha, Acero
fantasma.EstablecerRelacionesElementales([fantasma, psiquico], [normal], []); // Fantasma es fuerte contra Fantasma y Psíquico; inmune a Normal y Siniestro
dragon.EstablecerRelacionesElementales([dragon], [hielo], []); // Dragón es fuerte contra Dragón; débil contra Hielo, Hada, Acero
normal.EstablecerRelacionesElementales([], [lucha], [fantasma]); // Normal es débil contra Lucha; inmune a Fantasma
    }
}
// Instanciar todos los tipos de Pokémon


// Establecer las relaciones elementales

