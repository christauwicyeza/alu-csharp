using System;

class MatrixMath
{
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2){
        if (matrix1.Length == 0 ||
            matrix2.Length == 0 ||
            matrix1.GetLength(1) != matrix2.GetLength(0)){
            return (new double[,]{{-1}});
        }

        double[,] finalResult = new double[matrix1.GetLength(0),matrix2.GetLength(1)];
        double result = 0.0;

        for (int y = 0; y < matrix1.GetLength(0); y++){
            for (int x2 = 0; x2 < matrix2.GetLength(1); x2++){
                result = 0;
                for (int x = 0; x < matrix1.GetLength(1); x++){
                    result += matrix1[y,x] * matrix2[x, x2];
                }
                finalResult[y, x2] = Math.Round(result, 2);
            }
        }
        return finalResult;;  
    }

    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
         if (matrix.Length == 0 ||
             matrix.GetLength(1) != 2 ||
            matrix.GetLength(1) != matrix.GetLength(0)){
            return (new double[,]{{-1}});
        }

        double[,] temp = new double[2,2];
        if (Char.ToLower(direction).Equals('x'))
        {
           temp = new double[2,2]{{1, factor},{0,1}};
        }
        else if (Char.ToLower(direction).Equals('y'))
        {
           temp = new double[2,2]{{1, 0},{factor,1}};
        }
        else
        {
            return (new double[,]{{-1}});
        }
        matrix = new Double[2,2]{{matrix[0,0], matrix[1,0]},{matrix[0,1], matrix[1,1]}};
        matrix = Multiply(temp, matrix);
        matrix = new Double[2,2]{{matrix[0,0], matrix[1,0]},{matrix[0,1], matrix[1,1]}};
        return matrix;
    }
}