using System;

namespace ch13_Search
{
    public class SearchTest
    {
        public static void Test()
        {
            //TestLinearSearch();
            //TestBinarySearch();
            TestJumpSearch();
        }

        #region Linear Search

        private static void TestLinearSearch()
        {
            var array = new int[] { 50, 25, 73, 21, 3 };
            var key = 21;
            var index = LinearSearch(array, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }
            key = 100;
            index = LinearSearch(array, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }

            var length = 5;
            var custs = new Customer[length];
            for (int i = 0; i < length; i++)
            {
                custs[i] = new Customer { CustomerId = i + 1, CustomerName = $"Name {i + 1}" };
            }
            var custId = 2;
            var cust = LinearSearch(custs, custId);
            if (cust != null)
            {
                Console.WriteLine($"Find the customer: (CustomerId={cust.CustomerId}, CustomerName={cust.CustomerName}).");
            }
            else
            {
                Console.WriteLine($"Not found the customer.");
            }
            custId = 100;
            cust = LinearSearch(custs, custId);
            if (cust != null)
            {
                Console.WriteLine($"Find the customer: (CustomerId={cust.CustomerId}, CustomerName={cust.CustomerName}).");
            }
            else
            {
                Console.WriteLine($"Not found the customer.");
            }
        }
        
        /// <summary>
        /// 算法复杂度O(n*n)
        /// </summary>
        /// <param name="values"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static int LinearSearch(int[] values, int key)
        {
            for (int i = 0; i < values.Length-1; i++)
            {
                if (values[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 算法复杂度O(n*n)
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
        private static Customer LinearSearch(Customer[] customers, int custId)
        {
            for (int i = 0; i < customers.Length - 1; i++)
            {
                if (customers[i].CustomerId == custId)
                {
                    return customers[i];
                }
            }
            return null;
        }
        #endregion

        #region Binary Search

        private static void TestBinarySearch()
        {
            var array = new int[] { 3, 21, 25, 50, 73 };
            var key = 21;
            var index = BinarySearch(array, 0, array.Length - 1, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }

            key = 73;
            index = BinarySearch(array, 0, array.Length - 1, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }

            key = 23;
            index = BinarySearch(array, 0, array.Length - 1, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }
        }

        /// <summary>
        /// 算法复杂度O(n*log(n))
        /// </summary>
        /// <param name="values"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static int BinarySearch(int[] values, int left, int right, int key)
        {
            if (right >= left)
            {
                int middle = left + (right - left) / 2;
                if (values[middle] == key)
                {
                    return middle;
                }else if (values[middle] > key) 
                {
                    return BinarySearch(values, left, middle-1, key);
                }
                return BinarySearch(values, middle+1, right, key);
            }
            return -1;
        }

        #endregion

        #region Jump Search
        private static void TestJumpSearch()
        {
            var array = new int[] { 8, 19, 23, 50, 75, 103, 121, 143, 201 };
            var key = 143;
            var index = JumpSearch(array, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }

            key = 100;
            index = JumpSearch(array, key);
            if (index > -1)
            {
                Console.WriteLine($"Find the element ({key}) at index of ({index}).");
            }
            else
            {
                Console.WriteLine($"Not found the element ({key}).");
            }
        }

        /// <summary>
        /// 算法复杂度O(5)
        /// </summary>
        /// <param name="values"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static int JumpSearch(int[] values, int key)
        {
            int n = values.Length;
            int step = (int)Math.Sqrt(n);
            int prev = 0;

            while (values[Math.Min(step, n) - 1] < key)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                {
                    return -1;
                }
            }

            while (values[prev] < key)
            {
                prev++;
                if (prev == Math.Min(step, n))
                {
                    return -1;
                }
            }

            if (values[prev] == key)
            {
                return prev;
            }

            return -1;
        }
        #endregion

        #region Utils
        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
        }
        #endregion
    }
}
