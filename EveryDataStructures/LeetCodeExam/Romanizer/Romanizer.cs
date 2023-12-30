using System;
using System.Text;

namespace LeetCodeExam.Romanizer
{
    public class Romanizer
    {
        public static void Test()
        {
            var nums = new int[] { 1, 49, 23 };
            var romanNumerals = romanizer(nums);
            Console.WriteLine(string.Join(", ", romanNumerals));
        }

        private static string[] romanizer(int[] nums)
        {
            var romanNums = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                romanNums[i] = IntToRoman(nums[i]);
            }

            return romanNums;
        }

        private static string IntToRoman(int num)
        {
            var romanSymbols = new string[13]
            {
                "M", "CM", "D", "CD", "C", "XC",
                "L", "XL", "X", "IX", "V", "IV", "I"
            };
            var values = new int[13]
            {
                1000, 900, 500, 400, 100, 90,
                50, 40, 10, 9, 5, 4, 1
            };

            var romanNum = new StringBuilder();
            for (int i = 0; i < romanSymbols.Length; i++)
            {
                while (num >= values[i])
                {
                    romanNum.Append(romanSymbols[i]);
                    num -= values[i];
                }
            }

            return romanNum.ToString();
        }
    }
}
