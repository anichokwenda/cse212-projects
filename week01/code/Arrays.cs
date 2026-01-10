using System;
using System.Collections.Generic;

/// <summary>
/// Provides utility methods for common array and list operations.
/// This class is intended to be used as a library and does not contain
/// any executable entry point (Main).
/// </summary>
public static class Arrays
{
    /// <summary>
    /// Generates an array containing consecutive multiples of a given number.
    /// </summary>
    /// <param name="number">The number whose multiples are generated.</param>
    /// <param name="length">The number of multiples to generate.</param>
    /// <returns>
    /// An array of length <paramref name="length"/> where each element is
    /// <paramref name="number"/> multiplied by its (1-based) position.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="length"/> is negative.
    /// </exception>
    public static double[] MultiplesOf(double number, int length)
    {
        // Length must be non-negative; arrays cannot have negative sizes
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length));

        // Allocate the result array
        double[] result = new double[length];

        // Fill the array with multiples of the given number
        for (int i = 0; i < length; i++)
        {
            // i + 1 is used to start multiples at 1 × number
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotates the elements of a list to the right by a specified amount.
    /// The rotation is performed in-place.
    /// </summary>
    /// <param name="data">The list to rotate.</param>
    /// <param name="amount">The number of positions to rotate to the right.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="data"/> is null.
    /// </exception>
    public static void RotateListRight(List<int> data, int amount)
    {
        // The list itself must exist
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        int count = data.Count;

        // An empty list does not need to be rotated
        if (count == 0)
            return;

        // Normalize the rotation amount to the list length
        amount %= count;

        // Convert negative rotations into equivalent positive rotations
        if (amount < 0)
            amount += count;

        // If the normalized amount is zero, the list remains unchanged
        if (amount == 0)
            return;

        // Rotation is achieved using three reversals:
        // 1) Reverse the entire list
        // 2) Reverse the first 'amount' elements
        // 3) Reverse the remaining elements
        data.Reverse();
        data.Reverse(0, amount);
        data.Reverse(amount, count - amount);
    }

    /// <summary>
    /// Computes all positive divisors of a given number.
    /// </summary>
    /// <param name="number">The number whose divisors are calculated.</param>
    /// <returns>A sorted list of all positive divisors of <paramref name="number"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="number"/> is less than or equal to zero.
    /// </exception>
    public static List<int> Divisors(int number)
    {
        // Divisors are only defined for positive integers
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number));

        var divisors = new List<int>();

        // Only iterate up to the square root for efficiency
        int limit = (int)Math.Sqrt(number);

        for (int i = 1; i <= limit; i++)
        {
            // If i divides the number, add both i and its complement
            if (number % i == 0)
            {
                divisors.Add(i);

                int other = number / i;
                // Avoid adding the square root twice for perfect squares
                if (other != i)
                    divisors.Add(other);
            }
        }

        // Sort the divisors in ascending order before returning
        divisors.Sort();
        return divisors;
    }

    /// <summary>
    /// Selects elements from an array using a set of indices.
    /// </summary>
    /// <param name="array">The source array.</param>
    /// <param name="indices">The indices of elements to select.</param>
    /// <returns>
    /// A new array containing elements from <paramref name="array"/> at the
    /// specified <paramref name="indices"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="array"/> or <paramref name="indices"/> is null.
    /// </exception>
    /// <exception cref="IndexOutOfRangeException">
    /// Thrown when any index is outside the bounds of <paramref name="array"/>.
    /// </exception>
    public static int[] ArraySelector(int[] array, int[] indices)
    {
        // Both input arrays must exist
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (indices == null)
            throw new ArgumentNullException(nameof(indices));

        // Create an array to hold the selected values
        int[] result = new int[indices.Length];

        // Copy elements from the source array using the provided indices
        for (int i = 0; i < indices.Length; i++)
        {
            int index = indices[i];

            // Validate index bounds explicitly
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException($"Invalid index: {index}");

            result[i] = array[index];
        }

        return result;
    }
}
