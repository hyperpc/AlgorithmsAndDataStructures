using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExam
{
    public class MinimunUniqueArraySum
    {
        public static void Test()
        {
            var arr = new List<int> { 3, 2, 1, 2, 7 };
            Console.WriteLine(getSumOfUniqueArray(arr)); // 17
            arr = new List<int> { 1, 2, 2 };
            Console.WriteLine(getSumOfUniqueArray(arr)); // 6
            arr = new List<int> { 2, 2, 4, 5 };
            Console.WriteLine(getSumOfUniqueArray(arr)); // 14
        }

        /// <summary>
        /// 1 <= arr.Length <= 2000
        /// 1 <= arr[i] <= 3000
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int getSumOfUniqueArray(List<int> arr)
        {
            var unique = new List<int>();
            var min = 0;
            arr = arr.OrderBy(x => x).ToList();
            for (int i = 0; i < arr.Count; i++)
            {
                var item = arr[i];
                if (item <= min)
                {
                    item = min + 1;
                }
                min = item;
                unique.Add(item);
            }
            return unique.Sum();
        }
    }
}
