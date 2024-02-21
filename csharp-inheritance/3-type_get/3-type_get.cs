using System;
using System.Collections.Generic;
using System.Reflection;

public class Obj
{
    public static void Print(object myObj)
    {
        Type type = myObj.GetType();
        Console.WriteLine($"{type.Name} Properties:");
        
        foreach (PropertyInfo property in type.GetProperties())
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"{type.Name} Methods:");
        
        var seenMethods = new HashSet<string>();
        
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
        {
            if (!method.IsSpecialName && seenMethods.Add(method.Name))
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}

class Dog
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Bark()
    {
        Console.WriteLine("Woof!");
    }

    public void Sit()
    {
        Console.WriteLine("Sits.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Obj.Print(98);
        Console.WriteLine("-----------------");
        Obj.Print(1.00);
        Console.WriteLine("-----------------");
        Obj.Print("hello, World");
        Console.WriteLine("-----------------");
        Obj.Print(new List<int>());
        Console.WriteLine("-----------------");
        Obj.Print(new Dictionary<int, string>());
        Console.WriteLine("-----------------");
        Obj.Print(new Dog());
    }
}
