#nullable enable

using System;

/// <summary>
/// Modifier used with delegates
/// </summary>
public enum Modifier
{
    /// <summary> 
    /// Weak default value should be 0.5 
    /// </summary>
    Weak,
    /// <summary> 
    /// Base default value should be 1 
    /// </summary>
    Base,
    /// <summary> 
    /// Strong default value should be 1.5 
    /// </summary>
    Strong
}

/// <summary>
/// Player's CalculateHealth Delegate
/// </summary>
/// <param name="amount">Amount for health</param>
public delegate void CalculateHealth(float amount);

/// <summary>
/// Calculate Modifier Delegate
/// </summary>
/// <param name="baseValue">Base value</param>
/// <param name="modifier">Modifier: Weak, Base, Strong</param>
/// <returns>Returns a modified value</returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// Player class
/// </summary>
public class Player
{
    /// <summary>
    /// Event handler for CurrentHPArgs
    /// </summary>
    public event EventHandler<CurrentHPArgs>? HPCheck;

    // Player's name
    private string name { get; set; }
    // Player's max hp
    private float maxHp { get; set; }
    // Player's hp
    private float hp { get; set; }
    // Player's status
    private string status { get; set; }

    /// <summary>
    /// Player constructor
    /// </summary>
    /// <param name="name">Player's name</param>
    /// <param name="maxHp">Player's max hp</param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        if (maxHp <= 0)
        {
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
            maxHp = 100f;
        }
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.status = $"{name} is ready to go!";
        HPCheck += CheckStatus;
    }

    /// <summary>
    /// Prints the name and current health of the player
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    /// <summary>
    /// Player takes damage
    /// </summary>
    /// <param name="damage">Amount of damage taken</param>
    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            Console.WriteLine($"{name} takes 0 damage!");
            return;
        }
        Console.WriteLine($"{name} takes {damage} damage!");
        this.ValidateHP(this.hp - damage);
    }

    /// <summary>
    /// Player heals
    /// </summary>
    /// <param name="heal">Amount of heals received</param>
    public void HealDamage(float heal)
    {
        if (heal < 0)
        {
            Console.WriteLine($"{name} heals 0 HP!");
            return;
        }
        Console.WriteLine($"{name} heals {heal} HP!");
        this.ValidateHP(this.hp + heal);
    }

    /// <summary>
    /// Validates and sets the new player's hp
    /// </summary>
    /// <param name="newHp">New hp value</param>
    public void ValidateHP(float newHp)
    {
        if (newHp < 0)
        {
            this.hp = 0;
        }
        else if (newHp >= maxHp)
        {
            this.hp = maxHp;
        }
        else
        {
            this.hp = newHp;
        }
        CheckStatus(HPCheck, new CurrentHPArgs(this.hp));
    }

    /// <summary>
    /// Applies a modifier to the base value
    /// </summary>
    /// <param name="baseValue">Base value to apply</param>
    /// <param name="modifier">Modifier: Weak, Base, Strong</param>
    /// <returns>Modified value</returns>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        float modifiedVal = baseValue;
        switch (modifier)
        {
            case Modifier.Weak:
                modifiedVal = baseValue * 0.5f;
                break;
            case Modifier.Base:
                modifiedVal = baseValue * 1f;
                break;
            case Modifier.Strong:
                modifiedVal = baseValue * 1.5f;
                break;
        }
        return modifiedVal;
    }

    private void CheckStatus(object? sender, CurrentHPArgs e)
    {
        if (e.currentHp == this.maxHp)
            status = $"{name} is in perfect health!";
        else if (e.currentHp >= (this.maxHp * 0.5) && e.currentHp < this.maxHp)
            status = $"{name} is doing well!";
        else if (e.currentHp >= (this.maxHp * 0.25) && e.currentHp < this.maxHp)
            status = $"{name} isn't doing too great...";
        else if (e.currentHp > 0 && e.currentHp < (this.maxHp * 0.25))
            status = $"{name} needs help!";
        else if (e.currentHp <= 0)
            status = $"{name} is knocked out!";
        Console.WriteLine(status);
    }
}

/// <summary>
/// Current HP Args
/// </summary>
public class CurrentHPArgs : EventArgs
{
    /// <summary>
    /// Current hp value
    /// </summary>
    public readonly float currentHp;

    /// <summary>
    /// Constructor for CurrentHPArgs
    /// </summary>
    /// <param name="newHp">New hp value</param>
    public CurrentHPArgs(float newHp)
    {
        this.currentHp = newHp;
    }
}
