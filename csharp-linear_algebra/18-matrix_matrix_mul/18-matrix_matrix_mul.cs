using System;

class MatrixMath{

    public static double[,] Multiply(double[,] matrix1, double[,] matrix2){

        int rowA = matrix1.GetLength(0);
        int colA = matrix1.GetLength(1);
        int rowB = matrix2.GetLength(0);
        int colB = matrix2.GetLength(1);

        double[,] result = new double[rowA, colB];
       
        if(colA == rowB){
            for(int i = 0; i < rowA; i++){

                for(int j = 0; j < colB; j++){
                  
                  for(int u = 0; u < colA; u++){
                        result[i,j] += matrix1[i, u] * matrix2[u, j];
                  }
                }
            }

            return result;
        }

        return new double[,]{{-1}};
    }
}