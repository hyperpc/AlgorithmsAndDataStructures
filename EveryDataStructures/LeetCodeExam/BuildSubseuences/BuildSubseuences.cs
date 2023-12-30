using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExam
{
    public class BuildSubseuences
    {
        public static void Test()
        {
            var s = "abc";
            var subsequences = test_buildSubsequence(s);
            Console.WriteLine(string.Join(",", subsequences));

            s = "abcfed";
            subsequences= test_buildSubsequence(s);
            Console.WriteLine(string.Join(",", subsequences));
        }

        private static List<string> test_buildSubsequence(string s)
        {
            var list = new List<string>();
            if (string.IsNullOrWhiteSpace(s))
                return list;

            var array = s.ToList().OrderBy(a=>a).ToArray();
            var sumSub = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                sumSub = array[i].ToString();
                list.Add(sumSub);
                for (int j = i+1; j < s.Length; j++)
                {
                    sumSub += array[j].ToString();
                    list.Add(sumSub);
                }
                sumSub=string.Empty;
            }

            return list;
        }
    }
}
