using System;
using System.Collections;
using System.Collections.Generic;

class VectorMath{
    public static double Magnitude(double[] vector){
    
        if(vector.Length == 2){
            return Math.Round(Math.Sqrt(Math.Pow(vector[0], 2) + Math.Pow(vector[1], 2)), 2);
        }

        if(vector.Length == 3){
             return Math.Round(Math.Sqrt(Math.Pow(vector[0], 2) + Math.Pow(vector[1], 2) + Math.Pow(vector[2], 2)), 2);
        }

        return -1; // Return -1 if the vector is not 2D or 3D
    }

    static void Main(string[] args){
        // Example for a 2D vector
        double[] vector2D = {3, 4};
        double magnitude2D = Magnitude(vector2D);
        Console.WriteLine($"The magnitude of the 2D vector is: {magnitude2D}");

        // Example for a 3D vector
        double[] vector3D = {1, 2, 2};
        double magnitude3D = Magnitude(vector3D);
        Console.WriteLine($"The magnitude of the 3D vector is: {magnitude3D}");
    }
}
