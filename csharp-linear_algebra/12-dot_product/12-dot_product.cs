using System;

class VectorMath
{
    public static double DotProduct(double[] vector1, double[] vector2)
    {
        // Check if both vectors are of the same size and either 2D or 3D
        if ((vector1.Length == vector2.Length) && (vector1.Length == 2 || vector1.Length == 3))
        {
            // Calculate dot product
            double result = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                result += vector1[i] * vector2[i];
            }
            return result;
        }
        else
        {
            // Return -1 if vectors do not meet the criteria
            return -1;
        }
    }

    static void Main(string[] args)
    {
        // Example for 2D vectors
        double[] vector2D_1 = {1, 2};
        double[] vector2D_2 = {3, 4};
        Console.WriteLine("Dot Product of 2D vectors: " + DotProduct(vector2D_1, vector2D_2));

        // Example for 3D vectors
        double[] vector3D_1 = {1, 2, 3};
        double[] vector3D_2 = {4, 5, 6};
        Console.WriteLine("Dot Product of 3D vectors: " + DotProduct(vector3D_1, vector3D_2));

        // Example for invalid vector sizes
        double[] invalidVector1 = {1, 2};
        double[] invalidVector2 = {1, 2, 3};
        Console.WriteLine("Dot Product of mismatched vectors: " + DotProduct(invalidVector1, invalidVector2));
    }
}
