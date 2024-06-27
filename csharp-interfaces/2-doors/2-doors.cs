using System;
using System.Collections.Generic;

/// <summary>
/// Interface for interactions.
/// </summary>
public interface IInteractive
{
    /// <summary>
    /// Interact method definition.
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
    int durability { get; set; }

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
    bool isCollected { get; set; }

    /// <summary>
    /// Method to define collecting behavior.
    /// </summary>
    void Collect();
}

/// <summary>
/// Door class for controlling a door.
/// </summary>
public class Door : Base, IInteractive
{
    /// <summary>
    /// Constructor for initializing a door with a name.
    /// </summary>
    /// <param name="value">The name of the door.</param>
    public Door(string value = "Door")
    {
        name = value;
    }

    /// <summary>
    /// Defines interaction behavior for the door.
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// Abstract base class for all entities.
/// </summary>
public abstract class Base
{
    /// <summary>
    /// Gets or sets the name of the entity.
    /// </summary>
    public String? name { get; set; }

    /// <summary>
    /// Returns a string representation of the entity.
    /// </summary>
    /// <returns>A formatted string indicating the name and type of the entity.</returns>
    public override String ToString()
    {
        return $"{name} is a {this.GetType()}";
    }
}
