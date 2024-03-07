/// <summary>
/// Represents a utility class for matrix math operations.
/// </summary>

class MatrixMath
{
    /// <summary>
    /// Calculates the inverse of a 2D matrix.
    /// </summary>
    /// <param name="matrix">The input matrix.</param>
    /// <returns>The inverse of the input matrix, or [-1] if the matrix is not 2D or non-invertible.</returns>
    public static double[,] Inverse2D(double[,] matrix)
    {
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,] { { -1 } };
        }

        double determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        if (determinant == 0)
        {
            return new double[,] { { -1 } };
        }

        double[,] inverse = new double[2, 2];

        inverse[0, 0] = matrix[1, 1] / determinant;
        inverse[0, 1] = -matrix[0, 1] / determinant;
        inverse[1, 0] = -matrix[1, 0] / determinant;
        inverse[1, 1] = matrix[0, 0] / determinant;

        return inverse;
    }
}