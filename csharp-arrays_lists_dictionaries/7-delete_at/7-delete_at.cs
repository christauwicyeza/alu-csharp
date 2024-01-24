﻿using System.Collections;

class List
{
    public static List<int> DeleteAt(List<int> myList, int index)
    {
        int ListSize = myList.Count;
        List<int> CacheList = new List<int>();

        if (index >= 0 && index < ListSize)
        {
            for (int i = 0; i < ListSize; i++)
            {
                if (i == index)
                    continue;
                else
                    CacheList.Add(myList[i]);
            }
            Console.WriteLine("Index is within range");
            return CacheList;
        }
        else
        {
            Console.WriteLine("Index is out of range");
            return myList;
        }
    }
}
