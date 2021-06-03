using ArrayUtilities;
using System;

namespace UniDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = ArrayHelper.ReadMatrix("matrix1");
            ArrayHelper.PrintMatrix("matrix1", matrix1);

            int[,] matrix2 = ArrayHelper.ReadMatrix("matrix2");
            ArrayHelper.PrintMatrix("matrix2", matrix2);

            int[,] sum = ArrayHelper.SumMatrices(matrix1, matrix2);
            ArrayHelper.PrintMatrix("Sum matrix", sum);

            // ArrayHelper.PrintMainDiagonal(matrix1);
            // int[] mainDiagonal = ArrayHelper.GetMainDiagonal(matrix1);
            // ArrayHelper.Print("Elements from main diagonal", mainDiagonal);

            /*
            int[] array = { 2, 5, -100, 20, 500 };

            int[] elementsDesc = ArrayHelper.SelectionSort(array, SortDirection.Descending);
            int[] elementsAsc = ArrayHelper.SelectionSort(array, SortDirection.Ascending);

            ArrayHelper.Print("Elements (asc)", elementsAsc);
            ArrayHelper.Print("Elements (desc)", elementsDesc);

            long[] fibo = ArrayHelper.Fibonacci(50);
            ArrayHelper.Print("Fibonacci", fibo);

            int[] primes = ArrayHelper.PrimesEratostene(20);
            ArrayHelper.Print("Primes", primes);
            */
        }
    }
}
