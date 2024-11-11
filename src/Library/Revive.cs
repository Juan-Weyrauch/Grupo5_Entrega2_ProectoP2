namespace ClassLibrary
{
    public class Revive : IItem
    {
        public string Nombre => "Revive";

        public void Usar(IPokemon pokemon)
        {
            if (pokemon.Health == 0)
            {
                int vidaRevive = pokemon.InicialHealth / 2;
                pokemon.Curar(vidaRevive); // Restaura la salud a la mitad de la salud inicial
                Console.WriteLine($"{pokemon.Name} ha sido revivido con {vidaRevive} puntos de vida.");
            }
            else
            {
                Console.WriteLine($"{pokemon.Name} aún no está debilitado y no puede usar Revive.");
            }
        }
    }
}