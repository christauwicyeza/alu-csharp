using System;
using System.Collections.Generic;

public class LList
{
    public static int FindNode(LinkedList<int> myLList, int value)
    {
        if (myLList == null)
        {
            return -1;
        }

        int index = 0;
        foreach (int item in myLList)
        {
            if (item == value)
            {
                return index;
            }
            index++;
        }

        
        return -1;
    }
}