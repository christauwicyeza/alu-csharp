using System;
using System.Collections.Generic;

public class LList
{
    public static int Sum(LinkedList<int> myLList)
    {
        int sum = 0;

        if (myLList == null)
        {
            return sum;
        }

        foreach (int value in myLList)
        {
            sum += value;
        }

        return sum;
    }
}