using System;
using System.Collections;

namespace Text{
    public class Str{

        /// <summary>
        /// Returns index of non-repeating string 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int UniqueChar(string? s){

            if(s == null){
                return -1;
            }
            
            int len = s.Length;
            int repeated = -1;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (s[i] == s[j])
                    {
                        repeated += 1;
                    }
                }

                if (repeated == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}