using System;
using System.Collections.Generic;
using System.Reflection;

class Obj
{
    public static void Print(object myObj)
    {
        TypeInfo t = myObj.GetType().GetTypeInfo();
        IEnumerable<PropertyInfo> pList = t.GetProperties();
        Console.WriteLine($"{t.Name} Properties:");

        foreach (PropertyInfo p in pList)
        {
            Console.WriteLine(p.Name);
        }

        IEnumerable<MethodInfo> pMethod = t.GetMethods();
        Console.WriteLine($"{t.Name} Methods:");

        foreach (MethodInfo m in pMethod)
        {
            // Print only the methods declared in the type of myObj,
            // excluding inherited methods, unless overridden.
            if (m.DeclaringType == myObj.GetType())
            {
                Console.WriteLine(m.Name);
            }
        }
    }
}
