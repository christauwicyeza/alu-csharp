using System;

/// <summary>
/// A generic queue.
/// </summary>
/// <typeparam name="T">Element type.</typeparam>
public class Queue<T>
{
    /// <summary>
    /// Gets the type of elements.
    /// </summary>
    /// <returns>Type of T.</returns>
    public Type CheckType()
    {
        return typeof(T);
    }
}
