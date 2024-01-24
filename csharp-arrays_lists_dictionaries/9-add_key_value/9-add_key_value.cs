using System;
using System.Collections.Generic;

public class Dictionary
{
    public static Dictionary<string, string> AddKeyValue(Dictionary<string, string> myDict, string key, string value)
    {
        // Check if the key exists and add or update accordingly
        if (myDict.ContainsKey(key))
        {
            myDict[key] = value; // Update the existing key's value
        }
        else
        {
            myDict.Add(key, value); // Add the new key-value pair
        }

        return myDict;
    }
}