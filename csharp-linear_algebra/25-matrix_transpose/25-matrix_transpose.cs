using System;

class MatrixMath{
    public static T[,] Transpose<T>(T[,] matrix){

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);


        if(rows == 0 && cols == 0){

            return new T[,]{{},{}};
        }

        T[,] TranposedMatrix = new T[cols, rows];

        for(int row = 0; row < rows ; row++){
            for(int col = 0; col < cols; col++){
        
                TranposedMatrix[col, row] = matrix[row, col];
            }
        }

        return TranposedMatrix;  
    }
}