using System.Collections.Generic;

class ListHelper
{
    public static List<bool> CheckMultiplesOf2(List<int> myList)
    {
        List<bool> BoolList = new List<bool>();

        foreach (int value in myList)
        {
            if (value % 2 == 0)
            {
                BoolList.Add(true);
            }
            else
            {
                BoolList.Add(false);
            }
        }

        return BoolList;
    }
}
