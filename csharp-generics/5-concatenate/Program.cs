using System;

class Program
{
    static void Main()
    {
        // Example usage of Queue<string>
        Queue<string> stringQueue = new Queue<string>();
        stringQueue.Enqueue("Hello");
        stringQueue.Enqueue(" ");
        stringQueue.Enqueue("World");

        Console.WriteLine("Concatenating string elements:");
        Console.WriteLine(stringQueue.Concatenate());

        // Example usage of Queue<char>
        Queue<char> charQueue = new Queue<char>();
        charQueue.Enqueue('A');
        charQueue.Enqueue('B');
        charQueue.Enqueue('C');

        Console.WriteLine("\nConcatenating char elements:");
        Console.WriteLine(charQueue.Concatenate());

        // Example with an empty queue
        Queue<int> intQueue = new Queue<int>();

        Console.WriteLine("\nConcatenating int elements:");
        Console.WriteLine(intQueue.Concatenate()); // Should print "Queue is empty" and return null

        Console.ReadKey();
    }
}
