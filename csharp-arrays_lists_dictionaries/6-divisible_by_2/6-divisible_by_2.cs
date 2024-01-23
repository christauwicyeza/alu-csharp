using System.Collections;

class List
{
    public static List<bool> CheckMultiplesOf2(List<int> inputList)
    {
        List<bool> result = new List<bool>();

        foreach (int number in inputList)
        {
            bool isMultipleOf2 = (number % 2 == 0);
            result.Add(isMultipleOf2);
        }

        return result;
    }
}
