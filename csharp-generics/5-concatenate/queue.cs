using System;

/// <summary>
/// Generic Queue class
/// </summary>
/// <typeparam name="T">Type parameter</typeparam>
public class CustomQueue<T> {

    /// <summary>
    /// Node class representing an element in the queue
    /// </summary>
    public class Node {
        /// <summary>
        /// The value stored in the node
        /// </summary>
        public T? Value;

        /// <summary>
        /// The reference to the next node in the queue
        /// </summary>
        public Node? Next;

        /// <summary>
        /// Node constructor initializing the value
        /// </summary>
        /// <param name="value">Value to be stored in the node</param>
        public Node(T value) {
            Value = value;
            Next = null;
        }
    }

    private Node? head; // The front node of the queue
    private Node? tail; // The rear node of the queue
    private int count; // The count of nodes in the queue

    /// <summary>
    /// Constructor to initialize the queue
    /// </summary>
    public CustomQueue() {
        head = null;
        tail = null;
        count = 0;
    }

    /// <summary>
    /// Method to add a new element to the rear of the queue
    /// </summary>
    /// <param name="value">Value to be added</param>
    public void Enqueue(T? value) {
        Node newNode = new Node(value!);

        if (head == null) {
            head = newNode;
            tail = newNode;
        } else {
            tail!.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    /// <summary>
    /// Method to remove and return the front element of the queue
    /// </summary>
    /// <returns>The value of the removed element</returns>
    public T? Dequeue() {
        if (count == 0) {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        T? value = head!.Value;
        head = head.Next;
        count--;

        return value;
    }

    /// <summary>
    /// Method to return the value of the front element without removing it
    /// </summary>
    /// <returns>The value of the front element</returns>
    public T? Peek() {
        if (count == 0) {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        return head!.Value;
    }

    /// <summary>
    /// Method to print all elements of the queue from the front
    /// </summary>
    public void Print() {
        if (count == 0) {
            Console.WriteLine("Queue is empty");
            return;
        }

        Node? current = head;
        while (current != null) {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }

    /// <summary>
    /// Method to concatenate all string or char elements in the queue
    /// </summary>
    /// <returns>A concatenated string of all elements</returns>
    public string? Concatenate() {
        if (count == 0) {
            Console.WriteLine("Queue is empty");
            return null;
        }

        if (CheckType() != typeof(string) && CheckType() != typeof(char)) {
            Console.WriteLine("Concatenate() is for a queue of Strings or Chars");
            return null;
        }

        string result = "";
        Node? current = head;

        while (current != null) {
            result += current.Value;
            if (CheckType() == typeof(string)) {
                result += " ";
            }
            current = current.Next;
        }

        return result;
    }

    /// <summary>
    /// Method to return the type of elements stored in the queue
    /// </summary>
    /// <returns>The type of elements</returns>
    public Type CheckType() {
        return typeof(T);
    }

    /// <summary>
    /// Method to return the count of elements in the queue
    /// </summary>
    /// <returns>The count of elements</returns>
    public int Count() {
        return count;
    }
}