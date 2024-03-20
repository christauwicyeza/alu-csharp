using System;
using System.Collections.Generic;
using System.Reflection;

    /// <summary>Represents the class Obj.</summary>

public class Obj
{
    /// <summary>
    /// prints the names of the available properties and methods of an object.
    /// </summary>
    /// <param name="myObj">Object from where to get informations.</param>
    public static void Print(object myObj)
    {
        Type type = myObj.GetType();
        
        Console.WriteLine($"{type.Name} Properties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine(prop.Name);
        }
        
        Console.WriteLine($"{type.Name} Methods:");
        foreach (MethodInfo method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }
    }
}
