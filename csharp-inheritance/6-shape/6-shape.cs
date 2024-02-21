using System;


/// <summary>
/// Base class for all shapes to be represented. 
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
/// Rectangle class inherits from Shapes class
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

}