using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Algorithms.Sorting.Infrastructure;

namespace Playground.Algorithms.Sorting.MergeSorting
{
    public class MergeSortingService<T> : ISortingAlgorithmService<T>
        where T : IComparable
    {
        public string AlgorithmName
        {
            get
            {
                return "Merge sorting algorithm";
            }
        }

        private T[] Merge(T[] firstArray, T[] secondArray)
        {
            int resultArrayLength = firstArray.Length + secondArray.Length;
            T[] result = new T[resultArrayLength];

            int firstIndex = 0;
            int secondIndex = 0;
            int index = 0;

            while (firstIndex < firstArray.Length
                && secondIndex < secondArray.Length)
            {
                if (firstArray[firstIndex].CompareTo(secondArray[secondIndex]) <= 0)
                {
                    result[index] = firstArray[firstIndex];
                    firstIndex++;
                }
                else
                {
                    result[index] = secondArray[secondIndex];
                    secondIndex++;
                }

                index++;
            }

            while (firstIndex < firstArray.Length)
            {
                result[index] = firstArray[firstIndex];
                firstIndex++;
                index++;
            }

            while (secondIndex < secondArray.Length)
            {
                result[index] = secondArray[secondIndex];
                secondIndex++;
                index++;
            }

            return result;
        }

        private T[] SortArray(T[] collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return new T[1] { collection[startIndex] };
            }

            int middle = (startIndex + endIndex) / 2;

            T[] firstArray = SortArray(collection, startIndex, middle);
            T[] secondArray = SortArray(collection, middle + 1, endIndex);

            return Merge(firstArray, secondArray);
        } 

        public void Sort(T[] originalCollection, bool withDebuggingInfo = false)
        {
            T[] orderedArray = SortArray(originalCollection, 0, originalCollection.Length - 1);

            for (int i = 0; i < originalCollection.Length; i++)
            {
                originalCollection[i] = orderedArray[i];
            }
        }
    }
}
