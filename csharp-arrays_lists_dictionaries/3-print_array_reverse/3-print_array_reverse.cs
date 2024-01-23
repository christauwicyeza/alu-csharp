using System;

public class Array
{
    public static void Reverse(int[]? array)
    {
        if (array == null)
        {
            Console.WriteLine();
            return;
        }

        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}
