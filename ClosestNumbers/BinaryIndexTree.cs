using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestNumbers
{
    /// <summary>
    /// The sum operation where parent of index x is "x - (x & -x)".
    /// The update operation where parent of index x is "x + (x & -x)".
    /// </summary>
    class BinaryIndexTree
    {
        // Returns sum of arr[0..index]. This function assumes
        // that the array is preprocessed and partial sums of
        // array elements are stored in BITree[].
        public long getSum(long[] BITree, long index)
        {
            long sum = 0; // Iniialize result

            // index in BITree[] is 1 more than the index in arr[]
            index = index + 1;

            // Traverse ancestors of BITree[index]
            while (index > 0)
            {
                // Add current element of BITree to sum
                sum += BITree[index];

                // Move index to parent node in getSum View
                index -= index & (-index);
            }
            return sum;
        }

        // Updates a node in Binary Index Tree (BITree) at given index
        // in BITree.  The given value 'val' is added to BITree[i] and 
        // all of its ancestors in tree.
        public void updateBIT(long[] BITree, long n, long index, long val)
        {
            // index in BITree[] is 1 more than the index in arr[]
            index = index + 1;

            // Traverse all ancestors and add 'val'
            while (index <= n)
            {
                // Add 'val' to current node of BI Tree
                BITree[index] += val;

                // Update index to that of parent in update View
                index += index & (-index);
            }
        }

        // Constructs and returns a Binary Indexed Tree for given
        // array of size n.
        public long[] constructBITree(long[] arr, long n)
        {
            // Create and initialize BITree[] as 0
            long[] BITree = new long[n + 1];
            for (long i = 1; i <= n; i++)
                BITree[i] = 0;

            // Store the actual values in BITree[] using update()
            for (long i = 0; i < n; i++)
                updateBIT(BITree, n, i, arr[i]);

            // Uncomment below lines to see contents of BITree[]
            //for (int i=1; i<=n; i++)
            //      cout << BITree[i] << " ";

            return BITree;
        }

        // Returns inversion count arr[0..n-1]
        public long getInvCount(long[] arr, long n)
        {
            long invcount = 0; // Initialize result

            // Find maximum element in arr[]
            long maxElement = 0;
            for (long i = 0; i < n; i++)
                if (maxElement < arr[i])
                    maxElement = arr[i];

            // Create a BIT with size equal to maxElement+1 (Extra
            // one is used so that elements can be directly be
            // used as index)
            long[] BIT = new long[maxElement + 1];
            for (long i = 1; i <= maxElement; i++)
                BIT[i] = 0;

            // Traverse all elements from right.
            for (long i = n - 1; i >= 0; i--)
            {
                // Get count of elements smaller than arr[i]
                invcount += getSum(BIT, arr[i] - 1);

                // Add current element to BIT
                updateBIT(BIT, maxElement, arr[i], 1);
            }

            return invcount;
        }

        /// <summary>
        /// http://pavelsimo.blogspot.sg/2012/09/counting-inversions-in-array-using-BIT.html
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public long getInvCountModified(long[] arr, long n)
        {
            long invcount = 0; // Initialize result

            // Convert arr[] to an array with values from 1 to n and
            // relative order of smaller and greater elements remains
            // same.  For example, {7, -90, 100, 1} is converted to
            //  {3, 1, 4 ,2 }
            convert(arr, n);

            // Create a BIT with size equal to maxElement+1 (Extra
            // one is used so that elements can be directly be
            // used as index)
            long[] BIT = new long[n + 1];
            for (long i = 1; i <= n; i++)
                BIT[i] = 0;

            // Traverse all elements from right.
            for (long i = n - 1; i >= 0; i--)
            {
                // Get count of elements smaller than arr[i]
                invcount += getSum(BIT, arr[i] - 1);

                // Add current element to BIT
                updateBIT(BIT, n, arr[i], 1);
            }

            return invcount;
        }


        // Converts an array to an array with values from 1 to n
        // and relative order of smaller and greater elements remains
        // same.  For example, {7, -90, 100, 1} is converted to
        // {3, 1, 4 ,2 }
        private void convert(long[] arr, long n)
        {
            // Create a copy of arrp[] in temp and sort the temp array
            // in increasing order
            long[] temp = new long[n];
            for (long i = 0; i < n; i++)
                temp[i] = arr[i];

            //sort(temp, temp + n);
            Array.Sort(temp);

            // Traverse all array elements
            for (long i = 0; i < n; i++)
            {
                // lower_bound() Returns pointer to the first element
                // greater than or equal to arr[i]
                var search = Array.BinarySearch(temp, arr[i]);
                arr[i] = search + 1;
            }
            Console.WriteLine();
        }

    }
}
