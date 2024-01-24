using System;
using System.Collections.Generic;

class LList
{
    public static void Delete(LinkedList<int> myLList, int index)
    {
        if (myLList == null || index < 0 || index >= myLList.Count)
        {
            return; // Optionally handle invalid input
        }

        LinkedListNode<int> currentNode = myLList.First;
        for (int i = 0; i < index; ++i)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode != null)
        {
            myLList.Remove(currentNode);
        }
    }
}