using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public class Sorts
    {
        public static T[] MergeSort<T>(T[] array) where T : IComparable<T>
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

        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
        {
            //merge both arrays together
            T[] temp = new T[left.Length + right.Length];

            int x = 0;
            int y = 0;
            int z = 0;

            for (z = 0; z < temp.Length; z++)
            {
                if (x == temp.Length - 1)
                {
                    temp[z] = left[x];
                }
                else if (y == temp.Length - 1)
                {
                    temp[z] = right[y];
                }
                else if (left[x].CompareTo(right[y]) >= 0)
                {
                    x += 1;
                }
                else if (left[x].CompareTo(right[y]) < 0)
                {
                    y += 1;
                }
            }

            return temp;
        }
    }
}
