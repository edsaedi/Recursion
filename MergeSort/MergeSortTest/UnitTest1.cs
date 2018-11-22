using System;
using Xunit;
using SortLibrary;

namespace MergeSortTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int size = rand.Next(0, 101);
                int[] array = Randomize(size, 100);
                //store merge sort array
                //SortLibrary.Sorts.MergeSort<int>;
                //assert merge sort array is sorted
            }
        }

        public int[] Randomize(int size, int maxNum)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, maxNum);
            }
            return array;
        }
    }
}
