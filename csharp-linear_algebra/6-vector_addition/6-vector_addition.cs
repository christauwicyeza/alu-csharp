using System;


class VectorMath{
    public static double[] Add(double[] vector1, double[] vector2){

         if(vector1.Length == 2 && vector2.Length == 2){
            return new double[]{ vector1[0] + vector2[0] , vector1[1] + vector2[1]};
         }

         if(vector1.Length == 3 && vector2.Length == 3){
            return new double[]{ vector1[0] + vector2[0], vector1[1] + vector2[1], vector1[2] + vector2[2] };
         }

         return new double[]{-1};
    }
}