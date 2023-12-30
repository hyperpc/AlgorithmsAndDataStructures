using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExam
{
    public class MaxPairsOfTwoArrays
    {
        public static void Test()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 1 };
            Console.WriteLine($"Max Pairs: {Pairs_v1(a, b)}");
            Console.WriteLine($"Max Pairs: {Pairs_v2(a, b)}");
            Console.WriteLine($"Max Pairs: {Pairs_Sorted_v1(a, b)}");
            Console.WriteLine($"Max Pairs: {Pairs_Sorted_v2(a, b)}");
        }

        private static int Pairs_v1(int[] a, int[] b)
        {
            var maxPairs = 0;
            var pairs = new List<string>();
            var a_idx = 0;
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = a_idx; j < a.Length; j++)
                {
                    if (a[j] > b[i])
                    {
                        maxPairs++;
                        pairs.Add($"{{a[{j}],b[{i}]}}={{{a[j]},{b[i]}}}");
                        a_idx = ++j;
                        break;
                    }
                }
            }
            Console.WriteLine($"Pairs: {string.Join(",", pairs)}");
            return maxPairs;
        }
        
        private static int Pairs_v2(int[] a, int[] b)
        {
            var maxPairs = 0;
            var pairs = new List<string>();
            var a_idx = a.Length-1;
            for (int i = b.Length-1; i >=0 ; i--)
            {
                for (int j = a_idx; j >=0; j--)
                {
                    if (a[j] > b[i])
                    {
                        maxPairs++;
                        pairs.Add($"{{a[{j}],b[{i}]}}={{{a[j]},{b[i]}}}");
                        a_idx = --j;
                        break;
                    }
                }
            }
            Console.WriteLine($"Pairs: {string.Join(",", pairs)}");
            return maxPairs;
        }

        private static int Pairs_Sorted_v1(int[] a, int[] b)
        {
            var maxPairs = 0;
            var min_a = a.Min();
            var max_a = a.Max();
            var min_b = b.Min();
            var max_b = b.Max();

            if (min_b >= max_a)
                return 0;

            if (min_a > max_b)
                return a.Length;

            var a_sorted = a.Where(e => e > min_b).OrderBy(e => e).ToArray();
            var b_sorted = b.Where(e => e < max_a).OrderBy(e => e).ToArray();

            var pairs = new List<string>();
            var a_idx = 0;
            for (int i = 0; i < b_sorted.Length; i++)
            {
                for (int j = a_idx; j < a_sorted.Length; j++)
                {
                    if (a_sorted[j] > b_sorted[i])
                    {
                        maxPairs++;
                        pairs.Add($"{{a[{j}],b[{i}]}}={{{a_sorted[j]},{b_sorted[i]}}}");
                        a_idx = ++j;
                        break;
                    }
                }
            }
            Console.WriteLine($"Pairs: {string.Join(",", pairs)}");

            return maxPairs;
        }

        private static int Pairs_Sorted_v2(int[] a, int[] b)
        {
            var maxPairs = 0;
            var min_a = a.Min();
            var max_a = a.Max();
            var min_b = b.Min();
            var max_b = b.Max();

            if (min_b >= max_a)
                return 0;

            if (min_a > max_b)
                return a.Length;

            var a_sorted = a.Where(e => e > min_b).OrderBy(e => e).ToArray();
            var b_sorted = b.Where(e => e < max_a).OrderBy(e => e).ToArray();

            var pairs = new List<string>();
            var a_idx = a_sorted.Length - 1;
            for (int i = b_sorted.Length - 1; i >= 0; i--)
            {
                for (int j = a_idx; j >= 0; j--)
                {
                    if (a_sorted[j] > b_sorted[i])
                    {
                        maxPairs++;
                        pairs.Add($"{{a[{j}],b[{i}]}}={{{a_sorted[j]},{b_sorted[i]}}}");
                        a_idx = --j;
                        break;
                    }
                }
            }
            Console.WriteLine($"Pairs: {string.Join(",", pairs)}");

            return maxPairs;
        }

    }
}
