using System;
using System.Collections.Generic;

/// <summary>
/// Interface for interactive objects.
/// </summary>
public interface IInteractive{
    /// <summary>
    /// Method for interaction with the object.
    /// </summary>
    public void Interact();
}

/// <summary>
/// Interface for breakable objects.
/// </summary>
public interface IBreakable {
    // Property to hold the durability value of the object.
    public int durability { get; set; }

    /// <summary>
    /// Method to break the object.
    /// </summary>
    public void Break();
}

/// <summary>
/// Interface for collectable objects.
/// </summary>
public interface ICollectable{
    // Property to check if the object is collected.
    public bool isCollected { get; set; }
    
    /// <summary>
    /// Method to collect the object.
    /// </summary>
    public void Collect();
}

/// <summary>
/// Door class that implements IInteractive interface.
/// </summary>
public class Door : Base, IInteractive{
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
    public bool isQuestItem = false;
    public int durability { get; set; }

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
    public String? name { get; set; }

    public override String ToString(){
        return $"{name} is a {this.GetType()}";
    }
}
