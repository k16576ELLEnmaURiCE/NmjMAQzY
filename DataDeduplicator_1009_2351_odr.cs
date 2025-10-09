// 代码生成时间: 2025-10-09 23:51:41
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataDeduplicatorApp
{
    /// <summary>
    /// A utility class for deduplication and merging data.
    /// </summary>
    public class DataDeduplicator
    {
        /// <summary>
        /// Removes duplicates from the provided list of items.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <param name="items">The list of items to deduplicate.</param>
        /// <returns>A new list with duplicates removed.</returns>
        public List<T> Deduplicate<T>(List<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "The items list cannot be null.");
            }

            return new HashSet<T>(items).ToList();
        }

        /// <summary>
        /// Merges two lists of items, removing any duplicates between them.
        /// </summary>
        /// <typeparam name="T">The type of items in the lists.</typeparam>
        /// <param name="firstList">The first list of items.</param>
        /// <param name="secondList">The second list of items.</param>
        /// <returns>A new list containing the merged items without duplicates.</returns>
        public List<T> MergeAndDeduplicate<T>(List<T> firstList, List<T> secondList)
        {
            if (firstList == null)
            {
                throw new ArgumentNullException(nameof(firstList), "The first list cannot be null.");
            }

            if (secondList == null)
            {
                throw new ArgumentNullException(nameof(secondList), "The second list cannot be null.");
            }

            var combinedList = firstList.Concat(secondList).Distinct().ToList();
            return combinedList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dedup = new DataDeduplicator();

                List<int> firstList = new List<int> { 1, 2, 3, 4, 2 };
                List<int> secondList = new List<int> { 3, 4, 5, 6 };

                // Deduplicate the first list
                var deduplicatedFirstList = dedup.Deduplicate(firstList);
                Console.WriteLine("Deduplicated first list: " + string.Join(", ", deduplicatedFirstList));

                // Merge and deduplicate both lists
                var mergedList = dedup.MergeAndDeduplicate(deduplicatedFirstList, secondList);
                Console.WriteLine("Merged and deduplicated list: " + string.Join(", ", mergedList));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}