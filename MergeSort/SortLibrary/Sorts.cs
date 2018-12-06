using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public class Sorts
    {

        public static T[] QuickSort<T>(T[] array) where T : IComparable<T>
        {
            QuickSort(array, 0, array.Length - 1);
            return array;
        }

        private static void QuickSort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            if (left < right)
            {
                int pivot = LomutoPartition(array, left, right);
                QuickSort<T>(array, left, pivot - 1);
                QuickSort<T>(array, pivot + 1, right);
            }
        }

        public static int LomutoPartition<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            int pivot = right;
            int wall = left;

            for (int i = left; i < right; i++)
            {
                //if the pointer is less than the pivot, swap pointer and wall
                if (array[i].CompareTo(array[pivot]) < 0)
                {
                    if (i != wall)
                    {
                        var temp = array[wall];
                        array[wall] = array[i];
                        array[i] = temp;
                    }
                    wall++;
                }
            }

            if (pivot != wall)
            {
                var temp = array[pivot];
                array[pivot] = array[wall];
                array[wall] = temp;
            }

            return wall;
        }

        private static int HoarePartition<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            //pivot starts at first index
            int pivot = left;
            left--;
            right++;

            while (true)
            {
                //move left pointer right until value is greater or equal to pivot
                do
                {
                    left++; //must occur at least once every loop
                } while (array[left].CompareTo(array[pivot]) < 0);

                //move right pointer left until value found to be smaller or equal than pivot
                do
                {
                    right--;
                } while (array[right].CompareTo(array[pivot]) > 0);

                if (left >= right)
                {
                    return right;
                }

                //swap left and right
                var temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
        }


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
