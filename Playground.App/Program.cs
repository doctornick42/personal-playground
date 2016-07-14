using Playground.Algorithms.HelpingServices;
using Playground.Algorithms.Sorting;
using Playground.Algorithms.Sorting.BubbleSorting;
using Playground.Algorithms.Sorting.Infrastructure;
using Playground.Algorithms.Sorting.QuickSorting;
using Playground.Algorithms.Sorting.MergeSorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.App
{
    class Program
    {
        private static List<int> GetRandomList(int size)
        {
            List<int> ret = new List<int>(size);
            Random rand = new Random(1);
            for (int i = 0; i < size; i++)
            {
                ret.Add(rand.Next(size));
            }
            return ret;
        }

        private static int[] arrayWithNoCollisions = new int[8]
        {
            4, 9, 7, 6, 2, 3, 8, 1
        };

        private static int[] arrayWithCollisions = new int[10]
        {
            3, 1, 4, 1, 5, 9, 2, 6, 5, 3
        };

        private static int[] longerArray = new int[16]
        {
            4, 9, 7, 6, 2, 3, 8, 14, 5, 1, 9, 43, 41, 192, 12, 37
        };

        static void Main(string[] args)
        {
            SortingChecker<int> sortingChecker = new SortingChecker<int>();
            TimeMeasurer tm = new TimeMeasurer();

            int[] arrayToSort = GetRandomList(10000).ToArray();

            SortingRunner sortingRunner = new SortingRunner();
            sortingRunner.OnMessageAppears += x => Console.WriteLine(x);
            sortingRunner.Run(new MergeSortingService<int>(), arrayToSort, tm, sortingChecker);
            sortingRunner.Run(new BubbleSortingService<int>(), arrayToSort, tm, sortingChecker);
            sortingRunner.Run(new LomutoQuickSortingService<int>(), arrayToSort, tm, sortingChecker);
            sortingRunner.Run(new HoareQuickSortingService<int>(), arrayToSort, tm, sortingChecker);
            Console.ReadLine();
        }

        private static async Task RxTest()
        {
            var client = new WebClient();
            var downloadedStrings = Observable.FromEventPattern(client, "DownloadStringCompleted");

            downloadedStrings.Subscribe(
                data =>
                {
                    var eventArgs = (DownloadStringCompletedEventArgs)data.EventArgs;
                    if (eventArgs.Error != null)
                    {
                        Console.WriteLine("OnNext: (Error) " + eventArgs.Error);
                    }
                    else
                    {
                        Console.WriteLine("OnNext: " + eventArgs.Result);
                    }
                    Console.ReadLine();
                },
                ex => Console.WriteLine("OnError: " + ex.ToString()),
                () => Console.WriteLine("OnCompleted"));

            client.DownloadStringAsync(new Uri("http://invalid.example.com"));
        }
    }
}
