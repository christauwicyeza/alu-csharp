using System;
using System.Collections;

/*
class Program{
    public static void Main(string[] arg){
        double[,] testMatrix = {{5, 0, -2}, {1,-8,1}, {3, 2, 0}};
       //  double[,] testMatrix = {{1.2, -0.42}, {0.67, 2}};
       //double[,] testMatrix = {{11, 9, 7}, {2, 13, 1}, {4, 0, 17}};
      // double[,] testMatrix = {{1.2, 0.35, -0.42}, {0, -8, 6.21}, {3.89, -4, 0.67}};
        Console.WriteLine(" " + MatrixMath.Determinant(testMatrix));
    }
}

*/

class MatrixMath{

    public static double Determinant(double[,] matrix){
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols)
        {
            return -1; // Not a square matrix
        }

        if (rows == 2) // 2x2 matrix
        {
            return Math.Round(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0],2);
        }
        else if (rows == 3) // 3x3 matrix
        {
            double determinant = 0;
            determinant += matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]);
            determinant -= matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]);
            determinant += matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
            return Math.Round(determinant, 2);
        }
        else
        {
            return -1; 
        }

    }



    /*

    public static double Determinant(double[,] matrix){

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if((rows == 3 && cols == 3 ) || (rows == 2 && cols == 2)){

            if(rows == 2){
                return Math.Round(((matrix[0,0] * matrix[1,1]) -  (matrix[0,1] * matrix[1,0])),2);
            }

            if(rows == 3){
                double x = matrix[0,0] * ((matrix[1,1] * matrix[2,2]) - (matrix[2,1] * matrix[1,2]));
                double y = matrix[0,1] * ((matrix[1,0] * matrix[2,2]) - (matrix[2,0] * matrix[1,2]));
                double z = matrix[0,2] * ((matrix[1,0] * matrix[2,1]) - (matrix[2,0] * matrix[1,1]));

                return Math.Round((x - y - z),2);
            }
        }

        return -1;
    }
    */
}