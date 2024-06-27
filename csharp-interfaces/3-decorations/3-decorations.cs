using System;
using System.Collections.Generic;

/// <summary>
/// Interface for interactive objects.
/// </summary>
public interface IInteractive{
    /// <summary>
    /// Method for interaction with the object.
    /// </summary>
    void Interact();
}

/// <summary>
/// Interface for breakable objects.
/// </summary>
public interface IBreakable {
    /// <summary>
    /// Gets or sets the durability of the breakable object.
    /// </summary>
    int durability { get; set; }

    /// <summary>
    /// Method to break the object.
    /// </summary>
    void Break();
}

/// <summary>
/// Interface for collectable objects.
/// </summary>
public interface ICollectable{
    /// <summary>
    /// Gets or sets a value indicating whether the object is collected.
    /// </summary>
    bool isCollected { get; set; }
    
    /// <summary>
    /// Method to collect the object.
    /// </summary>
    void Collect();
}

/// <summary>
/// Door class that implements IInteractive interface.
/// </summary>
public class Door : Base, IInteractive{
    /// <summary>
    /// Constructor for Door class.
    /// </summary>
    /// <param name="value">The name of the door.</param>
    public Door(string value = "Door"){
        name = value;
    }

    /// <summary>
    /// Method called when interacting with the door.
    /// </summary>
    public void Interact(){
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// Decoration class that implements IInteractive and IBreakable interfaces.
/// </summary>
public class Decoration : Base, IInteractive, IBreakable{
    /// <summary>
    /// Indicates if the decoration is a quest item.
    /// </summary>
    public bool isQuestItem = false;

    /// <summary>
    /// Gets or sets the durability of the decoration.
    /// </summary>
    public int durability { get; set; }

    /// <summary>
    /// Constructor for Decoration class.
    /// </summary>
    /// <param name="CName">The name of the decoration.</param>
    /// <param name="durability">The durability of the decoration.</param>
    /// <param name="isQuestItem">Whether the decoration is a quest item.</param>
    public Decoration(string CName = "Decoration", int durability = 1, bool isQuestItem = false){
        this.isQuestItem = isQuestItem;
        name = CName;
        if(durability <= 0){
            throw new Exception("Durability must be greater than 0");
        } else {
            this.durability = durability;
        }
    }

    /// <summary>
    /// Method called when interacting with the decoration.
    /// </summary>
    public void Interact(){
        if(durability <= 0){
            Console.WriteLine($"The {name} has been broken.");
        } else if(isQuestItem){
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        } else {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

    /// <summary>
    /// Method to break the decoration.
    /// </summary>
    public void Break(){
        this.durability--;

        if(durability > 0){
            Console.WriteLine($"You hit the {name}. It cracks.");
        } else if(durability == 0){
            Console.WriteLine($"You smash the {name}. What a mess.");
        } else {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

/// <summary>
/// Base class for all objects.
/// </summary>
public abstract class Base{
    /// <summary>
    /// Gets or sets the name of the object.
    /// </summary>
    public string? name { get; set; }

    /// <summary>
    /// Returns a string representation of the object.
    /// </summary>
    /// <returns>A string representation of the object.</returns>
    public override string ToString(){
        return $"{name} is a {this.GetType()}";
    }
}
