namespace ClassLibrary;

public class Pokemon: IPokemon
{
    public string Name { get; }
    public int damage { get; set; }
    public int defense { get; set; }
    public int health { get; set; }
    public ITipoPokemon TipoPokemon { get; }

    Pokemon(string name, int damage, int defense, int health)
    {
        Name = name;
        damage = damage;
        defense = defense;
        health = health; 
        //ITipoPokemon tipoPokemon = tipoPokemon;
    }
}