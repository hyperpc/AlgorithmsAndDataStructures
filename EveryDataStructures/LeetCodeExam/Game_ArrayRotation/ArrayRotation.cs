using System;
using System.Linq;

namespace LeetCodeExam.Game_ArrayRotation
{
    public class ArrayRotation
    {
        public static void Test()
        {
            var array_org = new int[] { 1, 2, 3 };
            var array_rot = new int[] { 1, 2, 3, 4, 5, 6 };

            TestRotateArray(array_org, array_rot);
        }

        /// <summary>
        /// Implement of IMG_0367.JPG/IMG_0368.JPG
        /// </summary>
        /// <param name="org"></param>
        /// <param name="rot"></param>
        private static void TestRotateArray(int[] org, int[] rot)
        {
            var length_org = org.Length;
            if (length_org == 1)
            {
                Console.WriteLine(org[1]);
                return;
            }

            var max_org_val = org.Max();
            var max_org_idx = org.ToList().IndexOf(max_org_val);
            for (int i = 0; i < rot.Length; i++)
            {
                var cur_rot_val = rot[i];
                if (cur_rot_val < 1)
                {
                    continue;
                }

                var rs = max_org_idx - (cur_rot_val % length_org);
                Console.WriteLine(rs);
            }
        }
    }
}
