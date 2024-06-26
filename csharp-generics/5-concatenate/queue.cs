using System;

/// <summary>
/// Represents a generic queue.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class Queue<T>
{
    /// <summary>
    /// Represents a node in the queue.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public T? Value;

        /// <summary>
        /// Gets or sets the next node in the queue.
        /// </summary>
        public Node? Next;

        /// <summary>
        /// Initializes a new instance of the Node class with the specified value.
        /// </summary>
        /// <param name="value">The value to store in the node.</param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    protected Node? head; // first element of queue
    protected Node? tail; // last element of the queue
    int count; // number of items in queue

    /// <summary>
    /// Initializes a new instance of the Queue class.
    /// </summary>
    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="value">The value to add to the queue.</param>
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
    /// Removes and returns the element at the beginning of the queue.
    /// </summary>
    /// <returns>The element removed from the beginning of the queue.</returns>
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
    /// Returns the element at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>The element at the beginning of the queue.</returns>
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
    /// Prints all elements in the queue.
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
    /// Concatenates all elements in the queue if the queue is of type String or Char.
    /// </summary>
    /// <returns>The concatenated string or null if conditions are not met.</returns>
    public string? Concatenate()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return null;
        }

        if (CheckType() != typeof(string) && CheckType() != typeof(char))
        {
            Console.WriteLine("Concatenate() is for a queue of Strings or Chars only.");
            return null;
        }

        string outputValue = "";
        Node? current = head;

        while (current != null)
        {
            outputValue += current.Value;
            current = current.Next;

            // Add space if concatenating strings
            if (CheckType() == typeof(string) && current != null)
                outputValue += " ";
        }

        return outputValue;
    }

    /// <summary>
    /// Returns the type of elements in the queue.
    /// </summary>
    /// <returns>The type of elements in the queue.</returns>
    public Type CheckType()
    {
        return typeof(T);
    }

    /// <summary>
    /// Returns the number of items in the queue.
    /// </summary>
    /// <returns>The number of items in the queue.</returns>
    public int Count()
    {
        return count;
    }

    /// <summary>
    /// Main method to test the Queue class.
    /// </summary>
    public static void Main()
    {
        // Example usage of Queue<int>
        Queue<int> intQueue = new Queue<int>();
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);

        Console.WriteLine("Printing integer queue:");
        intQueue.Print();

        Console.WriteLine("Dequeuing elements:");
        Console.WriteLine(intQueue.Dequeue());
        Console.WriteLine(intQueue.Dequeue());
        Console.WriteLine(intQueue.Dequeue());
        Console.WriteLine(intQueue.Dequeue()); // This will print "Queue is empty"

        // Example usage of Queue<string>
        Queue<string> stringQueue = new Queue<string>();
        stringQueue.Enqueue("Hello");
        stringQueue.Enqueue("World");

        Console.WriteLine("Printing string queue:");
        stringQueue.Print();

        Console.WriteLine("Concatenating string elements:");
        Console.WriteLine(stringQueue.Concatenate());

        // Example usage of Queue<char>
        Queue<char> charQueue = new Queue<char>();
        charQueue.Enqueue('A');
        charQueue.Enqueue('B');
        charQueue.Enqueue('C');

        Console.WriteLine("Printing char queue:");
        charQueue.Print();

        Console.WriteLine("Concatenating char elements:");
        Console.WriteLine(charQueue.Concatenate());

        // Example of trying to concatenate integers (should fail)
        Queue<int> invalidQueue = new Queue<int>();
        invalidQueue.Enqueue(1);
        invalidQueue.Enqueue(2);
        invalidQueue.Enqueue(3);

        Console.WriteLine("Attempting to concatenate integers:");
        Console.WriteLine(invalidQueue.Concatenate()); // This should print an error message

        // Example of checking type
        Console.WriteLine($"Type of elements in invalidQueue: {invalidQueue.CheckType()}");

        // Example of counting items
        Console.WriteLine($"Number of items in invalidQueue: {invalidQueue.Count()}");
    }
}
