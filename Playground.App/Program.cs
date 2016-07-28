using Playground.Algorithms.HelpingServices;
using Playground.Algorithms.Sorting;
using Playground.Algorithms.Sorting.BubbleSorting;
using Playground.Algorithms.Sorting.QuickSorting;
using Playground.Algorithms.Sorting.MergeSorting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Playground.Algorithms.DataStructures.BinaryTrees;
using Playground.Algorithms.HelpingServices.BinaryTreeDrawers.Interfaces;
using Playground.Algorithms.HelpingServices.BinaryTreeDrawers.ConsoleDrawer;

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
            RunBinaryTreeConsoleDrawer(args);
        }

        private static void RunSortingServices(string[] args)
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

        private static void RunBinaryTreeConsoleDrawer(string[] args)
        {
            IBinaryTreeDrawer<int> binaryTreeDrawer = new BinaryTreeConsoleDrawer<int>();
            BinaryTree<int> testTree = new BinaryTree<int>();

            testTree.Root = new BinaryTreeNode<int>(1);
            testTree.Root.Left = new BinaryTreeNode<int>(2);
            testTree.Root.Right = new BinaryTreeNode<int>(3);
            testTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            testTree.Root.Left.Right = new BinaryTreeNode<int>(5);
            testTree.Root.Right.Left = new BinaryTreeNode<int>(3);
            testTree.Root.Right.Right = new BinaryTreeNode<int>(2);
            testTree.Root.Left.Left.Left = new BinaryTreeNode<int>(7);
            testTree.Root.Left.Left.Right = new BinaryTreeNode<int>(5);
            testTree.Root.Left.Right.Left = new BinaryTreeNode<int>(8);
            testTree.Root.Left.Right.Right = new BinaryTreeNode<int>(9);
            testTree.Root.Left.Left.Left.Left = new BinaryTreeNode<int>(4);
            testTree.Root.Left.Left.Left.Right = new BinaryTreeNode<int>(8);
            testTree.Root.Left.Left.Right.Left = new BinaryTreeNode<int>(0);
            testTree.Root.Left.Left.Right.Right = new BinaryTreeNode<int>(1);
            testTree.Root.Left.Right.Left.Left = new BinaryTreeNode<int>(5);
            testTree.Root.Left.Right.Right.Left = new BinaryTreeNode<int>(3);

            binaryTreeDrawer.Draw(testTree);
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
