using ArrayUtilities;
using System;

namespace UniDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 5, -100, 20, 500 };

            int[] elementsAsc = ArrayHelper.BubbleSort(array, SortDirection.Ascending);
            ArrayHelper.Print("Elements (asc)", elementsAsc);

            int[] elementsDesc = ArrayHelper.BubbleSort(array, SortDirection.Descending);
            ArrayHelper.Print("Elements (desc)", elementsDesc);
        }
    }
}
