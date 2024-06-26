using System;

/// <summary>
/// A generic queue.
/// </summary>
/// <typeparam name="T">Element type.</typeparam>
public class Queue<T>
{
    // Other members of Queue<T> class...

    /// <summary>
    /// Main method for testing Queue class.
    /// </summary>
    public static void Main(string[] args)
    {
        // Example usage
        Queue<int> intQueue = new Queue<int>();
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);

        Console.WriteLine($"Queue Type: {intQueue.CheckType()}");
        Console.WriteLine($"Queue Count: {intQueue.Count()}");

        // Print all elements in the queue
        Queue<int>.Node current = intQueue.Head;
        Console.Write("Queue Elements: ");
        while (current != null)
        {
            Console.Write($"{current.Value} ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
