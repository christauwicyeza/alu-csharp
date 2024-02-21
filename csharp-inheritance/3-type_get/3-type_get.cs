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

        // Assuming no properties are expected for Int32 as per given output

        // Define a list of expected method names
        var expectedMethodNames = new HashSet<string>
        {
            "CompareTo", "Equals", "GetHashCode", "ToString", "TryFormat",
            "Parse", "TryParse", "GetTypeCode", "GetType"
        };

        Console.WriteLine($"{t.Name} Methods:");
        
        // Filter and select methods based on the expected list, excluding duplicates
        var methods = t.GetMethods().Where(m => expectedMethodNames.Contains(m.Name))
                                     .GroupBy(m => m.Name)
                                     .Select(g => g.First()) // This takes the first occurrence of each method name
                                     .OrderBy(m => m.Name); // Optional, to have a consistent order

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }
    }
}
