using System;
/// <summary>
/// abstract class Base
/// </summary>
public abstract class Base {
/// <summary>
/// name property
/// </summary>
    public string? name { get ; set; }
/// <summary>
/// ToString() method
/// </summary>
/// <returns></returns>
    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}

/// <summary>
/// IInteractive interface
/// </summary>
public interface IInteractive {

/// <summary>
/// interact method
/// </summary>
    public void Interact();
}

/// <summary>
/// IBreakable interface
/// </summary>
public interface IBreakable {

/// <summary>
/// durability
/// </summary>
    public int durability { get ; set;}
/// <summary>
/// break method
/// </summary>
    public void Break();
}

/// <summary>
/// ICollectable interface
/// </summary>
public interface ICollectable{
/// <summary>
/// isCollected
/// </summary>
    public bool isCollected { get ; set; }

/// <summary>
/// collect method
/// </summary>
    public void Collect();

}

/// <summary>
/// class Door
/// </summary>
public class Door : Base , IInteractive{

/// <summary>
/// constructor that sets the value of name
/// </summary>
/// <param name="value"></param>
    public Door(string value = "Door"){
        name = value;
    }

/// <summary>
/// Interact() implementation
/// </summary>
    public void Interact(){
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// decoration base inheriting from base, iinteractive, ibreakable
/// </summary>
public class Decoration : Base, IInteractive, IBreakable {

/// <summary>
/// isquestitem prp
/// </summary>
    public bool isQuestItem { get; set; }

/// <summary>
/// durability prp
/// </summary>
    public int durability { get; set; } 

/// <summary>
/// Decoration
/// </summary>
/// <param name="Name"></param>
/// <param name="durability"></param>
/// <param name="isQuestItem"></param>
/// <exception cref="ArgumentException"></exception>
    public Decoration(string Name = "Decoration", int durability = 1, bool isQuestItem= false) {

        this.isQuestItem = isQuestItem;
        name = Name;

        if (durability <= 0) {
            throw new ArgumentException("Durability must be greater than 0");
        }
        else {
            this.durability = durability;
        }

    }

/// <summary>
/// interact implementation
/// </summary>
    public void Interact()
    {
        if (durability <= 0) {
            Console.WriteLine($"The {name} has been broken.");
        }
        else if (isQuestItem) {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        }
        else {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

/// <summary>
/// break implementation
/// </summary>
    public void Break() {
       
            this.durability--;
            if (durability > 0) {
                Console.WriteLine($"You hit the {name}. It cracks.");
            }
            if (durability == 0) {
                Console.WriteLine($"You smash the {name}. What a mess.");
            }
        
            if (durability < 0) {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

/// <summary>
/// class key inheriting from base and iscollectable
/// </summary>
public class Key: Base, ICollectable {

/// <summary>
/// iscollected prp
/// </summary>
    public bool isCollected { get; set; }

/// <summary>
/// key constructor
/// </summary>
/// <param name="Name"></param>
/// <param name="isCollected"></param>
    public Key(string Name = "Key", bool isCollected = false) {

        name = Name;
        this.isCollected = isCollected;
    }

/// <summary>
/// collect method
/// </summary>
    public void Collect() {
        if (!isCollected) {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
        else {
            Console.WriteLine($"You have already picked up the {name}.");
        }
    }
}