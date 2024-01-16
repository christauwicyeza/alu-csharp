public class Number
{
    public static int PrintLastDigit(int number)
    {
        number = Math.Abs(number);
        int lastDigit = number % 10;
        Console.WriteLine($"Last digit of {number} is: {lastDigit}");
        return lastDigit;
    }

    static void Main()
    {
        int testNumber = 4567;
        int result = PrintLastDigit(testNumber);
    }
}