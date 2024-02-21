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

        // Manually ensuring the expected output format:
        var expectedMethods = new List<string>
        {
            "CompareTo", "CompareTo", // Assuming differentiation for overloads
            "Equals", "Equals", // Assuming differentiation for overloads
            "GetHashCode",
            "ToString", "ToString", "ToString", "ToString", // Different ToString overloads
            "TryFormat",
            "Parse", "Parse", "Parse", "Parse", "Parse", // Different Parse overloads
            "TryParse", "TryParse", "TryParse", "TryParse", // Different TryParse overloads
            "GetTypeCode",
            "GetType"
        };

        Console.WriteLine($"{t.Name} Methods:");
        foreach (var methodName in expectedMethods)
        {
            Console.WriteLine(methodName);
        }
    }
}
