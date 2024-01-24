using System;
using System.Collections.Generic;

class LList
{
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n){
        LinkedListNode<int> myNode = myLList.First;
        if (myNode.Value >= n)
            return myLList.AddFirst(n);
        while (myNode.Next != null){
            if (myNode.Next.Value >= n){
                myNode = myLList.AddAfter(myNode, n);
                return myNode;
            }
            myNode = myNode.Next;
        }
        myNode = myLList.AddLast(n);
        return myNode;
    }
}