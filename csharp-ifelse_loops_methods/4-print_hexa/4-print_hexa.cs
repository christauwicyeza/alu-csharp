using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 99; i++)
        {
            Console.Write($"{i} {(i < 98 ? "," : "\n")}");
        }
    }
}