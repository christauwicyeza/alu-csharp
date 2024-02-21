using System;
using System.Reflection;

class Obj
{
    public static void Print(object myObj)
    {
        // Get TypeInfo of the object
        TypeInfo tInfo = myObj.GetType().GetTypeInfo();

        // Print properties
        Console.WriteLine($"{tInfo.Name} Properties:");
        foreach (PropertyInfo prop in tInfo.GetProperties())
        {
            Console.WriteLine(prop.Name);
        }

        // Print methods, excluding property accessors and methods inherited from Object, 
        // unless it's the GetType method as it's specifically mentioned in the example
        Console.WriteLine($"{tInfo.Name} Methods:");
        foreach (MethodInfo method in tInfo.GetMethods())
        {
            // Check to exclude methods inherited from Object (except GetType)
            // and property accessors
            if ((method.DeclaringType == tInfo.AsType() || method.Name == "GetType") &&
                !method.IsSpecialName) // IsSpecialName is true for property accessors and event accessors
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
