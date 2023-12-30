using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExam
{
    public class SubsequenceLength
    {
        public static void Test()
        {
            var arr = new List<int> { 0 };
            Console.WriteLine(getMaxLength(arr)); // 0
            arr = new List<int> { 1 };
            Console.WriteLine(getMaxLength(arr)); // 1
            arr = new List<int> { 1, 2, 4, 8 };
            Console.WriteLine(getMaxLength(arr)); // 1
            arr = new List<int> { 1, 3, 5, 7, 3 };
            Console.WriteLine(getMaxLength(arr)); // 5
            arr = new List<int> { 3, 1, 6, 2, 2 };
            Console.WriteLine(getMaxLength(arr)); // 4
            arr = new List<int> { 7, 4, 11, 8, 3 };
            Console.WriteLine(getMaxLength(arr)); // 3
        }

        private static int getMaxLength(List<int> arr)
        {
            var maxLength = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr[i] == 0)
                    continue;

                var sum = arr[i];
                var currentLength = 1;
                for (int j = 0; j < arr.Count(); j++)
                {
                    if (arr[j] == 0 || i == j)
                        continue;

                    if ((sum & arr[j]) == 0)
                        continue;

                    sum &= arr[j];
                    currentLength++;
                }

                if (maxLength < currentLength)
                {
                    maxLength = currentLength;
                }
            }

            return maxLength;
        }
    }
}
