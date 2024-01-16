public class Character
{
    public static bool IsLower(char c)
    {
        // Check if the character is between 'a' and 'z' in ASCII
        return c >= 'a' && c <= 'z';
    }

    // Example usage:
    static void Main()
    {
        char testChar = 'g';
        bool result = IsLower(testChar);
        Console.WriteLine($"Is '{testChar}' lowercase? {result}");
    }
}
