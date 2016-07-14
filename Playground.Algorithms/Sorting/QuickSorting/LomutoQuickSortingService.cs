using Playground.Algorithms.Sorting.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.Sorting.QuickSorting
{
    public class LomutoQuickSortingService<T> : QuickSortingServiceBase<T>
        where T : IComparable
    {
        public override string AlgorithmName
        {
            get
            {
                return "Quicksort with the Lomuto partition";
            }
        }

        protected override void SortSubArray(T[] originalCollection, int left, int right)
        {
            if (left < right)
            {
                if (_withDebuggingInfo)
                {
                    Console.WriteLine(String.Format("Current sub array: {0}", String.Join(", ", GetCurrentSubArray(originalCollection, left, right))));
                }

                int pivotIndex = Part(originalCollection, left, right);
                SortSubArray(originalCollection, left, pivotIndex - 1);
                SortSubArray(originalCollection, pivotIndex + 1, right);
            }
        }

        protected override int Part(T[] collection, int left, int right)
        {
            T pivot = collection[right];
            int swappingIndex = left;

            for (int i = left; i < right; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    Exchange(collection, swappingIndex, i);
                    swappingIndex++;
                }
            }

            if (swappingIndex < collection.Length && right < collection.Length)
            {
                Exchange(collection, swappingIndex, right);
            }
            return swappingIndex;
        }
    }
}
