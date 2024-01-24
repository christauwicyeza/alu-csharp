using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[5, 5];  // Create a 5x5 array initialized to 0

        matrix[2, 2] = 1;  // Set the element at index [2,2] to 1

        // Print the array
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + (j < matrix.GetLength(1) - 1 ? " " : "\n"));
            }
        }
    }
}