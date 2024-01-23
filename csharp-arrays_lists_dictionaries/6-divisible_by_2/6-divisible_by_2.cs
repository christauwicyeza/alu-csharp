using System;
using System.Collections.Generic;

class ListMethods
{
    public static List<bool> DivisibleBy2(List<int> myList)
    {
        if (myList == null)
        {
            Console.WriteLine("Input list is null");
            return null;
        }

        List<bool> result = new List<bool>();

        foreach (int number in myList)
        {
            bool isMultipleOf2 = (number % 2 == 0);
            result.Add(isMultipleOf2);
        }

        return result;
    }
}