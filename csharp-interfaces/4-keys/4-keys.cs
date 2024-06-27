using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a Door instance
        Door door = new Door("Front Door");

        // Interact with the door
        Console.WriteLine("--- Interacting with the Door ---");
        door.Interact();
        Console.WriteLine();

        // Create a Decoration instance
        Decoration decoration = new Decoration("Vase", 2, false);

        // Interact with the decoration
        Console.WriteLine("--- Interacting with the Decoration ---");
        decoration.Interact();
        decoration.Break();
        decoration.Break();
        decoration.Break();
        Console.WriteLine();

        // Create a Key instance
        Key key = new Key("Golden Key");

        // Collect the key
        Console.WriteLine("--- Collecting the Key ---");
        key.Collect();
        key.Collect();
        Console.WriteLine();

        // Display object details
        Console.WriteLine("--- Object Details ---");
        Console.WriteLine(door);
        Console.WriteLine(decoration);
        Console.WriteLine(key);
    }
}

/// <summary>
/// Interface for interactions
/// </summary>
public interface IInteractive
{
    void Interact();
}

/// <summary>
/// Interface for breakables
/// </summary>
public interface IBreakable
{
    int durability { get; set; }
    void Break();
}

/// <summary>
/// Interface for collectable objects
/// </summary>
public interface ICollectable
{
    bool isCollected { get; set; }
    void Collect();
}

/// <summary>
/// Door class for controlling a door
/// </summary>
public class Door : Base, IInteractive
{
    public Door(string value = "Door")
    {
        name = value;
    }

    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// Decoration class definition
/// </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    public bool isQuestItem = false;
    public int durability { get; set; }

    public Decoration(string CName = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        this.isQuestItem = isQuestItem;
        name = CName;
        if (durability <= 0)
        {
            throw new Exception("Durability must be greater than 0");
        }
        else
        {
            this.durability = durability;
        }
    }

    public void Interact()
    {
        if (durability <= 0)
        {
            Console.WriteLine($"The {name} has been broken.");
        }
        else if (isQuestItem)
        {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        }
        else
        {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

    public void Break()
    {
        this.durability--;

        if (durability > 0)
        {
            Console.WriteLine($"You hit the {name}. It cracks.");
        }

        if (durability == 0)
        {
            Console.WriteLine($"You smash the {name}. What a mess.");
        }

        if (durability < 0)
        {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

/// <summary>
/// Key class for representing a collectable key
/// </summary>
public class Key : Base, ICollectable
{
    public bool isCollected { get; set; }

    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    public void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
        else
        {
            Console.WriteLine($"You have already picked up the {name}.");
        }
    }
}

/// <summary>
/// Base class for everything
/// </summary>
public abstract class Base
{
    public string? name { get; set; }

    public override string ToString()
    {
        return $"{name} is a {this.GetType()}";
    }
}
