using System;
using System.Linq;
using System.Reflection;

public class Obj
{
    public static void Print(object myObj)
    {
        if (myObj == null)
        {
            Console.WriteLine("The object is null");
            return;
        }

        // Getting the type information of the object
        Type type = myObj.GetType();
        Console.WriteLine($"{type.Name} Properties:");

        // Getting and printing all public properties of the object
        PropertyInfo[] properties = type.GetProperties();
        foreach (var property in properties)
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"{type.Name} Methods:");
        // Getting and printing all public methods of the object, including inherited methods
        MethodInfo[] methods = type.GetMethods().Where(m => m.DeclaringType == type || !m.IsSpecialName).Distinct().ToArray();

        foreach (var method in methods)
        {
            Console.WriteLine(method.Name);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var num = 10;
        var myList = new List<int>();

        Obj.Print(num);
        Console.WriteLine("-----------------");
        Obj.Print(myList);
    }
}
