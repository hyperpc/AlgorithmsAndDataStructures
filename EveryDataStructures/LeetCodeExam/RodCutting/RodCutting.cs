using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExam
{
    public class RodCutting
    {
        public static void Test()
        {
            var lengths = new List<int> { 1, 1, 1 };
            var result = rodOffcut(lengths);
            Console.WriteLine(string.Join(",", result)); // 3
            lengths = new List<int> { 1, 2, 3, 1, 2 };
            result = rodOffcut(lengths);
            Console.WriteLine(string.Join(",", result)); // 5, 3, 1
            lengths = new List<int>();
            result = rodOffcut(lengths);
            Console.WriteLine(string.Join(",", result)); // 

            var rodList = new List<int> { 1, 1, 3, 4 };
            RodsLeftAfterCutting(rodList);
        }

        /// <summary>
        /// Implement of IMG_0365.JPG/IMG_0366.JPG
        /// Return new array of rod after cutting
        /// </summary>
        /// <param name="rodList"></param>
        private static void RodsLeftAfterCutting(List<int> rodList)
        {
            var min_rod_val = 0;
            while (rodList.Count > 0)
            {
                Console.WriteLine(string.Join(",", rodList));
                min_rod_val = rodList.Min();
                rodList = rodList.Where(r => r > min_rod_val).Select(r => (r - min_rod_val)).ToList();
            }
        }

        /// <summary>
        /// Implement of RodCutting.png
        /// Return new length of rod array after cutting
        /// </summary>
        /// <param name="lengths"></param>
        /// <returns></returns>
        private static List<int> rodOffcut(List<int> lengths)
        {
            var number_of_rods = new List<int>();
            var new_lengths = new List<int>();
            foreach (var item in lengths)
            {
                new_lengths.Add(item);
            }

            while (new_lengths.Count() > 0)
            {
                number_of_rods.Add(new_lengths.Count());
                var cut_length = new_lengths.Min();
                new_lengths = new_lengths.Where(l => l > cut_length).ToList();
            }

            return number_of_rods;
        }
    }
}
