using System;
using Xunit;
using SortLibrary;

namespace MergeSortTest
{
    public class UnitTest1
    {
        Random rand = new Random();

        [Fact]
        public void MergeSort()
        {
            for (int i = 0; i < 100; i++)
            {
                int size = rand.Next(0, 101);
                int[] array = Randomize(size);
                array = SortLibrary.Sorts.MergeSort<int>(array);
                for (int j = 1; j < size; j++)
                {
                    Assert.True(array[j - 1].CompareTo(array[j]) <= 0);
                }
                //store merge sort array
                //SortLibrary.Sorts.MergeSort<int>;
                //assert merge sort array is sorted
            }
        }

        [Fact]
        public void QuickSort()
        {
            for (int i = 0; i < 100; i++)
            {
                int size = rand.Next(0, 101);
                int[] array = Randomize(size);
                array = SortLibrary.Sorts.QuickSort<int>(array);
                for (int j = 1; j < size; j++)
                {
                    Assert.True(array[j - 1].CompareTo(array[j]) <= 0);
                }
            }
        }

        public int[] Randomize(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, size);
            }
            return array;
        }
    }
}
