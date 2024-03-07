using System;

class MatrixMath{

    public static double[,] MultiplyScalar(double[,] matrix, double scalar){

        if(matrix.GetLength(1) == 2 || matrix.GetLength(1) == 3){

            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for(int i = 0; i < matrix.GetLength(0); i++){
                for(int j = 0; j < matrix.GetLength(1); j++){
                    result[i,j] = scalar * matrix[i,j];
                }
            }
            return result;
        }

        return new double[,]{{-1}};
    }
}