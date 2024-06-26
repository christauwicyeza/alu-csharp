using System;

class Program
{
    static void Main()
    {
        Queue<int> myQueue = new Queue<int>();

        // Adding elements to the queue
        myQueue.Enqueue(10);
        myQueue.Enqueue(20);
        myQueue.Enqueue(30);

        // Peeking at the first element
        int? peekValue = myQueue.Peek();
        if (peekValue != null)
        {
            Console.WriteLine($"Peeked value: {peekValue}");
        }

        // Dequeuing elements
        int? dequeuedValue = myQueue.Dequeue();
        if (dequeuedValue != null)
        {
            Console.WriteLine($"Dequeued value: {dequeuedValue}");
        }

        // Printing all elements in the queue
        myQueue.Print();
    }
}
