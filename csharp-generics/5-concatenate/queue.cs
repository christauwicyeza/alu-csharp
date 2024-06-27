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
    public T Dequeue()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T)!; // Return default value of T
        }
        else
        {
            count--;
            T currentValue = head!.Value!;
            head = head.Next;
            return currentValue;
        }
    }

    /// <summary>
    /// Returns the first element without removing from queue
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T)!; // Return default value of T
        }

        return head!.Value!;
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
