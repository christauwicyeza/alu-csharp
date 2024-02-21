using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Obj
{
    public static void Print(object myObj)
    {
        TypeInfo t = myObj.GetType().GetTypeInfo();
        Console.WriteLine($"{t.Name} Properties:");

        foreach (PropertyInfo p in t.GetProperties())
        {
            Console.WriteLine(p.Name);
        }

        // Filtering to include base type methods if they are 'GetType'
        var methods = t.GetMethods().Where(m => m.DeclaringType == myObj.GetType() || m.Name == "GetType").Distinct().ToList();

        // Further refine the list to ensure uniqueness by method signature
        var uniqueMethods = methods.GroupBy(m => m.Name)
                                   .SelectMany(g => g.Count() > 1 ? g.Where(m => m.GetParameters().Length == 0) : g)
                                   .ToList();

        Console.WriteLine($"{t.Name} Methods:");
        foreach (MethodInfo m in uniqueMethods)
        {
            Console.WriteLine(m.Name);
        }
    }
}
