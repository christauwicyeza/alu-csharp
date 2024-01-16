using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 99; i++)
        {
            Console.Write($"{i:D} = 0x{i:X}");
            if (i < 98)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}