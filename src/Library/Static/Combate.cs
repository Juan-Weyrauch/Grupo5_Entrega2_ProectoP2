using ClassLibrary;

namespace Library;

public  static class Combate
{
    static IVisitor InfoVisitor = new InfoVisitor();
    //public void Combatir(Player juagor1, Player, jugador2)
   // {}

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
               Random par = new Random();
               Random par2 = new Random();
               int prob = par.Next(1, 5);
               int prob2 = par2.Next(1, 5);

               if (par == par2)
               {
                   // Debe perder el turno
               }
               
               break;
           
           case 4: // Dormido
               Random dor = new Random();
               Random dor2 = new Random();
               int pdor = dor.Next(1, i);
               int pdor2 = dor2.Next();
               //creo de deberia hacer un for o un while que vaya restando turnos hasta 4
               // para revisar si esta dormido si el numero es igual sale y se despierta?
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
}
