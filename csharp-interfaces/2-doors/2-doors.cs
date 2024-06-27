using System;
using System.Collections.Generic;


/// <summary>
/// interace for interactions
/// </summary>
public interface IInteractive{

    /// <summary>
    /// interact method
    /// </summary>
    public void Interact();
}


/// <summary>
/// interface for breakables
/// </summary>
public interface IBreakable {

    // durability
    public int durability { get ; set;}

    /// <summary>
    /// breaking stuff
    /// </summary>
    public void Break();
}


/// <summary>
/// collecting stuff
/// </summary>
public interface ICollectable{

    // collecting
    public bool isCollected { get ; set; }
    /// <summary>
    /// for collecting objects.
    /// </summary>
    public void Collect();
}

/// <summary>
/// Door class for controlling a door
/// </summary>
public class Door : Base , IInteractive{

    public Door(string value = "Door"){
        name = value;
    }

    public void Interact(){
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}


/// <summary>
/// base class for everythign.
/// </summary>
public abstract class Base{

    public String? name { get ; set; }

    public override String ToString(){
        return $"{name} is a {this.GetType()}";
    }
}