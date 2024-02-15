using System;
using System.Collections.Generic;
using System.Collections;

namespace Text
{
    public class Str
    {
        /// <summary>
        /// Returns number of words in a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CamelCase(string? s)
        {

            List<char> Caps = new List<char>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                Caps.Add(i);
            }
            
            int wordCount = 0;
            if (s == string.Empty)
            {
                return 0;
            }
            
            if (s != null)
            {
                wordCount = 1;
                foreach (char l in s)
                {
                    if (Caps.Contains(l))
                    {
                        wordCount++;
                    }
                }
            }

            return wordCount;

        }
    }
}