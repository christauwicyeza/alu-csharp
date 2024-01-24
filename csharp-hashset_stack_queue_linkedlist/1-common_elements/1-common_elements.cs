using System;
using System.Collections.Generic;

public class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        HashSet<int> set1 = new HashSet<int>(list1);
        List<int> commonElements = new List<int>();

        foreach (int element in list2)
        {
            if (set1.Contains(element))
            {
                commonElements.Add(element);
            }
        }

        commonElements.Sort(); // Manually sort the list
        return commonElements;
    }
}