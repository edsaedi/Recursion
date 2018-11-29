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
            T[] left = new T[mid];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }
            //create a right array
            T[] right = new T[array.Length - mid];
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
            if (left.Length == 0)
            {
                return right;
            }

            if (right.Length == 0)
            {
                return left;
            }

            //merge both arrays together
            T[] temp = new T[left.Length + right.Length];

            int L = 0;
            int R = 0;

            //Option A
            //for (int i = 0; i < temp.Length; i++)
            //{
            //    if (L < left.Length && R < right.Length)
            //    {
            //        if (left[L].CompareTo(right[R]) < 0)
            //        {
            //            temp[i] = left[L];
            //            L += 1;
            //        }
            //        else
            //        {
            //            temp[i] = right[R];
            //            R += 1;
            //        }
            //    }
            //    else if(L < left.Length)
            //    {
            //        temp[i] = left[L];
            //        L += 1;
            //    }
            //    else if(R < right.Length)
            //    {
            //        temp[i] = right[R];
            //        R += 1;
            //    }
            //}

            //Option B
            //for (int i = 0; i < temp.Length; i++)
            //{

            //    //If (L is available AND R is not Available) || (both are available AND L is the smaller one)
            //    if (L < left.Length && (R >= right.Length || left[L].CompareTo(right[R]) < 0))
            //    {
            //        temp[i] = left[L];
            //        L += 1;
            //    }
            //    else if (R < right.Length && (L >= left.Length || left[L].CompareTo(right[R]) >= 0))
            //    {
            //        temp[i] = right[R];
            //        R += 1;
            //    }
            //}

            //Option C
            int i = 0;
            //while both array are available
            //copy from smaller
            while (L < left.Length && R < right.Length)
            {
                if (left[L].CompareTo(right[R]) < 0)
                {
                    temp[i] = left[L];
                    L++;
                }
                else
                {
                    temp[i] = right[R];
                    R++;
                }
                i++;
            }

            //while left is available
            //copy from left
            while (L < left.Length)
            {
                temp[i] = left[L];
                L++;
                i++;
            }

            //while right is available
            //copy from right
            while (R < right.Length)
            {
                temp[i] = right[R];
                R++;
                i++;
            }

            return temp;
        }
    }
}
