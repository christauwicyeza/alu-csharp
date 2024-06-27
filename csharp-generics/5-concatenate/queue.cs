using System;

/// <summary>
/// Queue of type defined
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>
{
    /// <summary>
    /// Node class struct
    /// </summary>
    public class Node
    {
        public T? Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    // First element of queue
    protected Node? head;
    // Last element of the queue
    protected Node? tail;
    // Number of items in queue
    int count;

    // Constructor assignment
    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }

    /// <summary>
    /// Adding elements at queue end
    /// </summary>
    /// <param name="value"></param>
    public void Enqueue(T value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    /// <summary>
    /// Decrements the queue and returns the type 
    /// </summary>
    /// <returns></returns>
    public T? Dequeue()
    {
        T? currentValue;

        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }
        else
        {
            count--;

            currentValue = head!.Value;
            head = head.Next;
        }

        return currentValue;
    }

    /// <summary>
    /// Returns the first element without removing from queue
    /// </summary>
    /// <returns></returns>
    public T? Peek()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        return head!.Value;
    }

    /// <summary>
    /// Displays all elements in queue
    /// </summary>
    public void Print()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Node? current = head;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }

    /// <summary>
    /// Combines string or chars together
    /// </summary>
    /// <returns></returns>
    public string? Concatenate()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return null;
        }

        if (CheckType() != typeof(string) && CheckType() != typeof(char))
        {
            Console.WriteLine("Concatenate() is for a queue of Strings or Chars");
            return null;
        }

        string outputValue = "";

        Node? current = head;
        while (current != null)
        {
            outputValue += current.Value;
            if (CheckType() == typeof(string))
            {
                outputValue += " ";
            }
            current = current.Next;
        }

        return outputValue;
    }

    /// <summary>
    /// Returns type of generic
    /// </summary>
    /// <returns></returns>
    public Type CheckType()
    {
        return typeof(T);
    }

    /// <summary>
    /// Returns the number of items
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return count;
    }
}

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

        int dequeueValue = intQueue.Dequeue() ?? default;
        Console.WriteLine($"Dequeued value: {dequeueValue}");

        int peekValue = intQueue.Peek() ?? default;
        Console.WriteLine($"Peeked value: {peekValue}");

        Console.WriteLine($"Queue count: {intQueue.Count()}");

        // Example usage of Queue<string>
        Queue<string> stringQueue = new Queue<string>();
        stringQueue.Enqueue("Hello");
        stringQueue.Enqueue("World");

        Console.WriteLine("\nString Queue elements:");
        stringQueue.Print();

        string concatenatedString = stringQueue.Concatenate();
        Console.WriteLine($"Concatenated string: {concatenatedString}");

        Console.WriteLine($"String Queue count: {stringQueue.Count()}");

        // Example usage of Queue<char>
        Queue<char> charQueue = new Queue<char>();
        charQueue.Enqueue('A');
        charQueue.Enqueue('B');
        charQueue.Enqueue('C');

        Console.WriteLine("\nChar Queue elements:");
        charQueue.Print();

        string concatenatedChars = charQueue.Concatenate();
        Console.WriteLine($"Concatenated chars: {concatenatedChars}");

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
