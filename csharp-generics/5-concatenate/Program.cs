using System;

/// <summary>
/// Entry point for the program.
/// </summary>
public class Program
{
    /// <summary>
    /// Demonstrates usage of the Queue class.
    /// </summary>
    public static void Main()
    {
        // Example usage of Queue with integers
        Console.WriteLine("Queue of integers:");
        Queue<int> intQueue = new Queue<int>();
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Print();

        // Example usage of Queue with strings
        Console.WriteLine("\nQueue of strings:");
        Queue<string> stringQueue = new Queue<string>();
        stringQueue.Enqueue("Hello");
        stringQueue.Enqueue("World");
        stringQueue.Print();

        // Example usage of Concatenate method
        Console.WriteLine("\nConcatenating string elements:");
        string? concatenatedString = stringQueue.Concatenate();
        Console.WriteLine(concatenatedString);

        // Example usage of Queue with characters
        Console.WriteLine("\nQueue of chars:");
        Queue<char> charQueue = new Queue<char>();
        charQueue.Enqueue('A');
        charQueue.Enqueue('B');
        charQueue.Enqueue('C');
        charQueue.Print();

        // Example usage of Concatenate method
        Console.WriteLine("\nConcatenating char elements:");
        string? concatenatedChars = charQueue.Concatenate();
        Console.WriteLine(concatenatedChars);

        // Example usage of Queue with unsupported type
        Console.WriteLine("\nQueue of doubles:");
        Queue<double> doubleQueue = new Queue<double>();
        doubleQueue.Enqueue(1.1);
        doubleQueue.Enqueue(2.2);
        doubleQueue.Print();
        string? concatenatedDoubles = doubleQueue.Concatenate();
        Console.WriteLine(concatenatedDoubles);
    }
}
