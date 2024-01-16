using System;

public class Line
{
    public static void PrintLine(int length)
    {
        if (length > 0)
        {
            Console.WriteLine(new string('_', length));
        }
        else
        {
            Console.WriteLine();
        }
    }

    static void Main()
    {
        // Example usage:
        PrintLine(5);
    }
}