using System;
using System.Collections.Generic;

public class List
{
    public static List<int> CreatePrint(int size)
    {
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        List<int> numberList = new List<int>();

        for (int i = 0; i < size; i++)
        {
            numberList.Add(i);
            Console.Write(i);

            // Add a space after each element except the last one
            if (i < size - 1)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
        Console.WriteLine("List Length: " + numberList.Count);
        return numberList;
    }
}
