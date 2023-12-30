using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExam
{
    public class SlotWheels
    {
        public static void Test()
        {
            var arr = new List<string> { "712", "246","365","312" };
            Console.WriteLine(slotWheels(arr)); // 161
            arr = new List<string> { "812", "266", "256", "244" };
            Console.WriteLine(slotWheels(arr)); // 162
        }

        private static int slotWheels(List<string> spin)
        {
            var large = new List<int>();
            var m= new List<int>();
            var l = 0;
            var max = new List<int>();

            foreach (var item in spin)
            {
                foreach (var ch in item)
                {
                    max.Add((int)ch);
                }
                l = max.Max();
                m.Add(l);
                max.Clear();
            }
            large.Add(m.Max());

            l = 0;
            m.Clear();
            max.Clear();
            foreach(var item in spin)
            {
                foreach (var ch in item)
                {
                    max.Add((int)ch);
                }
                max = max.OrderBy(o=>o).ToList();
                max.RemoveAt(0);
                l=max.Max();
                m.Add(l);
                max.Clear();
            }
            large.Add(m.Max());

            l = 0;
            m.Clear();
            max.Clear();
            foreach (var item in spin)
            {
                foreach (var ch in item)
                {
                    max.Add((int)ch);
                }
                l = max.Min();
                m.Add(l);
                max.Clear();
            }
            large.Add(m.Max());

            return large.Sum();
        }
    }
}
