using System;

class VectorMath
{
    public static double DotProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length != vector2.Length || (vector1.Length < 2 || vector1.Length > 3))
        {
            return -1; // Return -1 if vectors are not the same size or not 2D or 3D
        }

        double result = 0;
        switch (vector1.Length)
        {
            case 2:
            case 3:
                for (int i = 0; i < vector1.Length; i++)
                {
                    result += vector1[i] * vector2[i];
                }
                break;
            default:
                return -1;
        }
        return result;
    }
}
