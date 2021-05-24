using ArrayUtilities;
using System;

namespace UniDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] array = { 2, 5, -100, 20, 500 };

            int[] array = new int[0];

            int min = ArrayHelper.Min(array);

            if (min == int.MinValue)
            {
                Console.WriteLine($"Nu am putut calcula minimul!");
            }
            else
            {
                Console.WriteLine($"min={min}");
            }
        }
    }
}
