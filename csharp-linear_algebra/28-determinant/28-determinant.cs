using System;

class MatrixMath
{
    public static double Determinant(double[,] matrix)
    {
        int size = matrix.GetLength(0);
        
        // Validate the matrix is square and either 2x2 or 3x3
        if (size != matrix.GetLength(1) || (size != 2 && size != 3))
        {
            return -1;
        }

        if (size == 2)
        {
            // Directly return the rounded determinant of a 2x2 matrix
            return Math.Round(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0], 2);
        }
        else
        {
            // Calculate the determinant of a 3x3 matrix using the rule of Sarrus
            double det = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                       - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                       + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
            return Math.Round(det, 2);
        }
    }
}
