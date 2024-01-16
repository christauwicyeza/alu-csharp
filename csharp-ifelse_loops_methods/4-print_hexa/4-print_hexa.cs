using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i <= 98; i++)
        {
            Console.Write($"{i} {(i < 98 ? " " : "\n")}{i:X}");
        }
    }
}