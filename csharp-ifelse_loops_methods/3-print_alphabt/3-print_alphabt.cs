using System;
class Program
{
    static void Main(string[] args)
    {
        for (char letter = 'a'; letter <= 'z'; letter++)
        {
            if (letter != 'q' && letter != 'e')
            {
                Console.Write(letter);
            }
        }
    }
}
