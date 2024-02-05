using System;
using System.Collections.Generic;

public class ListUtils
{
    public static List<int> Divide(List<int> list1, List<int> list2, int listLength)
    {
        List<int> divisionResults = new List<int>();

        try
        {
            for (int i = 0; i < listLength; i++)
            {
                try
                {
                    int result = list1[i] / list2[i];
                    divisionResults.Add(result);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Out of range");
                    return new List<int>(); // Return an empty list if either list is too short
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero");
                    divisionResults.Add(0); // Add 0 to the divisionResults list if division by zero occurs
                }
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Out of range");
        }

        return divisionResults;