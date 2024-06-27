using System;

/// <summary>
/// Represents a player with health properties and methods.
/// </summary>
public class Player
{
    private string name;
    private float maxHp;
    private float hp;

    /// <summary>
    /// Initializes a new instance of the Player class.
    /// </summary>
    /// <param name="name">The name of the player.</param>
    /// <param name="maxHp">The maximum health points of the player.</param>
    public Player(string name, float maxHp)
    {
        this.name = "Player";
        this.maxHp = 100f;
        this.hp = this.maxHp;

        if (maxHp > 0)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.hp = maxHp;
        }
        else
        {
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
    }

    /// <summary>
    /// Prints the current health status of the player.
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }
}
