namespace ClassLibrary;
    public interface IItem
    {
        string Name { get; }
        void Use(Player player);
    }

    public class SuperPotion : IItem
    {
        public string Name => "Súper Poción";

        public void Use(Player player)
        {
            player.Heal(70); // Recupera 70 puntos de HP
        }
    }

    public class Revive : IItem
    {
        public string Name => "Revivir";

        public void Use(Player player)
        {
            player.Revive(0.5); // Revive con el 50% de HP total
        }
    }

    public class FullRestore : IItem
    {
        public string Name => "Cura Total";

        public void Use(Player player)
        {
            player.RemoveStatusEffects(); // Elimina todos los efectos de estado
        }
    }