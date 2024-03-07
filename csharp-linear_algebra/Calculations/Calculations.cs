using System;

class Program{

    public static void Main(string[] args){

        Console.WriteLine("VectorSum : " + SumVectors3D(13,-2,0,-3,23,50)[0] + " : "  + SumVectors3D(13,-2,0,-3,23,50)[1]  + " : " + SumVectors3D(13,-2,0,-3,23,50)[2] );
    }

    // calculating pythagoras length
    public static double Pythagoras(int a, int b){

        int AB = (int) Math.Pow(a, 2);
        int BC = (int) Math.Pow(b, 2);

        double AC = Math.Round(Math.Sqrt(AB + BC), 2);

        return AC;
    }

    public static double Pythagoras3D(double x, double y, double z){
        double result = Math.Round(Math.Sqrt( Math.Pow(x,2) + Math.Pow(y, 2) + Math.Pow(z, 2)), 2);
        return result;
    }

    public static double[] SumVectors(double x1, double y1, double x2, double y2){

        double[] result = new double[2];
        result[0] = x1 + x2;
        result[1] = y1 + y2;
        return result;
    }

    public static double[] SumVectors3D(double x1, double y1, double z1, double x2, double y2, double z2){
        double[] result = new double[3];
        result[0] = x1 + x2;
        result[1] = y1 + y2;
        result[2] = z1 + z2;
        return result;
    }

    

  
}