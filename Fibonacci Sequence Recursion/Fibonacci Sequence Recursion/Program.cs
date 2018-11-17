using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Sequence_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in a length");
            int[] fibb = FibonacciSequence(int.Parse(Console.ReadLine()));
            for (int i = 0; i < fibb.Length; i++)
            {
                Console.Write($"{fibb[i]},");
            }
            Console.ReadKey();
        }

        // 0 1 1 2 3 5 8 13 21 34 

        // Input: 5
        // Output: 0 1 1 2 3

        public static int[] FibonacciSequence(int length)
        {
            if (length == 0)
            {
                return new int[length];
            }
            else if (length == 1)
            {
                return new int[] { 0 };
            }
            else if (length == 2)
            {
                return new int[] { 0, 1 };
            }

            int[] fibb = new int[length];
            fibb[0] = 0;
            fibb[1] = 1;
            Fibb(fibb, 2);
            return fibb;
        }

        private static void Fibb(int[] fibb, int curr)
        {
            //escape case?
            if (curr == fibb.Length)
            {
                return;
            }
            //recursive segment?
            fibb[curr] = fibb[curr - 1] + fibb[curr - 2];
            Fibb(fibb, curr + 1);
        }
    }
}
