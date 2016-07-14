using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.Sorting.Infrastructure
{
    public interface ISortingAlgorithmService<T>
        where T : IComparable
    {
        string AlgorithmName { get; }

        void Sort(T[] originalCollection, bool withDebuggingInfo = false);
    }
}
