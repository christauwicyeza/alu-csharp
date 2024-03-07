using System;

class MatrixMath
{
    public static double[,] Inverse2D(double[,] matrix)
    {
        // Check if the matrix is 2x2
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } };
        }

        // Calculate the determinant of the matrix
        double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        // Check if the matrix is non-invertible
        if (det == 0)
        {
            return new double[,] { { -1 } };
        }

        // Calculate the inverse of the matrix
        double invDet = 1.0 / det;
        double[,] inverse = new double[,]
        {
            { matrix[1, 1] * invDet, -matrix[0, 1] * invDet },
            { -matrix[1, 0] * invDet, matrix[0, 0] * invDet }
        };

        return inverse;
    }
}
