using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write($"{i:D2}");
            
            if (i < 99)
            {
                Console.Write(", ");
            }
        }
    }
}