using System;
using System.Collections.Generic;
using System.Reflection;

public class Obj
{
    public static void Print(object myObj)
    {
        Type type = myObj.GetType();
        Console.WriteLine($"{type.Name} Properties:");
        
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"{type.Name} Methods:");
        
        MethodInfo[] methods = type.GetMethods();
        var seenMethods = new HashSet<string>();
        
        foreach (MethodInfo method in methods)
        {
            // Exclude special names (property getters/setters, etc.) and avoid duplicates
            if (!method.IsSpecialName && seenMethods.Add(method.Name))
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
