using System;
using System.Collections.Generic;
using System.Linq;

public class Dictionary
{
    public static void PrintSorted(Dictionary<string, string> myDict)
    { 
        var sortedKeys = myDict.Keys.OrderBy(key => key).ToList();

        foreach (var key in sortedKeys)
        {
            Console.WriteLine("{0}: {1}", key, myDict[key]);
        }
    }
}