using System;

class Program{
    
    public static void Main(string[] arg){
        
        double[,] TestMatrix = { { 1, 2}, {3, 4} };
        // Assuming you want to rotate by 90 degrees (π/2 radians)
        double angleInDegrees = 90;
        double angleInRadians = angleInDegrees * (Math.PI / 180); // Convert to radians

        double[,] resultMatrix = MatrixMath.Rotate2D(TestMatrix, angleInRadians);
        
        Console.WriteLine($"{resultMatrix[0,0]}  --  {resultMatrix[0,1]}\n{resultMatrix[1,0]}  --  {resultMatrix[1,1]}");

    }
}

class MatrixMath{
    public static double[,] Rotate2D(double[,] matrix, double angle){
        double[,] rotationMatrix = {
            { Math.Cos(angle), -Math.Sin(angle) }, // Corrected the sign for a standard rotation matrix
            { Math.Sin(angle), Math.Cos(angle) }
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if(rows == cols && rows == 2){
         
         double[,] result = new double[rows,rows];

         for (int col = 0; col < cols; col++){
            for (int row = 0; row < rows; row++){
                result[row, col] = 0;
                for (int k = 0; k < rows; k++){
                    result[row, col] += Math.Round(rotationMatrix[row, k] * matrix[k, col], 2);
                }
            }
         }

         return result;
        }

        return new double[,]{{-1}};
    }
}
