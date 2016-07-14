using Playground.Algorithms.Sorting.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.Sorting.QuickSorting
{
    public class HoareQuickSortingService<T> : QuickSortingServiceBase<T>
        where T : IComparable
    {
        public override string AlgorithmName
        {
            get
            {
                return "Quicksort with the Hoare partition";
            }
        }

        protected override void SortSubArray(T[] originalCollection, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Part(originalCollection, left, right);
                SortSubArray(originalCollection, left, pivotIndex);
                SortSubArray(originalCollection, pivotIndex + 1, right);
            }
        }

        protected override int Part(T[] collection, int left, int right)
        {
            T pivot = collection[left];
            int currentLeftIndex = left - 1;
            int currentRightIndex = right + 1;

            while (true)
            {
                do
                {
                    currentLeftIndex++;
                } while (collection[currentLeftIndex].CompareTo(pivot) < 0);
                //while currentLeftIndexed element is less than pivot

                do
                {
                    currentRightIndex--;
                } while (collection[currentRightIndex].CompareTo(pivot) > 0);
                //while currentRightIndexed element is more than pivot

                if (currentLeftIndex >= currentRightIndex)
                {
                    //new pivot
                    return currentRightIndex;
                }

                Exchange(collection, currentLeftIndex, currentRightIndex);

                if (_withDebuggingInfo)
                {
                    Console.WriteLine(String.Join(", ", collection));
                }
            }
        }
    }
}
