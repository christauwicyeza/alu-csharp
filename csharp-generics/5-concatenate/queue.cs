using System;


/// <summary>
///public class queue
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>  {


/// <summary>
/// class Node
/// </summary>
    public class Node{
        /// <summary>
        /// value of node
        /// </summary>

        public T? Value;

        /// <summary>
        /// reference to the next node in queue
        /// </summary>
        public Node? Next;

        /// <summary>
        /// initializes values
        /// </summary>
        /// <param name="value"></param>
        public Node(T value){
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// head node
    /// </summary>
    protected Node? head;
    /// <summary>
    /// tail node
    /// </summary>
    protected Node? tail;
    // counts the number of nodes
    int count;

/// <summary>
/// queue method
/// </summary>
    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }


/// <summary>
/// enqueue method
/// </summary>
/// <param name="value"></param>
    public void Enqueue(T? value){

        Node newNode = new Node(value!);
    
        if(head == null){
            head = newNode;
            tail = newNode;
        }else{
            tail!.Next = newNode;
            tail = newNode;
        }
         count++;
    }
/// <summary>
/// dequeue method
/// </summary>
/// <returns></returns>
public T? Dequeue(){
     T? value;

     if(count == 0) {
        Console.WriteLine("Queue is empty");
        return default(T);
     } else {
        count--;

        value = head!.Value;
        head = head.Next;
     }
     return value;
}

/// <summary>
/// peek method that returns value of first node  w/o removing node
/// </summary>
/// <returns></returns>
public T? Peek() 
{
    if (count == 0) {
        Console.WriteLine("Queue is empty");
        return default(T);
    }
    return head!.Value;
}

/// <summary>
/// print method prints queue from head
/// </summary>
/// <returns></returns>
public void Print() {
    if (count == 0) {
        Console.WriteLine("Queue is empty");
        return;
    }

    for(int i = 0; i < count; i++){
        Console.WriteLine(head!.Value);
        head = head.Next;
    }
}
    /// <summary>
    /// concatenate method
    /// </summary>
    /// <returns></returns>
    public String? Concatenate(){
        if(count == 0){
            Console.WriteLine("Queue is empty");
            return null;
        }

        if(CheckType() != typeof(String)  && CheckType() != typeof(Char)){
            Console.WriteLine("Concatenate() is for a queue of Strings or Chars");
            return null;
        }

        String outputValue = "";

         for(int i = 0; i < count ; i ++){
            
           
            outputValue += head!.Value;
             if(CheckType() == typeof(string)){
               outputValue += " "; 
            }
            head = head!.Next;
        }

        return outputValue;

    }
    


/// <summary>
/// checktype method
/// </summary>

    public Type CheckType(){
        return typeof(T);
    }

/// <summary>
/// count method
/// </summary>

    public int Count(){
        return count;
    } 
}


class Program
{
    static void Main(string[] args)
    {
        // Queue<string> myStrQ = new Queue<string>();

        // myStrQ.Enqueue("hello");
        // myStrQ.Enqueue("holberton");
        // myStrQ.Enqueue("school");

        // Console.WriteLine(myStrQ.Concatenate());

        // Console.WriteLine("----------");

        // Queue<int> myIntQ = new Queue<int>();
        // myIntQ.Concatenate();

        // Console.WriteLine("----------");

        // Queue<char> myCharQ = new Queue<char>();
        // myCharQ.Enqueue('a');
        // myCharQ.Enqueue('b');
        // myCharQ.Enqueue('c');
        // Console.WriteLine(myCharQ.Concatenate());
    }
}