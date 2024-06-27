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
    /// Delegate to calculate health changes.
    /// </summary>
    /// <param name="amount">The amount of health change.</param>
    public delegate void CalculateHealth(float amount);

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

    /// <summary>
    /// Inflicts damage on the player.
    /// </summary>
    /// <param name="damage">The amount of damage to inflict.</param>
    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            Console.WriteLine($"{name} takes 0 damage!");
        }
        else
        {
            Console.WriteLine($"{name} takes {damage} damage!");
            hp = Math.Max(0, hp - damage);
        }
    }

    /// <summary>
    /// Heals the player.
    /// </summary>
    /// <param name="heal">The amount of healing to apply.</param>
    public void HealDamage(float heal)
    {
        if (heal < 0)
        {
            Console.WriteLine($"{name} heals 0 HP!");
        }
        else
        {
            Console.WriteLine($"{name} heals {heal} HP!");
            hp = Math.Min(maxHp, hp + heal);
        }
    }
}
