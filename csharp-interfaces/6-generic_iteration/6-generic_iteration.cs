using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Abstract base class with a name property
/// </summary>
public abstract class Base {
    /// <summary>
    /// The name of the object
    /// </summary>
    public string? name { get; set; }
    
    /// <summary>
    /// Overrides the ToString method to return the name and type of the object
    /// </summary>
    /// <returns>A string representation of the object</returns>
    public override string ToString() {
        return $"{name} is a {GetType().Name}";
    }
}

/// <summary>
/// Interface for interactive objects
/// </summary>
public interface IInteractive {
    /// <summary>
    /// Method to define interaction
    /// </summary>
    void Interact();
}

/// <summary>
/// Interface for breakable objects
/// </summary>
public interface IBreakable {
    /// <summary>
    /// Property to get and set the durability of the object
    /// </summary>
    int durability { get; set; }
    
    /// <summary>
    /// Method to define breaking behavior
    /// </summary>
    void Break();
}

/// <summary>
/// Interface for collectable objects
/// </summary>
public interface ICollectable {
    /// <summary>
    /// Property to check if the object is collected
    /// </summary>
    bool isCollected { get; set; }
    
    /// <summary>
    /// Method to define collection behavior
    /// </summary>
    void Collect();
}

/// <summary>
/// Door class that can be interacted with
/// </summary>
public class Door : Base, IInteractive {
    /// <summary>
    /// Constructor that sets the name of the door
    /// </summary>
    /// <param name="value">The name of the door</param>
    public Door(string value = "Door") {
        name = value;
    }

    /// <summary>
    /// Interact method implementation for Door
    /// </summary>
    public void Interact() {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// Decoration class that can be interacted with and broken
/// </summary>
public class Decoration : Base, IInteractive, IBreakable {
    /// <summary>
    /// Property to check if the decoration is a quest item
    /// </summary>
    public bool isQuestItem { get; set; }

    /// <summary>
    /// Property to get and set the durability of the decoration
    /// </summary>
    public int durability { get; set; } 

    /// <summary>
    /// Constructor to initialize the decoration
    /// </summary>
    /// <param name="name">Name of the decoration</param>
    /// <param name="durability">Durability of the decoration</param>
    /// <param name="isQuestItem">Is the decoration a quest item</param>
    /// <exception cref="ArgumentException">Thrown when durability is less than or equal to 0</exception>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false) {
        this.isQuestItem = isQuestItem;
        this.name = name;

        if (durability <= 0) {
            throw new ArgumentException("Durability must be greater than 0");
        } else {
            this.durability = durability;
        }
    }

    /// <summary>
    /// Interact method implementation for Decoration
    /// </summary>
    public void Interact() {
        if (durability <= 0) {
            Console.WriteLine($"The {name} has been broken.");
        } else if (isQuestItem) {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        } else {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

    /// <summary>
    /// Break method implementation for Decoration
    /// </summary>
    public void Break() {
        durability--;
        if (durability > 0) {
            Console.WriteLine($"You hit the {name}. It cracks.");
        } else if (durability == 0) {
            Console.WriteLine($"You smash the {name}. What a mess.");
        } else {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

/// <summary>
/// Key class that can be collected
/// </summary>
public class Key : Base, ICollectable {
    /// <summary>
    /// Property to check if the key is collected
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>
    /// Constructor to initialize the key
    /// </summary>
    /// <param name="name">Name of the key</param>
    /// <param name="isCollected">Is the key collected</param>
    public Key(string name = "Key", bool isCollected = false) {
        this.name = name;
        this.isCollected = isCollected;
    }

    /// <summary>
    /// Collect method implementation for Key
    /// </summary>
    public void Collect() {
        if (!isCollected) {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        } else {
            Console.WriteLine($"You have already picked up the {name}.");
        }
    }
}

/// <summary>
/// Generic container for objects
/// </summary>
/// <typeparam name="T">Type of objects in the container</typeparam>
public class Objs<T> : IEnumerable<T> {
    private List<T> items = new List<T>();

    /// <summary>
    /// Adds an item to the container
    /// </summary>
    /// <param name="item">Item to add</param>
    public void Add(T item) {
        items.Add(item);
    }

    /// <summary>
    /// Gets an enumerator for the items
    /// </summary>
    /// <returns>Enumerator for the items</returns>
    public IEnumerator<T> GetEnumerator() {
        return items.GetEnumerator();
    }

    /// <summary>
    /// Gets an enumerator (non-generic)
    /// </summary>
    /// <returns>Enumerator</returns>
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}

/// <summary>
/// Class for handling actions on room objects
/// </summary>
public class RoomObjects {
    /// <summary>
    /// Iterates through a list of objects and performs an action based on their type
    /// </summary>
    /// <param name="roomObjects">List of room objects</param>
    /// <param name="type">Type of action to perform</param>
    public static void IterateAction(List<Base> roomObjects, Type type) {
        foreach (var obj in roomObjects) {
            if (typeof(IInteractive).IsAssignableFrom(type) && obj is IInteractive interactive) {
                interactive.Interact();
            } else if (typeof(IBreakable).IsAssignableFrom(type) && obj is IBreakable breakable) {
                breakable.Break();
            } else if (typeof(ICollectable).IsAssignableFrom(type) && obj is ICollectable collectable) {
                collectable.Collect();
            }
        }
    }
}

// Example usage
class Program {
    static void Main(string[] args) {
        List<Base> roomObjects = new List<Base> {
            new Door("Front Door"),
            new Decoration("Vase", 3, false),
            new Key("Golden Key", false),
            new Decoration("Ancient Statue", 2, true)
        };

        RoomObjects.IterateAction(roomObjects, typeof(IInteractive));
        RoomObjects.IterateAction(roomObjects, typeof(IBreakable));
        RoomObjects.IterateAction(roomObjects, typeof(ICollectable));
    }
}
