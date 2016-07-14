using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.Sorting
{
    public class SortingChecker<T>
        where T : IComparable
    {
        public bool CheckOrder(T[] collection)
        {
            T[] collectionCopy = new T[collection.Length];
            collection.CopyTo(collectionCopy, 0);

            return Enumerable.SequenceEqual(collection, collectionCopy.OrderBy(x => x));
        }
    }
}
