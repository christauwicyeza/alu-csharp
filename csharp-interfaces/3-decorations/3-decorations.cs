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
/// Interface for collectable objects.
/// </summary>
public interface ICollectable
{
    /// <summary>
    /// Gets or sets whether the object is collected.
    /// </summary>
    bool IsCollected { get; set; }

    /// <summary>
    /// Method to define collecting behavior.
    /// </summary>
    void Collect();
}

/// <summary>
/// Class representing a Door, inheriting from Base and implementing IInteractive.
/// </summary>
public class Door : Base, IInteractive
{
    /// <summary>
    /// Initializes a new instance of the Door class with a name.
    /// </summary>
    /// <param name="name">The name of the door. Default is "Door".</param>
    public Door(string name = "Door") : base(name)
    {
    }

    /// <summary>
    /// Defines the interaction behavior for the door.
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {Name}. It's locked.");
    }
}

/// <summary>
/// Class representing a Decoration, inheriting from Base, IInteractive, and IBreakable.
/// </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>
    /// Gets or sets whether the decoration is a quest item.
    /// </summary>
    public bool IsQuestItem { get; set; }

    /// <summary>
    /// Gets or sets the durability of the decoration.
    /// </summary>
    public int Durability { get; set; }

    /// <summary>
    /// Initializes a new instance of the Decoration class with a name, durability, and quest item status.
    /// </summary>
    /// <param name="name">The name of the decoration. Default is "Decoration".</param>
    /// <param name="durability">The durability of the decoration. Default is 1.</param>
    /// <param name="isQuestItem">Whether the decoration is a quest item. Default is false.</param>
    /// <exception cref="ArgumentException">Thrown when durability is less than or equal to 0.</exception>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false) : base(name)
    {
        if (durability <= 0)
        {
            throw new ArgumentException("Durability must be greater than 0.", nameof(durability));
        }

        Durability = durability;
        IsQuestItem = isQuestItem;
    }

    /// <summary>
    /// Defines the interaction behavior for the decoration.
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
    /// Defines the breaking behavior for the decoration.
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
    /// <param name="name">The name of the entity. Default is "Base".</param>
    public Base(string name = "Base")
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

class Program
{
    static void Main(string[] args)
    {
        // Example usage of Door
        Door door = new Door("Front Door");
        Console.WriteLine(door);
        door.Interact();

        // Example usage of Decoration
        Decoration teacup = new Decoration("Teacup", 2, false);
        Console.WriteLine(teacup);
        teacup.Interact();
        teacup.Break();
        teacup.Break();
        teacup.Break();
        teacup.Break();
        teacup.Break();
        teacup.Break();
    }
}
