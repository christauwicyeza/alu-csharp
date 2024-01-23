using System;
using System.Collections.Generic;

class ListMethods
{
    public static int MaxInteger(List<int> myList)
    {
        if (myList == null)
        {
            Console.WriteLine("Input list is null");
            return -1;
        }

        if (myList.Count == 0)
        {
            Console.WriteLine("List is empty");
            return -1;
        }

        int max = myList[0];

        for (int i = 1; i < myList.Count; i++)
        {
            Console.Write(myList[i]);
            if (myList[i] > max)
            {
                max = myList[i];
            }
        }

        Console.WriteLine();
        return max;
    }
}
