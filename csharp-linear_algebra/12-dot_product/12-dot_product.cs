using System;

class VectorMath
{
    public static double DotProduct(double[] vector1, double[] vector2)
    {
        // Check if both vectors are of the same dimension (2D or 3D) and valid
        if ((vector1.Length == 2 || vector1.Length == 3) && vector1.Length == vector2.Length)
        {
            double dotProduct = 0;
            // Calculate the dot product
            for (int i = 0; i < vector1.Length; i++)
            {
                dotProduct += vector1[i] * vector2[i];
            }
            return dotProduct;
        }
        else
        {
            // Return -1 if the vectors are not both 2D or both 3D or not of the same dimension
            return -1;
        }
    }
}
