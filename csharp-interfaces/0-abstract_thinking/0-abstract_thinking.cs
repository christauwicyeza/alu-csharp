﻿using System;

/// <summary>
/// Abstract Base class representing an entity with a name.
/// </summary>
public abstract class Base
{
    /// <summary>
    /// Gets or sets the name of the entity.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Constructor for initializing the Base class with a name.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    public Base(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Overrides the default ToString method to return a formatted string indicating the type and name.
    /// </summary>
    /// <returns>A string representation of the object in the format: "{Name} is a {Type}".</returns>
    public override string ToString()
    {
        return $"{Name} is a {GetType().Name}";
    }
}
