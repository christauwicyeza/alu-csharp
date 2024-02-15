using System;

namespace MyMath{
    public class Matrix{
        
        /// <summary>
        /// Divides matrix by certain number
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[,] Divide(int[,] matrix, int num){
            try{
                if(num == 0){
                    Console.WriteLine("Num cannot be 0");
                    return null;
                }

                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);
                int[,] newMatrix = new int[rows, columns];

                for(int i = 0; i < rows; i++){
                    for(int j = 0; j < columns; j++){
                        newMatrix[i,j] = (matrix[i,j] / num);
                    }
                }

                return newMatrix;

            }catch(Exception e){
                     return null;
            }
               
        }
        }
    }