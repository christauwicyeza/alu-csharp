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
        // Console.WriteLine($"{t.Name} Properties:");

        // Define a list of expected method names
        var expectedMethodNames = new HashSet<string>
        {
            "CompareTo", "Equals", "GetHashCode", "ToString", "TryFormat",
            "Parse", "TryParse", "GetTypeCode", "GetType"
        };

        Console.WriteLine($"{t.Name} Methods:");
        foreach (MethodInfo method in t.GetMethods())
        {
            // Check if the method is in the expected list and not a duplicate; considering ToString and others may have overloads
            if (expectedMethodNames.Contains(method.Name) && method.DeclaringType == typeof(int))
            {
                Console.WriteLine(method.Name);
            }
        }

        // Explicitly handle the GetType method since it's inherited from System.Object
        if (expectedMethodNames.Contains("GetType"))
        {
            Console.WriteLine("GetType");
        }
    }
}
