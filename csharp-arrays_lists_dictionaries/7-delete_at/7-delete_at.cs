using System;
using System.Collections.Generic;

public class ListManipulator
{
    public static List<int> DeleteAt(List<int> myList, int index)
    {
        if (index < 0 || index >= myList.Count)
        {
            Console.WriteLine("Index is out of range");
        }
        else
        {
            myList.RemoveAt(index);
        }

        return myList;
    }
}
