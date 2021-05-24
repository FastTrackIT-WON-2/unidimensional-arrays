using ArrayUtilities;
using System;

namespace UniDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 5, -100, 20, 500 };

            int max = ArrayHelper.Max(array);

            Console.WriteLine($"max={max}");
        }
    }
}
