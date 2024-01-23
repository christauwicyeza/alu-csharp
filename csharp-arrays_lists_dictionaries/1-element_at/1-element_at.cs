using System;

class Array
{
    public static int[] CreatePrint(int size)
    {
        if (size == 0)
        {
            Console.WriteLine();
            return new int[0];
        }
        else if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        int[] NumberList = new int[size];
        for (int i = 0; i < size; i++)
        {
            NumberList[i] = i;
            if (i < size - 1)
            {
                Console.Write($"{i} ");
            }
            else
            {
                Console.Write($"{i}");
            }
        }
        Console.WriteLine();

        return NumberList;
    }
}