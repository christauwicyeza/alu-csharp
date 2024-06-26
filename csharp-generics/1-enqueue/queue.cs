using System;

/// <summary>
/// A generic queue.
/// </summary>
/// <typeparam name="T">Element type.</typeparam>
public class Queue<T>
{
    /// <summary>
    /// A node in the queue.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Node value.
        /// </summary>
        public T Value { get; set; }
        
        /// <summary>
        /// Next node.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Creates a node with a value.
        /// </summary>
        /// <param name="value">Node value.</param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Queue head.
    /// </summary>
    public Node Head { get; private set; }
    
    /// <summary>
    /// Queue tail.
    /// </summary>
    public Node Tail { get; private set; }
    
    /// <summary>
    /// Node count.
    /// </summary>
    private int count;

    /// <summary>
    /// Initializes the queue.
    /// </summary>
    public Queue()
    {
        Head = null;
        Tail = null;
        count = 0;
    }

    /// <summary>
    /// Adds a node to the end.
    /// </summary>
    /// <param name="value">Node value.</param>
    public void Enqueue(T value)
    {
        Node newNode = new Node(value);
        if (Tail == null)
        {
            Head = newNode;
        }
        else
        {
            Tail.Next = newNode;
        }
        Tail = newNode;
        count++;
    }

    /// <summary>
    /// Gets the node count.
    /// </summary>
    /// <returns>Node count.</returns>
    public int Count()
    {
        return count;
    }

    /// <summary>
    /// Gets the element type.
    /// </summary>
    /// <returns>Element type.</returns>
    public Type CheckType()
    {
        return typeof(T);
    }
}
