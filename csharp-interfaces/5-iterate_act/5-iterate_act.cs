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

/// <summary>
/// roomobjects class
/// </summary>
public class RoomObjects {

/// <summary>
/// iterateaction method
/// </summary>
/// <param name="roomObjects"></param>
/// <param name="type"></param>
    public static void IterateAction(List<Base> roomObjects, Type type) {

        foreach (var obj in roomObjects) {

            if (typeof(Door).GetInterfaces().Contains(type))
            {
                IInteractive? current = obj as IInteractive;
                current?.Interact();
            }
            else if (typeof(Decoration).GetInterfaces().Contains(type))
            {
                IBreakable? current = obj as IBreakable;
                current?.Break();
            }
            else if (typeof(Key).GetInterfaces().Contains(type))
            {
                ICollectable? current = obj as ICollectable;
                current?.Collect();
            }
      }
    }
}

using System;

/// Base abstract class
public abstract class Base
{
    /// Name property
    public string? name { get; set; }

    /// Override ToString method
    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}

/// Interface for interactive objects
public interface IInteractive
{
    /// Interact method
    void Interact();
}

/// Interface for breakable objects
public interface IBreakable
{
    /// Durability property
    int durability { get; set; }

    /// Break method
    void Break();
}

/// Interface for collectable objects
public interface ICollectable
{
    /// IsCollected property
    bool isCollected { get; set; }

    /// Collect method
    void Collect();
}

/// Door class implementing IInteractive
public class Door : Base, IInteractive
{
    /// Constructor to set the name
    public Door(string value = "Door")
    {
        name = value;
    }

    /// Implementation of Interact method
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// Decoration class implementing IInteractive and IBreakable
public class Decoration : Base, IInteractive, IBreakable
{
    /// IsQuestItem property
    public bool isQuestItem { get; set; }

    /// Durability property
    public int durability { get; set; }

    /// Constructor to set properties
    public Decoration(string Name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        this.isQuestItem = isQuestItem;
        name = Name;

        if (durability <= 0)
        {
            throw new ArgumentException("Durability must be greater than 0");
        }
        else
        {
            this.durability = durability;
        }
    }

    /// Implementation of Interact method
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

    /// Implementation of Break method
    public void Break()
    {
        durability--;

        if (durability > 0)
        {
            Console.WriteLine($"You hit the {name}. It cracks.");
        }
        else if (durability == 0)
        {
            Console.WriteLine($"You smash the {name}. What a mess.");
        }
        else
        {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

/// Key class implementing ICollectable
public class Key : Base, ICollectable
{
    /// IsCollected property
    public bool isCollected { get; set; }

    /// Constructor to set properties
    public Key(string Name = "Key", bool isCollected = false)
    {
        name = Name;
        this.isCollected = isCollected;
    }

    /// Implementation of Collect method
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

/// RoomObjects class to handle actions on room objects
public class RoomObjects
{
    /// Method to iterate over room objects and perform actions
    public static void IterateAction(List<Base> roomObjects, Type type)
    {
        foreach (var obj in roomObjects)
        {
            if (typeof(Door).GetInterfaces().Contains(type))
            {
                IInteractive? current = obj as IInteractive;
                current?.Interact();
            }
            else if (typeof(Decoration).GetInterfaces().Contains(type))
            {
                IBreakable? current = obj as IBreakable;
                current?.Break();
            }
            else if (typeof(Key).GetInterfaces().Contains(type))
            {
                ICollectable? current = obj as ICollectable;
                current?.Collect();
            }
        }
    }
}
