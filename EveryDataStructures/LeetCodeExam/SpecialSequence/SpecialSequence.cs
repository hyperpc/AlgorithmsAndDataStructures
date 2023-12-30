using System;
using System.Text;

namespace LeetCodeExam
{
    public class SpecialSequence
    {
        public static void Test()
        {
            var queries = generateDigitsArray(7);
            var result = sumOfTheDigits(queries);
            for (int i = 0; i < result.Length; i++)
            {
                //Console.WriteLine(queries[i]);
                //Console.WriteLine(result[i]);
                var num = queries[i].ToString();

                var exp = new StringBuilder();
                exp.Append("(");
                for (int j = 0; j < num.Length; j++)
                {
                    if (j == num.Length - 1)
                    {
                        exp.Append($"{num[j]}) = ");
                    }
                    else
                    {
                        exp.Append($"{num[j]} +");
                    }
                }
                exp.Append($"{result[i]}");
                Console.WriteLine(num);
                Console.WriteLine(exp.ToString());
            }
        }
        
        private static int[] generateDigitsArray(int length)
        {
            var rs = new int[length];
            if (length == 1)
            {
                rs[0] = 1;
                return rs;
            }
            else if (length == 2)
            {
                rs[0] = 1;
                rs[1] = 11;
                return rs;
            }

            rs[0] = 1;
            rs[1] = 11;
            var queries = new string[length];
            queries[0] = "1";
            queries[1] = "11";
            for (int i = 2; i < length; i++)
            {
                var preNum = queries[i - 1];
                int n = 1;
                var nextNum = string.Empty;
                var j = 0;
                for (n = 0; n < preNum.Length-1; n++)
                {
                    if (preNum[n] == preNum[n + 1])
                    {
                        j++;
                    }
                    else
                    {
                        j++;
                        nextNum += j.ToString() + preNum[n].ToString();
                        j = 0;
                    }
                }
                j++;
                nextNum += j.ToString() + preNum[n];
                queries[i] = nextNum;
                rs[i] = Int32.Parse(nextNum);
            }
            return rs;
        }

        private static int[] sumOfTheDigits(int[] q)
        {
            var rs = new int[q.Length];
            for (int i = 0; i < q.Length; i++)
            {
                var num = q[i].ToString();
                var sum = 0;
                for (int j = 0; j < num.Length; j++)
                {
                    sum += Int32.Parse(num[j].ToString());
                }
                rs[i] = sum;
            }

            return rs;
        }
    }
}
