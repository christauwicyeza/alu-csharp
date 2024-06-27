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
    /// <param name="name">The name of the entity. Default is "Door".</param>
    public Base(string name = "Door")
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

class Program
{
    static void Main(string[] args)
    {
        Door door = new Door();
        door.Interact();
    }
}
