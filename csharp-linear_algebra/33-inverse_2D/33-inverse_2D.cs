using System;

class MatrixMath
{
    public static double[,] Inverse2D(double[,] matrix)
    {
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } };
        }

        double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        if (det == 0)
        {
            return new double[,] { { -1 } };
        }

        double invDet = 1.0 / det;
        double[,] inverse = new double[,]
        {
            { Math.Round(matrix[1, 1] * invDet, 2), Math.Round(-matrix[0, 1] * invDet, 2) },
            { Math.Round(-matrix[1, 0] * invDet, 2), Math.Round(matrix[0, 0] * invDet, 2) }
        };

        return inverse;
    }
}
