using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 99; i++)
        {
            Console.Write($"{i:D} = 0x{i:X}");
            Console.Write(i < 98 ? ", " : "\n");
        }
    }
}