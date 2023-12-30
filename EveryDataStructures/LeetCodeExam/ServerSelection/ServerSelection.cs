using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExam
{
    /// <summary>
    /// LeetCode #1780
    /// </summary>
    public class ServerSelection
    {
        public static void Test()
        {
            //Console.WriteLine(convertDecimalToBinary(3));

            var servers = new List<int> { 1,1,2,4,2,6,8 };
            var expected_load = 3;
            Console.WriteLine(getMinServers(expected_load, servers));

            servers = new List<int> { 1, 1, 2, 4, 2, 6, 8 };
            expected_load = 7;
            Console.WriteLine(getMinServers(expected_load, servers));

            servers = new List<int> { 1, 1, 2, 4, 2, 6, 8 };
            expected_load = 8;
            Console.WriteLine(getMinServers(expected_load, servers));

            servers = new List<int> { 1, 1, 2, 4, 2, 6, 8 };
            expected_load = 13;
            Console.WriteLine(getMinServers(expected_load, servers));
        }

        private static string convertDecimalToBinary(int num)
        {
            return Convert.ToString(num, 2);
        }

        private static int getMinServers(int expected_load, List<int> servers)
        {
            if (servers.Any(s => s == expected_load))
            {
                Console.WriteLine(expected_load);
                return 1;
            }

            var minServers = 0;
            var serverToCheck = servers.Where(s => s < expected_load).ToList();
            //Console.WriteLine(string.Join(",", serverToCheck));
            var loads_bin = convertDecimalToBinary(expected_load);
            var list = new List<int>();
            for (int i = loads_bin.Length-1; i >=0 ; i--)
            {
                //Console.WriteLine(loads_bin[i]);
                if (Int32.TryParse(loads_bin[i].ToString(), out int bin) && bin > 0)
                {
                    var num = (int)Math.Pow(2, i);
                    if (!serverToCheck.Contains(num))
                    {
                        minServers = -1;
                        break;
                    }
                    list.Add(num);
                    serverToCheck.Remove(serverToCheck.IndexOf(num));
                }
            }
            if (minServers == -1)
            {
                return -1;
            }

            Console.WriteLine(string.Join(",", list));
            minServers = list.Count;
            return minServers;
        }
    }
}
