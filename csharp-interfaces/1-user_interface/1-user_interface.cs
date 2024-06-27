using System;

/// <summary>
/// Abstract base class.
/// </summary>
public abstract class Base
{
    // Name of the entity
    public string? name { get; set; }

    /// <summary>
    /// Returns a string representation of the object.
    /// </summary>
    public override string ToString()
    {
        return $"{name} is a {this.GetType().Name}";
    }
}

/// <summary>
/// Interface for interactive objects.
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
    // Durability of the object
    int durability { get; set; }

    /// <summary>
    /// Break method.
    /// </summary>
    void Break();
}

/// <summary>
/// Interface for collectable objects.
/// </summary>
public interface ICollectable
{
    // Indicates if the object is collected
    bool isCollected { get; set; }

    /// <summary>
    /// Collect method.
    /// </summary>
    void Collect();
}

/// <summary>
/// TestObject class.
/// </summary>
public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    public int durability { get; set; }
    public bool isCollected { get; set; }

    /// <summary>
    /// Interaction behavior.
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"{name} interacts.");
    }

    /// <summary>
    /// Breaking behavior.
    /// </summary>
    public void Break()
    {
        Console.WriteLine($"{name} breaks.");
    }

    /// <summary>
    /// Collecting behavior.
    /// </summary>
    public void Collect()
    {
        isCollected = true;
        Console.WriteLine($"{name} is collected.");
    }
}
