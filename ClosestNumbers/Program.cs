using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            //int[] result = closestNumbers(arr);
            //Console.WriteLine(String.Join(" ", result));
            //Console.WriteLine(String.Join(" ", InsertionSort(arr)));

            #region
            BinaryIndexTree bitree = new BinaryIndexTree();
            long[] freq = { 2, 1, 3, 1, 2 };//// { 2, 1, 1, 3, 2, 3, 4, 5, 6, 7, 8, 9 };
            long n = freq.Length;
            Console.WriteLine(bitree.getInvCount(freq, n));
            //Console.WriteLine(bitree.getSum(BITree, 3));
            Array.ConvertAll(arr_temp, long.Parse);

            //// Let use test the update operation
            //freq[3] += 6;
            //bitree.updateBIT(BITree, n, 3, 6); //Update BIT for above change in arr[]

            //Console.WriteLine(bitree.getSum(BITree, 3));
            #endregion

            Console.Read();
        }
        static int[] closestNumbers(int[] arr)
        {
            Array.Sort(arr);
            List<int> numbers = new List<int>();
            int min = arr[1] - arr[0];
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] < min)
                {
                    min = arr[i] - arr[i - 1];
                }
            }

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] == min)
                {
                    numbers.Add(arr[i - 1]);
                    numbers.Add(arr[i]);
                }
            }

            return numbers.ToArray();
        }

        private static int[] InsertionSort(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        count++;
                        var swap = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = swap;
                    }
                    else
                        break;
                }
            }

            return arr;
        }

    }
}
