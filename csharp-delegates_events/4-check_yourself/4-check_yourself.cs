using System;

/// <summary>
/// Class representing current health arguments.
/// </summary>
public class CurrentHPArgs : EventArgs
{
    /// <summary>
    /// Gets the current health value.
    /// </summary>
    public float CurrentHp { get; }

    /// <summary>
    /// Initializes a new instance of the CurrentHPArgs class.
    /// </summary>
    /// <param name="newHp">The new health value.</param>
    public CurrentHPArgs(float newHp)
    {
        CurrentHp = newHp;
    }
}

/// <summary>
/// Represents the different levels of modifiers for calculations.
/// </summary>
public enum Modifier
{
    /// <summary>
    /// Weak value.
    /// </summary>
    Weak,

    /// <summary>
    /// Base value.
    /// </summary>
    Base,

    /// <summary>
    /// Strong value.
    /// </summary>
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
/// Represents a player with health properties and methods.
/// </summary>
public class Player
{
    private string name;
    private float maxHp;
    private float hp;
    private string status;

    /// <summary>
    /// Event handler for health check events.
    /// </summary>
    public event EventHandler<CurrentHPArgs> HPCheck;

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
    public Player(string name = "Player", float maxHp = 100f)
    {
        if (maxHp <= 0)
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        else
        {
            this.maxHp = maxHp;
        }

        this.name = name;
        hp = this.maxHp;
        status = $"{name} is ready to go!";
        HPCheck += CheckStatus;
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
            float newHp = hp - damage;
            Console.WriteLine($"{name} takes {damage} damage!");
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
            float newHp = hp + heal;
            Console.WriteLine($"{name} heals {Math.Round(heal, 1)} HP!");
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

        HPCheck?.Invoke(this, new CurrentHPArgs(hp));
    }

    /// <summary>
    /// Applies a modifier to a base value.
    /// </summary>
    /// <param name="baseValue">The base value to modify.</param>
    /// <param name="modifier">The modifier to apply.</param>
    /// <returns>The modified value.</returns>
    public float ApplyModifier(float baseValue, Modifier modifier)
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

    /// <summary>
    /// Checks the player's status based on their current health.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        if (e.CurrentHp == maxHp)
        {
            Console.WriteLine($"{name} is in perfect health!");
        }
        else if (e.CurrentHp >= maxHp * 0.5 && e.CurrentHp < maxHp)
        {
            Console.WriteLine($"{name} is doing well!");
        }
        else if (e.CurrentHp >= maxHp * 0.25 && e.CurrentHp < maxHp * 0.5)
        {
            Console.WriteLine($"{name} isn't doing too great...");
        }
        else if (e.CurrentHp > 0 && e.CurrentHp < maxHp * 0.25)
        {
            Console.WriteLine($"{name} needs help!");
        }
        else if (e.CurrentHp == 0)
        {
            Console.WriteLine($"{name} is knocked out!");
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

class Programs
{
    static void Main()
    {
        // Create a player
        Player player1 = new Player("Alice", 120f);

        // Delegate instances
        Player.CalculateHealth damageDelegate = new Player.CalculateHealth(player1.TakeDamage);
        Player.CalculateHealth healDelegate = new Player.CalculateHealth(player1.HealDamage);

        // CalculateModifier delegate instance
        CalculateModifier modifierDelegate = new CalculateModifier(player1.ApplyModifier);

        // Apply modifiers to damage and heal values
        float baseDamage = 30f;
        float baseHeal = 20f;

        float weakDamage = modifierDelegate(baseDamage, Modifier.Weak);
        float strongHeal = modifierDelegate(baseHeal, Modifier.Strong);

        // Apply damage and heal using modified values
        damageDelegate(weakDamage);  // Output: Alice takes 15 damage!
        player1.PrintHealth();       // Output: Alice has 105 / 120 health

        healDelegate(strongHeal);    // Output: Alice heals 30 HP!
        player1.PrintHealth();       // Output: Alice has 120 / 120 health

        // Check status
        damageDelegate(60f);         // Output: Alice takes 60 damage!
        player1.PrintHealth();       // Output: Alice has 60 / 120 health
                                     // Output: Alice is doing well!

        damageDelegate(45f);         // Output: Alice takes 45 damage!
        player1.PrintHealth();       // Output: Alice has 15 / 120 health
                                     // Output: Alice needs help!

        healDelegate(20f);           // Output: Alice heals 20 HP!
        player1.PrintHealth();       // Output: Alice has 35 / 120 health
                                     // Output: Alice isn't doing too great...
    }
}
