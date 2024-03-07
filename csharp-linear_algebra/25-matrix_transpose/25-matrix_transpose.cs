/// <summary>
/// Represents a utility class for matrix math operations.
/// </summary>

class MatrixMath
{
    /// <summary>
    /// Transposes a matrix and returns the resulting matrix.
    /// </summary>
    /// <param name="matrix">The matrix to be transposed.</param>
    /// <returns>The transposed matrix, or an empty matrix if the input matrix is empty.</returns>
    public static double[,] Transpose(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows == 0 || cols == 0)
        {
            return new double[0, 0];
        }

        double[,] transposedMatrix = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposedMatrix[j, i] = matrix[i, j];
            }
        }

        return transposedMatrix;
    }
}