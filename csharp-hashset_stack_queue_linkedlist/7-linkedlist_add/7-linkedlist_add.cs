using System;
using System.Collections.Generic;

public class LList
{
    public static LinkedListNode<int> Add(LinkedList<int> myLList, int n)
    {
               LinkedListNode<int> newNode = new LinkedListNode<int>(n);
       
        myLList.AddFirst(newNode);

        return newNode;
    }
}