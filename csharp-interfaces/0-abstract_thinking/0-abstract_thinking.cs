using System;

public abstract class Base
{
    // Property to store the name
    public string Name { get; set; }

    // Constructor
    public Base(string name)
    {
        Name = name;
    }

    // Override ToString() method to return "<name> is a <type>"
    public override string ToString()
    {
        return $"{Name} is a {GetType().Name}";
    }
}
