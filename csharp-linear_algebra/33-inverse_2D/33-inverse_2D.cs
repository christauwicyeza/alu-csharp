using System;


class MatrixMath{

    public static double[,] Inverse2D(double[,] matrix){

         if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
        {
            return new double[,]{ {-1}};
        }

        double a = matrix[0, 0];
        double b = matrix[0, 1];
        double c = matrix[1, 0];
        double d = matrix[1, 1];

        double determinant = a * d - b * c;

        if (determinant == 0)
        {
            return new double[,] { { -1} }; 
        }

        double invDet = 1.0 / determinant;

        return new double[,]
        {
            { Math.Round(invDet * d, 2), Math.Round(-invDet * b, 2) },
            { Math.Round(-invDet * c, 2), Math.Round(invDet * a , 2)}
        };
    }


    /*
    public static double[,] Inverse2D(double[,] matrix){

       if(matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2){
            double determinant = Math.Round(((matrix[0,0] * matrix[1,1]) -  (matrix[0,1] * matrix[1,0])),2);
            if(determinant == 0){
                return new double[,]{{-1}};
            }

            return new double[,]{
                { matrix[1,1] * determinant, -(matrix[0,1] * determinant)},
                {-(matrix[1,0] * determinant), (matrix[0,0] * determinant)}
            };
       }

       return new double[,]{{-1}};
      
    }
    */
}