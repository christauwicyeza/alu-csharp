public class Number
{
    public static int Add(int a, int b)
    {
        int result = a + b;
        return result;
    }

    static void Main()
    {
        int num1 = 10;
        int num2 = 20;
        int sum = Add(num1, num2);
        Console.WriteLine($"Sum of {num1} and {num2} is: {sum}");
    }
}