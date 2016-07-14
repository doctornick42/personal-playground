using Playground.Algorithms.HelpingServices;
using Playground.Algorithms.Sorting.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.Sorting
{
    public class SortingRunner
    {
        public SortingRunner(bool writeDownArrayContent = false)
        {
            WriteDownArrayContent = writeDownArrayContent;
        }

        public bool WriteDownArrayContent { get; set; }

        public event Action<string> OnMessageAppears;

        public void Run<T>(ISortingAlgorithmService<T> service, T[] arrayToSort, TimeMeasurer timeMeasurer,
            SortingChecker<T> sortingChecker)
            where T : IComparable
        {
            //make a copy of array to not modify it
            T[] arrayCopy = new T[arrayToSort.Length];
            arrayToSort.CopyTo(arrayCopy, 0);

            if (WriteDownArrayContent)
            {
                OnMessageAppears.Invoke(String.Format("Original array: {0}", String.Join(", ", arrayCopy)));
            }

            OnMessageAppears.Invoke(String.Format("Chosen algorithm: {0}", service.AlgorithmName));
            OnMessageAppears.Invoke(String.Format("Array length: {0}", arrayCopy.Length));

            timeMeasurer.onWatchStop += OnMessageAppears;
            timeMeasurer.RunAndLogOutTime(service, x => x.Sort(arrayCopy));
            timeMeasurer.onWatchStop -= OnMessageAppears;

            if (WriteDownArrayContent)
            {
                OnMessageAppears.Invoke(String.Format("Sorted array: {0}", String.Join(", ", arrayCopy)));
            }

            OnMessageAppears.Invoke(String.Format("Ordering is {0}",
                sortingChecker.CheckOrder(arrayCopy) ? "ok" : "not ok"));

            OnMessageAppears.Invoke(String.Format("\r\n"));
        }
    }
}
