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
            float newHp = hp - damage;
            ValidateHP(newHp);
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
            float newHp = hp + heal;
            ValidateHP(newHp);
        }
    }

    /// <summary>
    /// Validates and sets the new value of hp.
    /// </summary>
    /// <param name="newHp">The new health value to validate and set.</param>
    public void ValidateHP(float newHp)
    {
        if (newHp < 0)
        {
            hp = 0;
        }
        else if (newHp > maxHp)
        {
            hp = maxHp;
        }
        else
        {
            hp = newHp;
        }
    }
}

/// <summary>
/// Represents the different levels of modifiers for calculations.
/// </summary>
public enum Modifier
{
    Weak,
    Base,
    Strong
}

/// <summary>
/// Delegate to calculate modified values.
/// </summary>
/// <param name="baseValue">The base value to modify.</param>
/// <param name="modifier">The modifier to apply.</param>
/// <returns>The modified value.</returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// Applies a modifier to a base value.
/// </summary>
/// <param name="baseValue">The base value to modify.</param>
/// <param name="modifier">The modifier to apply.</param>
/// <returns>The modified value.</returns>
public static float ApplyModifier(float baseValue, Modifier modifier)
{
    switch (modifier)
    {
        case Modifier.Weak:
            return baseValue * 0.5f;
        case Modifier.Base:
            return baseValue;
        case Modifier.Strong:
            return baseValue * 1.5f;
        default:
            throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null);
    }
}
