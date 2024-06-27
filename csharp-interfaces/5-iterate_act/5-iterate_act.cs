using System;
using System.Collections.Generic;

/// <summary>
/// Interface for interactions
/// </summary>
public interface IInteractive
{
    /// <summary>
    /// Interact method.
    /// </summary>
    void Interact();
}

/// <summary>
/// Interface for breakable objects.
/// </summary>
public interface IBreakable
{
    /// <summary>
    /// Durability of the object.
    /// </summary>
    int durability { get; set; }

    /// <summary>
    /// Breaks the object.
    /// </summary>
    void Break();
}

/// <summary>
/// Interface for collectable objects.
/// </summary>
public interface ICollectable
{
    /// <summary>
    /// Indicates if the object has been collected.
    /// </summary>
    bool isCollected { get; set; }

    /// <summary>
    /// Collects the object.
    /// </summary>
    void Collect();
}

/// <summary>
/// Class representing a door.
/// </summary>
public class Door : Base, IInteractive
{
    /// <summary>
    /// Constructs a door with a given name.
    /// </summary>
    /// <param name="value">The name of the door.</param>
    public Door(string value = "Door")
    {
        name = value;
    }

    /// <summary>
    /// Interacts with the door.
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// Class representing a decoration object.
/// </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>
    /// Indicates if the decoration is a quest item.
    /// </summary>
    public bool isQuestItem = false;

    /// <summary>
    /// Durability of the decoration.
    /// </summary>
    public int durability { get; set; }

    /// <summary>
    /// Constructs a decoration object with specified parameters.
    /// </summary>
    /// <param name="CName">The name of the decoration.</param>
    /// <param name="durability">The durability of the decoration.</param>
    /// <param name="isQuestItem">Indicates if the decoration is a quest item.</param>
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

    /// <summary>
    /// Interacts with the decoration object.
    /// </summary>
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

    /// <summary>
    /// Breaks the decoration object.
    /// </summary>
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
/// Class representing a key object.
/// </summary>
public class Key : Base, ICollectable
{
    /// <summary>
    /// Indicates if the key has been collected.
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>
    /// Constructs a key object with specified parameters.
    /// </summary>
    /// <param name="name">The name of the key.</param>
    /// <param name="isCollected">Indicates if the key is initially collected.</param>
    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    /// <summary>
    /// Collects the key.
    /// </summary>
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
/// Class to perform actions on room objects.
/// </summary>
public class RoomObjects
{
    /// <summary>
    /// Iterates over a list of room objects and performs actions based on their type.
    /// </summary>
    /// <param name="roomObjects">List of room objects.</param>
    /// <param name="type">Type of action to perform (IInteractive, IBreakable, ICollectable).</param>
    public static void IterateAction(List<Base> roomObjects, Type? type)
    {
        foreach (var temp in roomObjects)
        {
            if (typeof(Door).GetInterfaces().Contains(type))
            {
                IInteractive? current = temp as IInteractive;
                current?.Interact();
            }
            else if (typeof(Decoration).GetInterfaces().Contains(type))
            {
                IBreakable? current = temp as IBreakable;
                current?.Break();
            }
            else if (typeof(Key).GetInterfaces().Contains(type))
            {
                ICollectable? current = temp as ICollectable;
                current?.Collect();
            }
        }
    }
}

/// <summary>
/// Base class for all objects.
/// </summary>
public abstract class Base
{
    /// <summary>
    /// The name of the object.
    /// </summary>
    public string? name { get; set; }

    /// <summary>
    /// Returns a string representation of the object.
    /// </summary>
    /// <returns>A string representation of the object.</returns>
    public override string ToString()
    {
        return $"{name} is a {this.GetType()}";
    }
}

/// <summary>
/// Main class to demonstrate object interactions.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method to run the program.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    public static void Main(string[] args)
    {
        // Creating instances of different objects
        Door door = new Door("Front Door");
        Decoration vase = new Decoration("Vase", 2, false);
        Key goldenKey = new Key("Golden Key");

        // List of room objects
        List<Base> roomObjects = new List<Base> { door, vase, goldenKey };

        // Performing interactions based on object types
        Console.WriteLine("--- Performing interactions in the room ---");
        RoomObjects.IterateAction(roomObjects, typeof(IInteractive));
        RoomObjects.IterateAction(roomObjects, typeof(IBreakable));
        RoomObjects.IterateAction(roomObjects, typeof(ICollectable));

        // Displaying object details
        Console.WriteLine("--- Object Details ---");
        foreach (var obj in roomObjects)
        {
            Console.WriteLine(obj);
        }
    }
}
