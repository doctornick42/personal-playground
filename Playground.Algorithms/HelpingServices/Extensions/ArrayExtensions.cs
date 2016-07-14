using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.HelpingServices.Extensions
{
    public static class ArrayExtensions
    {
        public static void ExchangeElements<T>(this T[] array, int firstIndex, int secondIndex)
        {
            T buffer = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = buffer;
        }
    }
}
