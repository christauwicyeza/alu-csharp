using System;

/// <summary>
/// Represents a generic queue.
/// </summary>
/// <typeparam name="T">Element type.</typeparam>
public class Queue<T>
{
    public Type CheckType()
    {
        return typeof(T);
    }
}
