using System;

class Program
{
    static void Main(string[] args)
    {
        // Loop through the alphabet and print each letter (excluding 'q' and 'e') without a newline
        for (char letter = 'a'; letter <= 'z'; letter++)
            if (letter == 'q' || letter == 'e')
            {
                continue;
            }
            Console.Write(letter);
        }
    }
