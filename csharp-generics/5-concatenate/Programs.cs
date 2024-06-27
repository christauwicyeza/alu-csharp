using System;

class Program
{
    static void Main()
    {
        // Example usage of Queue<int>
        Queue<int> intQueue = new Queue<int>();
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);

        Console.WriteLine("Queue elements:");
        intQueue.Print();

        int dequeueValue = intQueue.Dequeue();
        Console.WriteLine($"Dequeued value: {dequeueValue}");

        int peekValue = intQueue.Peek();
        Console.WriteLine($"Peeked value: {peekValue}");

        Console.WriteLine($"Queue count: {intQueue.Count()}");

        // Example usage of Queue<string>
        Queue<string> stringQueue = new Queue<string>();
        stringQueue.Enqueue("Hello");
        stringQueue.Enqueue("World");

        Console.WriteLine("\nString Queue elements:");
        stringQueue.Print();

        string concatenatedString = stringQueue.Concatenate();
        if (concatenatedString != null)
        {
            Console.WriteLine($"Concatenated string: {concatenatedString}");
        }

        Console.WriteLine($"String Queue count: {stringQueue.Count()}");

        // Example usage of Queue<char>
        Queue<char> charQueue = new Queue<char>();
        charQueue.Enqueue('A');
        charQueue.Enqueue('B');
        charQueue.Enqueue('C');

        Console.WriteLine("\nChar Queue elements:");
        charQueue.Print();

        string concatenatedChars = charQueue.Concatenate();
        if (concatenatedChars != null)
        {
            Console.WriteLine($"Concatenated chars: {concatenatedChars}");
        }

        Console.WriteLine($"Char Queue count: {charQueue.Count()}");

        // Example for error case
        Queue<double> doubleQueue = new Queue<double>();
        doubleQueue.Enqueue(1.1);
        doubleQueue.Enqueue(2.2);

        string concatenatedDouble = doubleQueue.Concatenate();
        if (concatenatedDouble == null)
        {
            Console.WriteLine("\nConcatenation failed due to incorrect type.");
        }
    }
}
