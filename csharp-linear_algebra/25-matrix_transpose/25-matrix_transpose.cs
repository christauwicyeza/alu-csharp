using System;
/*
class Program{
    public static void Main(string[] args){
        double[,] emtpy = {{}, { }};
        double[,] result = MatrixMath.Transpose(emtpy);
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
*/

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