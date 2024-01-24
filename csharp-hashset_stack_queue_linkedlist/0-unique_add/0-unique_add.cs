using System;
using System.Collections.Generic;
using System.Linq;

public class List
{
    public static int Sum(List<int> myList)
    {
        HashSet<int> uniqueElements = new HashSet<int>(myList);
        return uniqueElements.Sum();
    }
}