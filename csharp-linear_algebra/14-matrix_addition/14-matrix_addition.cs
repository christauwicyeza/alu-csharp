using System;

class MatrixMath{

    public static double[,] Add(double[,] matrix1, double[,] matrix2){

        if(matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1) && matrix1.GetLength(0) == 2){
            for(int i = 0; i < matrix1.GetLength(0); i++){
                for(int j = 0 ; j < matrix1.GetLength(1); j++){
                    matrix1[i,j] = matrix1[i,j] + matrix2[i,j];
                }
            }

            return matrix1;
        }

        if(matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1) && matrix1.GetLength(0) == 3){
            for(int i = 0; i < matrix1.GetLength(0); i++){
                for(int j = 0 ; j < matrix1.GetLength(1); j++){
                    matrix1[i,j] = matrix1[i,j] + matrix2[i,j];
                }
            }

            return matrix1;
        }

        return new double[,]{ {-1}};


    }
}