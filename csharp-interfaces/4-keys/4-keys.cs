using System;

/// <summary>Base abstract class</summary>
public abstract class Base
{
    /// <summary>Name property</summary>
    public string? name { get; set; }

    /// <summary>Override ToString()</summary>
    /// <returns>String</returns>
    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}

/// <summary>Interactive interface</summary>
public interface IInteractive
{
    /// <summary>Interact method</summary>
    void Interact();
}

/// <summary>Breakable interface</summary>
public interface IBreakable
{
    /// <summary>Durability property</summary>
    int durability { get; set; }

    /// <summary>Break method</summary>
    void Break();
}

/// <summary>Collectable interface</summary>
public interface ICollectable
{
    /// <summary>IsCollected property</summary>
    bool isCollected { get; set; }

    /// <summary>Collect method</summary>
    void Collect();
}

/// <summary>Door class</summary>
public class Door : Base, IInteractive
{
    /// <summary>Constructor</summary>
    /// <param name="value">Name of the door</param>
    public Door(string value = "Door")
    {
        name = value;
    }

    /// <summary>Interact method</summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>Decoration class</summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>Quest item property</summary>
    public bool isQuestItem { get; set; }

    /// <summary>Durability property</summary>
    public int durability { get; set; }

    /// <summary>Constructor</summary>
    /// <param name="Name">Name of the decoration</param>
    /// <param name="durability">Durability value</param>
    /// <param name="isQuestItem">Is quest item flag</param>
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

    /// <summary>Interact method</summary>
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

    /// <summary>Break method</summary>
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

/// <summary>Key class</summary>
public class Key : Base, ICollectable
{
    /// <summary>IsCollected property</summary>
    public bool isCollected { get; set; }

    /// <summary>Constructor</summary>
    /// <param name="Name">Name of the key</param>
    /// <param name="isCollected">Is collected flag</param>
    public Key(string Name = "Key", bool isCollected = false)
    {
        name = Name;
        this.isCollected = isCollected;
    }

    /// <summary>Collect method</summary>
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
