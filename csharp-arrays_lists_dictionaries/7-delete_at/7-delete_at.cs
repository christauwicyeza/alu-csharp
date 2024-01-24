using System;
using System.Collections.Generic;

public class ListManipulator
{
    public static List<int> DeleteAt(List<int> myList, int index)
    {
        if (index < 0 || index >= myList.Count)
        {
            Console.WriteLine("Index is out of range");
            return myList;
        }

        List<int> updatedList = new List<int>();

        for (int i = 0; i < myList.Count; i++)
        {
            if (i != index)
            {
                updatedList.Add(myList[i]);
            }
        }

        myList.Clear();
        foreach (var item in updatedList)
        {
            myList.Add(item);
        }

        return myList;
    }
}
