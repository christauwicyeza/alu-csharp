
using System;



/// <summary>
/// Shape class is based class for all shapes
/// </summary>
public class Shape{


/// <summary>
/// Emtpy area calculation
/// </summary>
/// <returns></returns>
/// <exception cref="NotImplementedException"></exception>
    public virtual int Area(){
        throw new NotImplementedException("Area() is not implemented");
    }

}

/// <summary>
/// Class Rectangle which inherits from Shape
/// </summary>
public class Rectangle : Shape{

// width of rectangle
    private int width;
    // height of rectangle
    private int height;

/// <summary>
/// managees width
/// </summary>
    public int Width{
        get { return width ;}
        set { 
            if( value < 0){
            throw new ArgumentException("Width must be greater than or equal to 0");
        }
        width = value;
        }
    }

/// <summary>
/// manages height
/// </summary>
    public int Height{

        get { return height;}
        set { if(value < 0){
            throw new ArgumentException("Height must be greater than or equal to 0");
        }

        height = value;
        }

    }

/// <summary>
/// Calculates area of rectangle
/// </summary>
/// <returns> Area of rectangle</returns>
    public override int Area(){
        return height * width;
    }

/// <summary>
/// Local representation of the Rectangle in string format
/// </summary>
/// <returns>String</returns>
    public override string ToString(){

        return $"[Rectangle] {width} / {height}";
    }
}


/// <summary>
/// Square derived class from Rectangle
/// </summary>
public class Square : Rectangle{

// size of Square
    private int size;

/// <summary>
/// getter and setter of the Size
/// </summary>
    public int Size{
        get { return size ; }
        set {  if (value < 0 ){
            throw new ArgumentException("Size must be greater than or equal to 0");
        }
            size = value;
            Height = value;
            Width = value;
        }
    }

    /// <summary>
    /// Format string return for square type
    /// </summary>
    /// <returns>String</returns>
     public override string ToString(){

        return $"[Square] {size} / {size}";
    }


}