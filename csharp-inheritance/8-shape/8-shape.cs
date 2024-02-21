using System;

public class Shape
{
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
}

public class Rectangle : Shape
{
    private int width;
    private int height;

    public int Width
    {
        get { return width; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width must be greater than or equal to 0");
            }
            width = value;
        }
    }

    public int Height
    {
        get { return height; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height must be greater than or equal to 0");
            }
            height = value;
        }
    }

    public override int Area()
    {
        return height * width;
    }

    public override string ToString()
    {
        return $"[Rectangle] {width} / {height}";
    }
}

public class Square : Rectangle
{
    private int size;

    public int Size
    {
        get { return size; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Size must be greater than or equal to 0");
            }
            size = value;
            Height = value;
            Width = value;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Rectangle rectangle = new Rectangle { Width = 5, Height = 10 };
        Console.WriteLine(rectangle.ToString());
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");

        Square square = new Square { Size = 4 };
        Console.WriteLine(square.ToString());
        Console.WriteLine($"Square Area: {square.Area()}");
    }
}
