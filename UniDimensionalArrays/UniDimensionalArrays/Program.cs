using ArrayUtilities;
using System;

namespace UniDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 1, 3, 1, 5, 2 };
            int[][] arrayWithFreq = ArrayHelper.Frequencies(array);
            ArrayHelper.PrintJaggedArray("Elem + Freq", arrayWithFreq);

            return;

            int[] sir1 = { 1, 2, 3 };
            int[] sir2 = { 9, 8 };

            int[][] result = ArrayHelper.CartesianProduct(sir1, sir2);
            ArrayHelper.PrintJaggedArray("Cartesian Product", result);
            return;

            int[,] matrix1 = ArrayHelper.ReadMatrix("matrix1");
            ArrayHelper.PrintMatrix("matrix1", matrix1);

            int[,] matrix2 = ArrayHelper.ReadMatrix("matrix2");
            ArrayHelper.PrintMatrix("matrix2", matrix2);

            int[,] product = ArrayHelper.ProductMatrices(matrix1, matrix2);
            ArrayHelper.PrintMatrix("Prod matrix", product);

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
