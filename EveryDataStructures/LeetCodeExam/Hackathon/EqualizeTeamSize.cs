using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExam
{
    public class EqualizeTeamSize
    {
        public static void Test()
        {
            var ts = new List<int> { 1, 2, 2, 3, 4 };
            var k = 0;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 1;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            k = 2;
            Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 4;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 5;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 6;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");


            ts = new List<int> { 1, 7, 3, 8 };
            //k = 0;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            k = 1;
            Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 2;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 3;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 4;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 5;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");

            ts = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            //k = 0;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 1;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 2;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 6;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 7;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 8;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            k = 10;
            Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");



            //ts = new List<int> { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //k = 0;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 1;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 2;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 10;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 11;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 12;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            //k = 99;
            //Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");


            ts = new List<int> { 1, 2, 3, 4 };
            k = 1;
            Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
            k = 10;
            Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");

            ts = new List<int> { 1, 3, 3, 3, 4, 4, 5, 5, 5, 5 };
            k = 4;
            Console.WriteLine($"ts={{{string.Join(",", ts)}}}, k={k}, return={equalizeTeamSize(ts, k)}");
        }

        private static int equalizeTeamSize(List<int> teamSize, int k)
        {
            var maxTS = teamSize.Max();
            if (k == 0)
            {
                return teamSize.Where(s => s == maxTS).Count();
            }
            else if (k >= teamSize.Count-1)
            {
                return teamSize.Count;
            }
            else
            {
                var teamSizeWithCnt = teamSize.GroupBy(a => a).Select(g => new { Val = g.Key, Count = g.Count() }).OrderByDescending(s => s.Count).OrderByDescending(s => s.Val);
                var rs = 0;
                var greater = 0;
                for (int i = 0; i < teamSizeWithCnt.Count(); i++)
                {
                    var team = teamSizeWithCnt.ElementAt(i);
                    var teamCnt = k > greater ? team.Count + greater : team.Count + k;
                    rs = rs < teamCnt ? teamCnt : rs;
                    greater += team.Count;
                }

                return rs;
            }
        }

    }
}
