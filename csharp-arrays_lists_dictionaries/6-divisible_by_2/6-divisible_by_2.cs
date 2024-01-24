using System.Collections;

class List
{
    public static List<bool> CheckMultiplesOf2(List<int> numbersToCheck)
    {
        List<bool> isDivisibleBy2 = new List<bool>();

        foreach (int value in numbersToCheck)
        {
            if (value % 2 == 0)
            {
                isDivisibleBy2.Add(true);
            }
            else
            {
                isDivisibleBy2.Add(false);
            }
        }

        return isDivisibleBy2;
    }
}