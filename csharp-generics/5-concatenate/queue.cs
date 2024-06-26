using System;
using System.Text;

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
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the next node in the queue.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class with a specified value.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

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
            tail.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    /// <summary>
    /// Removes and returns the element at the beginning of the queue.
    /// </summary>
    /// <returns>The element removed from the beginning of the queue.</returns>
    public T Dequeue()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        T currentValue = head.Value;
        head = head.Next;
        count--;

        return currentValue;
    }

    /// <summary>
    /// Returns the element at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>The element at the beginning of the queue.</returns>
    public T Peek()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        return head.Value;
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

        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }

    /// <summary>
    /// Concatenates all elements in the queue into a single string.
    /// </summary>
    /// <returns>A concatenated string of all elements.</returns>
    public string Concatenate()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return null;
        }

        if (typeof(T) != typeof(string) && typeof(T) != typeof(char))
        {
            Console.WriteLine("Concatenate() is for a queue of Strings or Chars only.");
            return null;
        }

        StringBuilder sb = new StringBuilder();
        Node current = head;
        while (current != null)
        {
            sb.Append(current.Value);
            current = current.Next;
        }

        return sb.ToString();
    }

    /// <summary>
    /// Gets the type of elements in the queue.
    /// </summary>
    /// <returns>The type of elements in the queue.</returns>
    public Type CheckType()
    {
        return typeof(T);
    }

    /// <summary>
    /// Gets the number of elements in the queue.
    /// </summary>
    /// <returns>The number of elements in the queue.</returns>
    public int Count()
    {
        return count;
    }
}
