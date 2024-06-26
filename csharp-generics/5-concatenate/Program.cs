using System;

class Program
{
    static void Main(string[] args)
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

        Console.ReadKey();
    }
}
