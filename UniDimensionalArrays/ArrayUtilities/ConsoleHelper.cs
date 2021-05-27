using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayUtilities
{
    /// <summary>
    /// Utilities for working with the console.
    /// </summary>
    public static class ConsoleHelper
    {
        public static int ReadNumber(string label, int maxAttempts, int defaultValue)
        {
            label = label ?? "Please enter a number";
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                Console.Write($"{label}=");
                string value = Console.ReadLine();
                if (int.TryParse(value, out int number))
                {
                    return number;
                }

                attempts++;
                Console.WriteLine($"Value '{value}' doesn't represent a number, please try again ({maxAttempts - attempts} attempts remaining) ...");
            }

            return defaultValue;
        }
    }
}
