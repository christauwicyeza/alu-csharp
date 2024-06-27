using System;

/// <summary>
/// Interface for interactive objects.
/// </summary>
public interface IInteractive
{
    /// <summary>
    /// Defines interaction behavior.
    /// </summary>
    void Interact();
}

/// <summary>
/// Interface for breakable objects.
/// </summary>
public interface IBreakable
{
    /// <summary>
    /// Gets or sets the durability of the object.
    /// </summary>
    int Durability { get; set; }

    /// <summary>
    /// Method to define breaking behavior.
    /// </summary>
    void Break();
}

/// <summary>
/// Abstract base class representing an entity with a name.
/// </summary>
public abstract class Base
{
    /// <summary>
    /// Gets or sets the name of the entity.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Initializes a new instance of the Base class with a name.
    /// </summary>
    /// <param name="name">The name of the entity. Default is "Decoration".</param>
    public Base(string name = "Decoration")
    {
        Name = name;
    }

    /// <summary>
    /// Returns a string representation of the object.
    /// </summary>
    /// <returns>A string in the format: "{Name} is a {Type}".</returns>
    public override string ToString()
    {
        return $"{Name} is a {GetType().Name}";
    }
}

/// <summary>
/// Decoration class inheriting from Base, IInteractive, and IBreakable.
/// </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>
    /// Gets or sets whether the object is a quest item.
    /// </summary>
    public bool IsQuestItem { get; set; }

    private int durability;

    /// <summary>
    /// Gets or sets the durability of the decoration.
    /// </summary>
    public int Durability
    {
        get { return durability; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Durability must be greater than 0");
            durability = value;
        }
    }

    /// <summary>
    /// Constructor for initializing the Decoration class.
    /// </summary>
    /// <param name="name">The name of the decoration. Default is "Decoration".</param>
    /// <param name="durability">The durability of the decoration. Default is 1.</param>
    /// <param name="isQuestItem">Whether the decoration is a quest item. Default is false.</param>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
        : base(name)
    {
        Durability = durability;
        IsQuestItem = isQuestItem;
    }

    /// <summary>
    /// Method to interact with the decoration.
    /// </summary>
    public void Interact()
    {
        if (Durability <= 0)
        {
            Console.WriteLine($"The {Name} has been broken.");
        }
        else if (IsQuestItem)
        {
            Console.WriteLine($"You look at the {Name}. There's a key inside.");
        }
        else
        {
            Console.WriteLine($"You look at the {Name}. Not much to see here.");
        }
    }

    /// <summary>
    /// Method to break the decoration.
    /// </summary>
    public void Break()
    {
        Durability--;

        if (Durability > 0)
        {
            Console.WriteLine($"You hit the {Name}. It cracks.");
        }
        else if (Durability == 0)
        {
            Console.WriteLine($"You smash the {Name}. What a mess.");
        }
        else
        {
            Console.WriteLine($"The {Name} is already broken.");
        }
    }
}
