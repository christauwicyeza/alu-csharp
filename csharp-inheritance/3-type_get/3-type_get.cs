using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Example object
        var exampleObject = new ExampleClass();
        Obj.Print(exampleObject);

        Console.WriteLine("-----------------");

        // Example with a built-in type
        var myList = new List<int>();
        Obj.Print(myList);

        Console.WriteLine("-----------------");

        // Primitive type example
        int number = 42;
        Obj.Print(number);
    }
}

class ExampleClass
{
    public int ExampleProperty { get; set; }
    public void ExampleMethod()
    {
        Console.WriteLine("Method invoked");
    }
}

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
            if (m.DeclaringType == myObj.GetType())
            {
                Console.WriteLine(m.Name);
            }
        }
    }
}
