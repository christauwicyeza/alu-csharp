using System;
using System.Collections.Generic;

public class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        HashSet<int> uniqueElements = new HashSet<int>();

        // Add unique elements from list1
        foreach (int item in list1)
        {
            if (!list2.Contains(item))
            {
                uniqueElements.Add(item);
            }
        }

        // Add unique elements from list2
        foreach (int item in list2)
        {
            if (!list1.Contains(item))
            {
                uniqueElements.Add(item);
            }
        }

        // Convert HashSet to List and sort
        List<int> resultList = new List<int>(uniqueElements);
        resultList.Sort();
        return resultList;
    }
}