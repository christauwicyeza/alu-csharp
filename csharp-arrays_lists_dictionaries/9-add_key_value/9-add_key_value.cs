using System;
using System.Collections.Generic;

public class Dictionary
{
    public static Dictionary<string, string> AddKeyValue(Dictionary<string, string> myDict, string key, string value)
    {
        
        if (myDict.ContainsKey(key))
        {
            myDict[key] = value; 
        }
        else
        {
            myDict.Add(key, value); 
        }

        return myDict;
    }
}