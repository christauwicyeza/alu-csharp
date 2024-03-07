using System;

public class MatrixMath
{

    public static double[,] Shear2D(double[,] matrix, char direction, double factor){
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];
        double[,] mMatrix = new double[rows, cols];

        if(rows != 2 || cols != 2){
            
            return new double[,]{ {-1}};
        }


        if(direction != 'x' && direction != 'y'){
           
            return new double[,] { { -1}};
        }
        

        // create matrix 
        if(direction == 'x'){
            
         mMatrix = new double[,]{ 
                { 1, 0},
                { factor, 1}
        };
        }

        if(direction == 'y'){
             mMatrix = new double[,]{
                { 1, factor},
                { 0, 1}
            };
        }

        for(int i = 0; i < rows; i++){

                for(int j = 0; j < cols; j++){
                
                  for(int u = 0; u < 2; u++){
                        result[i,j] += Math.Round(matrix[i, u] * mMatrix[u, j], 2);
                }
            }
        }

        return result;

    }
}


/*
class Program
{
    public static void Main(string[] arg)
    {
        double[,] matrix = {
            { 1, 2 },
            { 3, 4 }
        };

        double shearFactorX = 2.2; // Shear along X-axis
        // Shear along Y-axis

        double[,] shearedMatrixX = MatrixMath.Shear2D(matrix, 'y', 2.2);
      

        // Output the sheared matrix
        for (int i = 0; i < shearedMatrixX.GetLength(0); i++)
        {
            for (int j = 0; j < shearedMatrixX.GetLength(1); j++)
            {
                Console.Write($"{shearedMatrixX[i, j]} ");
            }
            Console.WriteLine();
        }

     
   
    }
}
*/
