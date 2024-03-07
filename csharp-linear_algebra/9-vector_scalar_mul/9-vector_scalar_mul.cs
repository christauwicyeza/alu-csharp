using System;

class VectorMath{

    public static double[] Multiply(double[] vector, double scalar){
        if(vector.Length == 2){
            return new double[]{ vector[0] * scalar , vector[1] * scalar};
        }

        if(vector.Length == 3){
            return new double[]{ vector[0] * scalar, vector[1] * scalar, vector[2] * scalar};
        }

        return new double[]{-1};
    }
}