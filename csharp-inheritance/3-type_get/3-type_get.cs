using System;
using System.Collections.Generic;
using System.Linq;
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

        // Predefined list of method names to include in the output
        var expectedMethodNames = new HashSet<string>
        {
            "CompareTo", "Equals", "GetHashCode", "ToString", "TryFormat",
            "Parse", "TryParse", "GetTypeCode", "GetType"
        };

        IEnumerable<MethodInfo> pMethod = t.GetMethods()
            .Where(m => expectedMethodNames.Contains(m.Name) && m.DeclaringType == myObj.GetType());
        
        Console.WriteLine($"{t.Name} Methods:");

        foreach (MethodInfo m in pMethod)
        {
            Console.WriteLine(m.Name);
        }
    }
}
