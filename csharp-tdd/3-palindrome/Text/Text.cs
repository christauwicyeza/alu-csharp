using System;

namespace Text
{
    public class Str
    {
        /// <summary>
        /// Determines if a string is a palindrome.
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <returns>True if the string is a palindrome, otherwise False.</returns>
        public static bool IsPalindrome(string s)
        {
            // Remove all non-alphanumeric characters and convert to lowercase
            string cleanS = "";
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    cleanS += char.ToLower(c);
                }
            }

            // Check if the cleaned string is a palindrome
            int length = cleanS.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (cleanS[i] != cleanS[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}