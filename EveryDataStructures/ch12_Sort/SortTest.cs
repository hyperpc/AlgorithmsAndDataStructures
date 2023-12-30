using System;
using System.Linq;

namespace ch12_Sort
{
    public class SortTest
    {
        public static void Test()
        {
            var array = new int[] { 50, 25, 73, 21, 3 };
            //SelectionSort(array);
            //InsertionSort(array);
            //BubbleSort(array);
            //QuickSort(array, 0, array.Length - 1);
            //MergeSort(array, 0, array.Length - 1);
            BucketSort(array, array.Max());
        }

        #region Selection Sort
        private static void SelectionSort(int[] values)
        {
            Console.WriteLine("Selection Sorting start.");
            if (values.Length <= 1) return;

            int j, minIndex;
            for (int i = 0; i < values.Length - 1; i++)
            {
                minIndex = i;
                for (j = i + 1; j < values.Length; j++)
                {
                    if (values[j] < values[minIndex])
                    {
                        minIndex = j;
                    }
                    //Console.WriteLine($"i={i}, j={j}, values={string.Join(", ", values)}");
                }
                Swap(ref values[minIndex], ref values[i]);
                Console.WriteLine(string.Join(", ", values));
            }
            Console.WriteLine("Selection Sorting completed.");
        }
        #endregion

        #region Insertion Sort
        private static void InsertionSort(int[] values)
        {
            Console.WriteLine("Insertion Sorting start.");
            if (values.Length <= 1) return;

            int j, value;
            for (int i = 0; i < values.Length; i++)
            {
                value = values[i];
                j = i - 1;
                while (j >= 0 && values[j] > value)
                {
                    values[j + 1] = values[j];
                    // 继续向左比较，和上一轮排序的元素继续比较
                    j--;
                    //Console.WriteLine($"i={i}, j={j}, values={string.Join(", ", values)}");
                }
                values[j + 1] = value;
                Console.WriteLine(string.Join(", ", values));
            }
            Console.WriteLine("Insertion Sorting completed.");
        }
        #endregion

        #region Bubble Sort
        private static void BubbleSort(int[] values)
        {
            Console.WriteLine("Bubble Sorting start.");
            bool swaped;
            for (int i = 0; i < values.Length - 1; i++)
            {
                swaped = false;
                for (int j = values.Length - 1; j > i; j--)
                {
                    if (values[j] < values[j - 1])
                    {
                        Swap(ref values[j], ref values[j - 1]);
                        swaped = true;
                    }
                    //Console.WriteLine($"i={i}, j={j}, values={string.Join(", ", values)}");
                }
                Console.WriteLine(string.Join(", ", values));
                if (!swaped)
                {
                    break;
                }
            }
            Console.WriteLine("Bubble Sorting completed.");
        }
        #endregion

        #region Divide-And-Conquer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private static void QuickSort(int[] values, int low, int high)
        {
            Console.WriteLine("Quick Sorting start.");
            if (low < high)
            {
                int index = Partition(values, low, high);
                QuickSort(values, low, index - 1);
                QuickSort(values, index + 1, high);
            }
            Console.WriteLine("Quick Sorting completed.");
        }

        /// <summary>
        /// 选择最后一个元素作为基准pivot
        /// </summary>
        /// <param name="values"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int Partition(int[] values, int low, int high)
        {
            int pivot = values[high];
            Console.WriteLine($"low={low}, high={high}, pivot={pivot}");
            int i = (low - 1);
            for (int j = low; j <= high - 1; j++)
            {
                if (values[j] <= pivot)
                {
                    i++;
                    Swap(ref values[i], ref values[j]);
                }
                Console.WriteLine($"i={i}; j={j}; values={string.Join(", ", values)}");
            }
            i++;
            Swap(ref values[i], ref values[high]);
            Console.WriteLine($"i={i}; values={string.Join(", ", values)}");
            return i;
        }
        #endregion

        #region Merge Sort
        private static void MergeSort(int[] values, int left, int right)
        {
            Console.WriteLine("Merge Sorting start.");
            if (left == right)
            {
                return;
            }

            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(values, left, middle);
                MergeSort(values, middle + 1, right);

                int[] temp = new int[values.Length];
                for (int i = left; i <= right; i++)
                {
                    temp[i] = values[i];
                }
                Console.WriteLine($"temp={string.Join(", ", temp)}");

                int index1 = left;
                int index2 = middle + 1;
                for (int i = left; i <= right; i++)
                {
                    if (index1 == middle + 1)
                    {
                        values[i] = temp[index2++];
                    }
                    else if (index2 > right)
                    {
                        values[i] = temp[index1++];
                    }
                    else if (temp[index1] < temp[index2])
                    {
                        values[i] = temp[index1++];
                    }
                    else
                    {
                        values[i] = temp[index2++];
                    }
                    Console.WriteLine($"i={i}, index1={index1}, index2={index2}, values={string.Join(", ", values)}");
                }
            }
            Console.WriteLine("Merge Sorting completed.");
        }
        #endregion

        #region Bucket Sort
        private static void BucketSort(int[] values, int maxVal)
        {
            Console.WriteLine("Bucket Sorting start.");
            int[] bucket = new int[maxVal + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = 0;
            }
            Console.WriteLine($"bucket={string.Join(", ", bucket)}");

            for (int i = 0; i < values.Length; i++)
            {
                bucket[values[i]]++;
            }
            Console.WriteLine($"bucket={string.Join(", ", bucket)}");

            int pos = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                for (int j = 0; j < bucket[i]; j++)
                {
                    values[pos++] = i;
                    Console.WriteLine($">>> Inner: values={string.Join(", ", values)}");
                }
                Console.WriteLine($"Outter: values={string.Join(", ", values)}");
            }
            Console.WriteLine("Bucket Sorting completed.");
        }
        #endregion

        #region Utils
        private static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }
        #endregion
    }
}
