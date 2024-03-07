using System;
using System.Linq;

class VectorMath
{
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length != 3 || vector2.Length != 3)
        {
            return new double[] { -1 };
        }

        double[] result = new double[]
        {
            vector1[1] * vector2[2] - vector1[2] * vector2[1],
            vector1[2] * vector2[0] - vector1[0] * vector2[2],
            vector1[0] * vector2[1] - vector1[1] * vector2[0]
        };

        result = result.Select(x => x == -0.0 ? 0.0 : x).ToArray();
        return result;
    }
    
    public static string FormatVector(double[] vector)
    {
        return $"({string.Join(", ", vector.Select(x => x.ToString()))})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        double[] vector1 = { /* your vector1 elements */ };
        double[] vector2 = { /* your vector2 elements */ };

        double[] crossProductResult = VectorMath.CrossProduct(vector1, vector2);
        string formattedResult = VectorMath.FormatVector(crossProductResult);

        Console.WriteLine(formattedResult);
    }
}
