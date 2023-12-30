using System;
using System.Collections.Generic;

namespace LeetCodeExam
{
    public class AncestralName
    {
        public static void Test()
        {
            var list = new List<string>
            {
                "A I", "B I", "C II", "A V", "B VII", "D I", "E X"
            };

            Console.WriteLine(string.Join(", ", list));
        }

        private static List<string> sortRoman(List<string> names)
        {
            names.Sort((s1, s2) =>
            {
                var s1Array = s1.Split(new char[] { ' ' });
                var s2Array = s2.Split(new char[] { ' ' });
                var name1 = s1Array[0];
                var name2 = s2Array[0];
                var comp = name1.CompareTo(name2);
                if (comp != 0) { return comp; }

                var val1 = RomanToInt(s1Array[1]);
                var val2 = RomanToInt(s2Array[1]);
                return val1.CompareTo(val2);
            });

            return names;
        }

        private static int RomanToInt(string s)
        {
            var dict = new Dictionary<char, int>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };

            var num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var currentVal = dict[s[i]];
                if (i == s.Length - 1)
                {
                    num += currentVal;
                }
                else
                {
                    var nextVal = dict[s[i + 1]];
                    if (i < s.Length - 1 && currentVal < nextVal)
                    {
                        num -= currentVal;
                    }
                    else
                    {
                        num += currentVal;
                    }
                }
            }

            return num;
        }
    }
}
