using System;

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

        public static int[] BubbleSortAsc(int[] array)
        {
            if (array is null)
            {
                return new int[0];
            }

            if (array.Length == 0)
            {
                return new int[0];
            }

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
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        // A     B     Temp
                        // A -> Temp (A gol)
                        // B -> A (B devine gol)
                        // Temp -> B (Temp devine gol)
                        // B     A    Temp

                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        areElementsOrdered = false;
                        break;
                    }
                }
            }
            while (!areElementsOrdered);

            return array;
        }

        public static void Print(string label, int[] array)
        {
            string labelToPrint = label ?? "Array";
            string arrayElementsList = string.Join(", ", array ?? new int[0]);

            Console.WriteLine($"{labelToPrint}=[{arrayElementsList}]");
        }
    }
}
