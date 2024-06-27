using System;

/// <summary>
/// queue of type defined
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>  {

/// <summary>
/// Node class struct
/// </summary>
    public class Node{

        public T? Value;
        public Node? Next;

        public Node(T value){
            Value = value;
            Next = null;
        }
    }

// first element of queue
    protected Node? head;
    // last element of the queue
    protected Node? tail;
    // number of items in queue
    int count;

// constructor assignment
    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }


/// <summary>
/// adding elements at queue end
/// </summary>
/// <param name="value"></param>
    public void Enqueue(T value){

        Node newNode = new Node(value);
    
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
/// decrements the queue and returns the type 
/// </summary>
/// <returns></returns>
    public T? Dequeue(){

        T? CurrentValue;

        if(count == 0){
            Console.WriteLine("Queue is emtpy");
            return default(T);
        }else{
            count--;

            CurrentValue = head!.Value;
            head = head.Next;
        }

          return CurrentValue;
    }


/// <summary>
/// returns the first element without removing from queue
/// </summary>
/// <returns></returns>
    public T? Peek(){
        if(count == 0){
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        return head!.Value;
    }

/// <summary>
/// displays all elements in queue
/// </summary>
    public void Print(){

        if(count == 0){
            Console.WriteLine("Queue is empty");
            return;
        }

    

        for(int i = 0; i < count ; i ++){
            Console.WriteLine(head!.Value);
            head = head.Next;
        }
    }


/// <summary>
/// combines string or chars together
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
/// returns type of generic
/// </summary>
/// <returns></returns>
    public Type CheckType(){
        return typeof(T);
    }

/// <summary>
/// returns the number of items
/// </summary>
/// <returns></returns>
    public int Count(){
        return count;
    }
    
}