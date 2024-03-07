using System;

class Program
{
    public static void Main(string[] arg)
    {
        double[,] TestMatrix = { { 1, 2 }, { 3, 4 } };

        // Assume angle is in radians for this example; for degrees, convert first
        double radians = 1; // Example angle in radians
        double[,] resultMatrix = MatrixMath.Rotate2D(TestMatrix, radians);

        Console.WriteLine($"{resultMatrix[0,0]}  --  {resultMatrix[0,1]}\n{resultMatrix[1,0]}  --  {resultMatrix[1,1]}");
    }
}

class MatrixMath
{
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        double[,] rotationMatrix = {
            { Math.Cos(angle), -Math.Sin(angle) }, // Corrected sign for standard counterclockwise rotation
            { Math.Sin(angle), Math.Cos(angle) }
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows == cols && rows == 2)
        {
            double[,] result = new double[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j] += Math.Round(matrix[i, k] * rotationMatrix[k, j], 2);
                    }
                }
            }

            return result;
        }

        return new double[,] { { -1 } };
    }
}