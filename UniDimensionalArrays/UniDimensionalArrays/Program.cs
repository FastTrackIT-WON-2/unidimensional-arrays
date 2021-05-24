using ArrayUtilities;
using System;

namespace UniDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 5, -100, 20, 500 };

            int[] elements = ArrayHelper.BubbleSortAsc(array);

            ArrayHelper.Print("elements", elements);
        }
    }
}
