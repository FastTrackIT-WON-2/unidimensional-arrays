using System;
using System.Text;

namespace ArrayUtilities
{
    /// <summary>
    /// Utilites for arrays.
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        /// Calculates the minimum element.
        /// If min cannot be determined (e.g.: array is null, or empty) it will
        /// return <see cref="int.MinValue"/>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The min value.</returns>
        public static int Min(int[] array)
        {
            if (array is null)
            {
                return int.MinValue;
            }

            if (array.Length == 0)
            {
                return int.MinValue;
            }

            // consideram min = primul element din array
            // incepem sa parcurgem vectorul de la elementul 2 pana la capat
            // la fiecare pas:
            //          - este elementul curent mai mic decat min?
            //              - Da: noul min = elementul curent
            //              - Nu: mergi mai departe la urmatorul element

            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                int currentElement = array[i];
                if (currentElement < min)
                {
                    min = currentElement;
                }
            }

            return min;
        }

        /// <summary>
        /// Calculates the maximum element.
        /// If max cannot be determined (e.g.: array is null, or empty) it will
        /// return <see cref="int.MaxValue"/>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The max value.</returns>
        public static int Max(int[] array)
        {
            if (array is null)
            {
                return int.MaxValue;
            }

            if (array.Length == 0)
            {
                return int.MaxValue;
            }

            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                int currentElement = array[i];
                if (currentElement > max)
                {
                    max = currentElement;
                }
            }

            return max;
        }

        /// <summary>
        /// Clones the original array into a new one, copying all elements.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <returns>A clone containing the same elements.</returns>
        public static int[] Clone(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return new int[0];
            }

            int[] clone = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                clone[i] = array[i];
            }

            return clone;
        }

        /// <summary>
        /// Sorts the array using the bubble sort algorithm.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="sortDirection">The sort direction</param>
        /// <returns>The array having the elements sorted.</returns>
        public static int[] BubbleSort(int[] array, SortDirection sortDirection)
        {
            int[] result = Clone(array);

            // Index: 0 | 1 | 2 | 3 |
            // ----------------------
            // Value: 4 | 3 | 2 | 1 |
            // ----------------------

            // pornim de la indexul = 0
            // 1) verificam array[0] < array[1] ? ( 4 < 3 ?) => FALS
            //          array[0] = 3
            //          array[1] = 4

            // Index: 0 | 1 | 2 | 3 |
            // ----------------------
            // Value: 3 | 4 | 2 | 1 |
            // ----------------------

            // pornim de la indexul = 0
            // 1) verificam array[0] < array[1] ? (3 < 4 ?) => ADEVARAT
            // 2) indexul = 1
            // 3) verificam array[1] < array[2] ? (4 < 2 ?) => FALS
            //          array[1] = 2
            //          array[2] = 4

            // Index: 0 | 1 | 2 | 3 |
            // ----------------------
            // Value: 3 | 2 | 4 | 1 |
            // ----------------------

            // pornim de la indexul = 0

            // pornim verificarea array-ului de la indexul 0
            // la fiecare pas:
            //      - verificam daca elementul de la indexul curent este mai mic
            //        decat elementul de la indexul urmator
            //        ( array[i] < array[i + 1] )
            //      - Daca da:
            //          - OK, mergem mai departe
            //      - Daca NU:
            //          - Interschimbam elementele (array[i] trebuie sa devina array[i + 1),
            //                                      array[i + 1] trebuie sa devina array[i])
            //          - du-te inapoi de la inceput si verifica din nou array-ul
            // Nota: algoritmul se termina cand nu mai gasim perechi de elemente care trebuie interschimbate

            bool areElementsOrdered;
            do
            {
                areElementsOrdered = true;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    bool isSwapNeeded;
                    switch (sortDirection)
                    {
                        case SortDirection.Descending:
                            isSwapNeeded = result[i] < result[i + 1];
                            break;

                        case SortDirection.Ascending:
                        default:
                            isSwapNeeded = result[i] > result[i + 1];
                            break;
                    }

                    if (isSwapNeeded)
                    {
                        // A     B     Temp
                        // A -> Temp (A gol)
                        // B -> A (B devine gol)
                        // Temp -> B (Temp devine gol)
                        // B     A    Temp

                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        areElementsOrdered = false;
                        break;
                    }
                }
            }
            while (!areElementsOrdered);

            return result;
        }

        /// <summary>
        /// Sorts the array using the selection sort algorithm.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="sortDirection">The sort direction</param>
        /// <returns>The array having the elements sorted.</returns>
        public static int[] SelectionSort(int[] array, SortDirection sortDirection)
        {
            int[] result = Clone(array);

            // Index: 0 | 1 | 2 | 3 |
            // ----------------------
            // Value: 3 | 2 | 4 | 1 |
            // ----------------------

            for (int i = 0; i < array.Length - 1; i++)
            {
                // la fiecare pas, trebuie sa aduc minimul din sub-sirul ramas (i+1 -> capat)
                // pe pozitia i

                for (int j = i + 1; j < array.Length; j++)
                {
                    bool isSwapNeeded;
                    switch (sortDirection)
                    {
                        case SortDirection.Descending:
                            isSwapNeeded = result[i] < result[j];
                            break;

                        case SortDirection.Ascending:
                        default:
                            isSwapNeeded = result[i] > result[j];
                            break;
                    }

                    if (isSwapNeeded)
                    {
                        int temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Calculates the fibonacci sequence till n.
        /// </summary>
        /// <param name="n">The number till which we calculate fibonacci sequence.</param>
        /// <returns>The fibonacci sequence till n.</returns>
        public static long[] Fibonacci(int n)
        {
            if (n < 0)
            {
                return new long[0];
            }

            if (n == 0)
            {
                return new long[] { 0 };
            }

            if (n == 1)
            {
                return new long[] { 0, 1 };
            }

            // For n >= 2
            long[] result = new long[n + 1];
            result[0] = 0;
            result[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result;
        }

        /// <summary>
        /// Returns the sequence of prime numbers till "n" using the Eratostene sieve algorithm.
        /// </summary>
        /// <param name="n">The number till which we return prime numbers.</param>
        /// <returns>The sequence of prime numbers till "n".</returns>
        public static int[] PrimesEratostene(int n)
        {
            if (n <= 1)
            {
                return new int[0];
            }

            // for now on, n >= 2
            bool[] isCut = new bool[n + 1];
            int countPrimes = 0;
            isCut[0] = true;
            isCut[1] = true;

            for (int i = 2; i < isCut.Length; i++)
            {
                if (isCut[i])
                {
                    continue;
                }

                // "i" is prime
                countPrimes++;

                // cut multiples of "i"
                for (int factor = 2; i * factor <= n;factor++)
                {
                    isCut[i * factor] = true;
                }
            }

            int[] result = new int[countPrimes];
            for (int i = 0, indexPrime = 0; i < isCut.Length; i++)
            {
                if (!isCut[i])
                {
                    result[indexPrime] = i;
                    indexPrime++;
                }
            }

            return result;
        }

        /// <summary>
        /// Prints the array to the console.
        /// </summary>
        /// <param name="label">Label used before the array elements.</param>
        /// <param name="array">The array elements.</param>
        public static void Print(string label, int[] array)
        {
            string labelToPrint = label ?? "Array";
            string arrayElementsList = string.Join(", ", array ?? new int[0]);

            Console.WriteLine($"{labelToPrint}=[{arrayElementsList}]");
        }

        /// <summary>
        /// Prints the array to the console.
        /// </summary>
        /// <param name="label">Label used before the array elements.</param>
        /// <param name="array">The array elements.</param>
        public static void Print(string label, long[] array)
        {
            string labelToPrint = label ?? "Array";
            string arrayElementsList = string.Join(", ", array ?? new long[0]);

            Console.WriteLine($"{labelToPrint}=[{arrayElementsList}]");
        }

        /// <summary>
        /// Reads a matrix from console.
        /// </summary>
        /// <param name="label">The matrix label.</param>
        /// <returns>The matrix, as read from the console.</returns>
        public static int[,] ReadMatrix(string label)
        {
            label = label ?? "matrix";

            int rowsCount = ConsoleHelper.ReadNumber($"{label} no of rows", 3, 3);
            int colsCount = ConsoleHelper.ReadNumber($"{label} no of cols", 3, 3);

            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row ++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    int element = ConsoleHelper.ReadNumber($"element[{row}, {col}]", 3, 0);
                    matrix[row, col] = element;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Prints a matrix to the console.
        /// </summary>
        /// <param name="label">The matrix label.</param>
        /// <param name="matrix">The matrix.</param>
        public static void PrintMatrix(string label, int[,] matrix)
        {
            Console.WriteLine(label ?? "Matrix");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col],6}");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the matrix main diagonal.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public static void PrintMainDiagonal(int[,] matrix)
        {
            if (matrix is null)
            {
                Console.WriteLine("Matrix is null, no main diagonal to print!");
                return;
            }

            int rowsCount = matrix.GetLength(0);
            int colsCount = matrix.GetLength(1);

            int maxSize = Math.Min(rowsCount, colsCount);

            Console.WriteLine("Main diagonal elements: ");
            for (int i = 0; i <maxSize; i++)
            {
                Console.Write($"{matrix[i, i],6}, ");
            }

            /* ------------------------------------------------
             * Initial attempt:
             * (inefficient because of 2 for(s))
             * ------------------------------------------------
            Console.WriteLine("Main diagonal elements: ");

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (row == col)
                    {
                        Console.Write($"{matrix[row, col],6}, ");
                    }
                }
            }
            */
        }

        /// <summary>
        /// Gets the elements from the main diagonal as an array of integers.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The elements from the main diagonal as an array of integers.</returns>
        public static int[] GetMainDiagonal(int[,] matrix)
        {
            if (matrix is null)
            {
                return new int[0];
            }

            int rowsCount = matrix.GetLength(0);
            int colsCount = matrix.GetLength(1);

            int maxSize = Math.Min(rowsCount, colsCount);

            int[] result = new int[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                result[i] = matrix[i, i];
            }

            return result;
        }

        /// <summary>
        /// Calculates the sum of two matrices.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The matrix representing the sum of the two matrices.</returns>
        public static int[,] SumMatrices(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                return new int[0, 0];
            }

            int rowsCount1 = matrix1.GetLength(0);
            int colsCount1 = matrix1.GetLength(1);

            int rowsCount2 = matrix2.GetLength(0);
            int colsCount2 = matrix2.GetLength(1);

            if (rowsCount1 != rowsCount2 || colsCount1 != colsCount2)
            {
                // cannot calculate the sum
                return new int[0, 0];
            }

            int[,] sum = new int[rowsCount1, colsCount1];

            for (int row = 0; row < rowsCount1; row++)
            {
                for (int col = 0; col < colsCount1; col++)
                {
                    sum[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }

            return sum;
        }

        /// <summary>
        /// Calculates the product of two matrices.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The matrix representing the product of the two matrices.</returns>
        public static int[,] ProductMatrices(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                return new int[0, 0];
            }

            int rowsCount1 = matrix1.GetLength(0);
            int colsCount1 = matrix1.GetLength(1);

            int rowsCount2 = matrix2.GetLength(0);
            int colsCount2 = matrix2.GetLength(1);

            if (colsCount1 != rowsCount2)
            {
                // cannot calculate product
                return new int[0, 0];
            }

            int[,] product = new int[rowsCount1, colsCount2];

            for (int i = 0; i < rowsCount1; i++)
            {
                for (int j = 0; j < colsCount2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsCount1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }

                    product[i, j] = sum;
                }
            }

            return product;
        }

        /// <summary>
        /// Calculates the cartesian product of 2 sets and returns the pairs as an jagged array.
        /// </summary>
        /// <param name="set1">The first set.</param>
        /// <param name="set2">The second set.</param>
        /// <returns>The cartesian product of 2 sets and returns the pairs as an jagged array.</returns>
        public static int[][] CartesianProduct(int[] set1, int[] set2)
        {
            int[][] cartesian = new int[set1.Length * set2.Length][];

            for (int i = 0, indexCartesian = 0; i < set1.Length; i++)
            {
                for (int j = 0; j < set2.Length; j++, indexCartesian++)
                {
                    cartesian[indexCartesian] = new int[] { set1[i], set2[j] };
                }
            }

            /* 
             * Do the math on indices:
             * 
            for (int i = 0; i < set1.Length; i++)
            {
                for (int j = 0; j < set2.Length; j++)
                {
                    cartesian[i * set2.Length + j] = new int[] { set1[i], set2[j] };
                }
            }
            */
            return cartesian;
        }

        /// <summary>
        /// Prints a jagged array.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="array">The jagged array</param>
        public static void PrintJaggedArray(string label, int[][] array)
        {
            StringBuilder builder = new StringBuilder();

            string labelToPrint = label ?? "Jagged Array";

            builder.Append($"{labelToPrint}=");

            if (array is null)
            {
                builder.Append("<null>");
                Console.WriteLine(builder.ToString());
                return;
            }

            builder.Append("[");

            for (int i = 0; i < array.Length; i++)
            {
                int[] element = array[i];
                if (element is null)
                {
                    builder.Append("(<null>)");
                }
                else
                {
                    string elementsList = string.Join(", ", element);
                    builder.Append($"({elementsList})");
                }

                if (i < array.Length - 1)
                {
                    builder.Append(", ");
                }
            }

            builder.Append("]");

            Console.WriteLine(builder.ToString());
        }

        public static int[][] Frequencies(int[] array)
        {
            // array = [1,      2,      1,      3,      1, 5, 2]
            // freq  = [3,      2,      3,      1,      3, 1, 2]
            //         [(1, 3), (2, 2), (1, 3), (3, 1), ...
            // 1 - 3 ori
            // 2 - 2 ori
            // 3 - 1 data
            // 5 - 1 data

            int[][] elementsWithFrequencies = new int[array.Length][];

            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                int frequencies = 1;

                for (int j = 0; j < array.Length; j++)
                {
                    if ((i != j) && (array[j] == element))
                    {
                        frequencies++;
                    }
                }

                elementsWithFrequencies[i] = new[] { element, frequencies };
            }

            return elementsWithFrequencies;
        }
    }
}
