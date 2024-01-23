using System;

public class Array
{
    public static void Reverse(int[] array)
    {
        if (array == null)
        {
            Console.WriteLine("Array is null");
            return;
        }

        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        int[] myArray = { 1, 2, 3, 4, 5 };

        Console.WriteLine("Original Array:");
        PrintArray(myArray);

        Console.WriteLine("Reversed Array:");
        Array.Reverse(myArray);
    }

    static void PrintArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}