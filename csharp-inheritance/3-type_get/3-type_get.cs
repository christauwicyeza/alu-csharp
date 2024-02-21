using System.Reflection;
using System;
using System.Collections.Generic;


/*
TypeInfo t = typeof(Calendar).GetTypeInfo();
IEnumerable<PropertyInfo> pList = t.DeclaredProperties;
IEnumerable<MethodInfo> mList = t.DeclaredMethods;

StringBuilder sb = new StringBuilder();

sb.Append("Properties:");
foreach (PropertyInfo p in pList)
{

    sb.Append("\n" + p.DeclaringType.Name + ": " + p.Name);
}
sb.Append("\nMethods:");
foreach (MethodInfo m in mList)
{
    sb.Append("\n" + m.DeclaringType.Name + ": " + m.Name);
}

Console.WriteLine(sb.ToString());
*/


class Obj {


    public static void Print(object myObj){

        TypeInfo t =  myObj.GetType().GetTypeInfo();
        // IEnumerable<PropertyInfo> pList  = t.DeclaredProperties;
        IEnumerable<PropertyInfo> pList = t.GetProperties();
        //Console.WriteLine(pList.First().DeclaringType.Name + " Properties:");
        Console.WriteLine($"{t.Name} Properties:");
 
        //StringBuilder sb = new StringBuilder();
        //sb.Append(pList.First().DeclaringType.Name + " Properties:");



        foreach(PropertyInfo p in pList){
         //if(p.Attributes == None){

          //  }
            Console.WriteLine(p.Name);
           // sb.Append("\n" + p.Name);
        }

        IEnumerable<MethodInfo> pMethod = t.GetMethods();
        // Console.WriteLine(pMethod.First().DeclaringType.Name + " Methods:");
        // sb.Append(pMethod.First().DeclaringType.Name + " Method:");
        Console.WriteLine($"{t.Name} Methods:");

        foreach(MethodInfo m in pMethod){
            if(m.DeclaringType == myObj.GetType()){
                 Console.WriteLine(m.Name);
            }
            // Console.WriteLine(m.Name);
          
           // sb.Append("\n" + m.Name);
        }

        // Console.WriteLine(sb.ToString());

        

    }
}
