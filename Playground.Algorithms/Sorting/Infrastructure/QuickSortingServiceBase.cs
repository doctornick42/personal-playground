using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.Sorting.Infrastructure
{
    public abstract class QuickSortingServiceBase<T> : ISortingAlgorithmService<T>
        where T : IComparable
    {
        public abstract string AlgorithmName
        {
            get;
        }

        protected bool _withDebuggingInfo;

        protected abstract void SortSubArray(T[] originalCollection, int left, int right);

        protected abstract int Part(T[] collection, int left, int right);

        protected void Exchange(T[] collection, int firstIndex, int secondIndex)
        {
            T buffer = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = buffer;
        }

        public virtual void Sort(T[] originalCollection, bool withDebuggingInfo = false)
        {
            _withDebuggingInfo = withDebuggingInfo;

            //T[] copiedArray = new T[originalCollection.Length];
            //Array.Copy(originalCollection, copiedArray, originalCollection.Length);
            //SortSubArray(copiedArray, 0, copiedArray.Length - 1);

            SortSubArray(originalCollection, 0, originalCollection.Length - 1);

            //return copiedArray;
        }

        public virtual T[] GetCurrentSubArray(T[] originalArray, int leftIndex, int rightIndex)
        {
            T[] result = new T[rightIndex - leftIndex + 1];

            for (int i = 0; i < result.Length - 1; i++)
            {
                result[i] = originalArray[i + leftIndex];
            }

            return result;
        }
    }
}
