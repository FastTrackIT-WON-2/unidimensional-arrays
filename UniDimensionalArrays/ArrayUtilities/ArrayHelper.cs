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
    }
}
