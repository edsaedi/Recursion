using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {

        static T[] MergeSort<T>(T[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            //calculate the mid index
            int mid = array.Length / 2;
            //create a left array
            T[] left = new T[mid - 1];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }
            //create a right array
            T[] right = new T[mid];
            for (int i = mid, j = 0; j < right.Length; i++, j++)
            {
                right[j] = array[i];
            }

            left = MergeSort(left);
            right = MergeSort(right);

            var output = Merge(left, right);
            return output;
        }

        static T[] Merge<T>(T[] left, T[] right)
        {
            //merge both arrays together

            return null;
        }



        static void Main(string[] args)
        {

        }
    }
}
