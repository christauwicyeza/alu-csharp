using System;
using System.Collections.Generic;
using System.Reflection;

class Obj
{
    /// <summary>
    /// Prints the names of the available properties and methods of an object.
    /// </summary>
    /// <param name="myObj">The object to inspect.</param>
    public static void Print(object myObj)
    {
        TypeInfo typeInfo = myObj.GetType().GetTypeInfo();
        IEnumerable<PropertyInfo> properties = typeInfo.DeclaredProperties;
        IEnumerable<MethodInfo> methods = typeInfo.DeclaredMethods;

        Console.WriteLine($"{typeInfo.Name} Properties:");
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"{typeInfo.Name} Methods:");
        foreach (MethodInfo method in methods)
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
