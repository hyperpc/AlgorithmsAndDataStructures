using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExam
{
    public class PlusMult
    {
        public static void Test()
        {
            var a = new List<int> { 0 };
            plusMult(a);
            a = new List<int> { 1 };
            plusMult(a);
            a = new List<int> { -1 };
            plusMult(a);
            a = new List<int> { 0, 1 };
            plusMult(a);
            a = new List<int> { 0, -1 };
            plusMult(a);
            a = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            plusMult(a);

            a = new List<int> { 1 }; // NUTRAL(EVEN)
            plusMult(a);

            a = new List<int> { 1, 0, 3, 0, 5 }; //
            plusMult(a);
        }

        private static string plusMult(List<int> A)
        {
            var rs = string.Empty;
            var length = A.Count();
            var loopCnt = length / 2;
            var arrEven = new int[loopCnt];
            var arrOdd = new int[loopCnt];

            for (int i = 0; i < loopCnt; i++)
            {
                arrEven[i] = A[i * 2];
                arrOdd[i] = A[i * 2 + 1];
                Console.WriteLine($"    Even__{arrEven[i]}");
                Console.WriteLine($"    Odd__{arrOdd[i]}");
            }
            var rsEven = 0;
            var rsOdd = 0;

            for (int i = 0; i < loopCnt; i++)
            {
                if (i % 2 == 1)
                {
                    rsEven = rsEven * arrEven[i];
                    rsOdd = rsOdd * arrOdd[i];
                }
                else if (i % 2 == 0)
                {
                    rsEven = rsEven + arrEven[i];
                    rsOdd = rsOdd + arrOdd[i];
                }
                Console.WriteLine($"    Even__rs__{rsEven}");
                Console.WriteLine($"    Odd__rs__{rsOdd}");
            }
            // case 4: rsEven>0, rsEven%2=0; rsOdd<0, rsOdd%2<0; NEUTRAL()
            Console.WriteLine("rsEven=" + rsEven.ToString());
            Console.WriteLine("rsEven%2=" + (rsEven % 2));
            Console.WriteLine("rsOdd=" + rsOdd.ToString());
            Console.WriteLine("rsOdd%2=" + (rsOdd % 2));
            if (rsEven % 2 > rsOdd % 2)
            {
                if (rsOdd <= 0 && rsEven % 2 > 0)
                {
                    rs = "NEUTRAL";
                }
                else if (rsOdd <= 0 && rsEven % 2 == 0)
                {
                    rs = "ODD";
                }
                else
                {
                    rs = "EVEN";
                }
            }
            else if (rsEven % 2 < rsOdd % 2)
            {
                rs = "ODD";
            }
            else if (rsEven % 2 == rsOdd % 2)
            {
                if (rsEven % 2 == 0 && rsEven * rsOdd < 0)
                {
                    rs = "EVEN";
                }
                else if (rsEven % 2 == 1 && rsEven * rsOdd < 0)
                {
                    rs = "ODD";
                }
                else
                {
                    rs = "NEUTRAL";
                }
            }
            Console.WriteLine($"        >>> Final: {rs}");

            return rs;
        }
    }
}
