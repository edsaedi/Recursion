using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in a number.");
            Console.WriteLine(FactorialRecursive(int.Parse(Console.ReadLine())));
            Console.ReadKey();
        }

        static int Factorial(int number)
        {
            int answer = 1;
            for (int i = number; i > 0; i--)
            {
                answer *= i;
            }
            return answer;
        }

        static int FactorialRecursive(int number)
        {
            if(number == 1)
            {
                return 1;
            }
            return number * FactorialRecursive(number - 1);
        }
    }
}
