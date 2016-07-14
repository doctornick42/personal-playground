using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Algorithms.Sorting.Infrastructure;
using Playground.Algorithms.HelpingServices.Extensions;

namespace Playground.Algorithms.Sorting.BubbleSorting
{
    public class BubbleSortingService<T> : ISortingAlgorithmService<T>
        where T : IComparable
    {
        public string AlgorithmName
        {
            get
            {
                return "Bubble sorting";
            }
        }

        public void Sort(T[] originalCollection, bool withDebuggingInfo = false)
        {
            bool replacesExist = false;

            do
            {
                replacesExist = false;

                for (int i = 0; i < originalCollection.Length - 1; i++)
                {
                    if (originalCollection[i].CompareTo(originalCollection[i + 1]) > 0)
                    {
                        originalCollection.ExchangeElements(i, i + 1);
                        replacesExist = true;
                    }
                }
            }
            while (replacesExist);
        }
    }
}
