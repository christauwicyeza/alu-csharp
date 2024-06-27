using System;

/// <summary>
/// Queue of a specified type.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class Queue<T>
{
    /// <summary>
    /// Node class for the elements in the queue.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Value contained in the node.
        /// </summary>
        public T? Value;

        /// <summary>
        /// Reference to the next node in the queue.
        /// </summary>
        public Node? Next;

        /// <summary>
        /// Constructs a new node with a specified value.
        /// </summary>
        /// <param name="value">The value to store in the node.</param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Head of the queue.
    /// </summary>
    protected Node? head;

    /// <summary>
    /// Tail of the queue.
    /// </summary>
    protected Node? tail;

    /// <summary>
    /// Number of elements in the queue.
    /// </summary>
    int count;

    /// <summary>
    /// Constructs an empty queue.
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
    /// <param name="value">The value to enqueue.</param>
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
    /// <returns>The element removed from the beginning of the queue, or the default value of type T if the queue is empty.</returns>
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
    /// <returns>The element at the beginning of the queue, or the default value of type T if the queue is empty.</returns>
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
    /// Concatenates all elements in the queue if the queue is of type string or char.
    /// </summary>
    /// <returns>A concatenated string of all elements, or null if the queue is empty or not of type string or char.</returns>
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
            if (CheckType() == typeof(string))
            {
                outputValue += " ";
            }
            current = current.Next;
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
    /// Returns the number of elements in the queue.
    /// </summary>
    /// <returns>The number of elements in the queue.</returns>
    public int Count()
    {
        return count;
    }
}
