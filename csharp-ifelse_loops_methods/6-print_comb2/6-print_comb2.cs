using System;

class Program
{
    static void Main(string[] args)
    {
        for (int firstDigit = 0; firstDigit <= 9; firstDigit++)
        {
            for (int secondDigit = firstDigit + 1; secondDigit <= 9; secondDigit++)
            {
                Console.Write($"{firstDigit}{secondDigit}");
                if (!(firstDigit == 8 && secondDigit == 9))
                {
                    Console.Write(", ");
                }
            }
        }
        Console.WriteLine();
    }
}
