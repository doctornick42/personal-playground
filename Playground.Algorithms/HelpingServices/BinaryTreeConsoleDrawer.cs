using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Algorithms.DataStructures.BinaryTrees;
using Playground.Algorithms.HelpingServices.BinaryTreeDrawers.Interfaces;

namespace Playground.Algorithms.HelpingServices.BinaryTreeDrawers
{
    public class BinaryTreeConsoleDrawer<T> : IBinaryTreeDrawer<T>
    {
        public void Draw(BinaryTree<T> tree)
        {
            if (tree.Root == null) { return; }

            List<ConsoleTreeRowRepresentation> rows = new List<ConsoleTreeRowRepresentation>();

            ConsoleTreeRowRepresentation rootRow = new ConsoleTreeRowRepresentation(new List<string> { tree.Root.Value.ToString() });
            rows.Add(rootRow);

            var currentLevel = GetNextLevel(new BinaryTreeNode<T>[1] { tree.Root });

            while (currentLevel.Length > 0)
            {
                string[] currentLevelNodeValues = currentLevel.Select(x => x.Value.ToString()).ToArray();
                rows.Add(new ConsoleTreeRowRepresentation(currentLevelNodeValues));

                currentLevel = GetNextLevel(currentLevel);
            }

            foreach (var row in rows)
            {
                Console.WriteLine(String.Join("     ", row.Values));
            }
        }

        private void SetRowsOffsets(IEnumerable<ConsoleTreeRowRepresentation> rows)
        {
            int rowsCount = rows.Count();
            if (rowsCount == 1) { return; }

            int maxElemetsInRowCount = 2 * rowsCount;
        }

        private BinaryTreeNode<T>[] GetNextLevel(BinaryTreeNode<T>[] currentLevel)
        {
            List<BinaryTreeNode<T>> resultAsList = new List<BinaryTreeNode<T>>();
            for (int i = 0; i < currentLevel.Length; i++)
            {
                BinaryTreeNode<T> currentNode = currentLevel[i];
                if (currentNode != null)
                {
                    if (currentNode.Left != null) { resultAsList.Add(currentNode.Left); }
                    if (currentNode.Right != null) { resultAsList.Add(currentNode.Right); }
                }
            }

            return resultAsList.ToArray();
        }
    }

    public struct ConsoleTreeRowRepresentation
    {
        public ConsoleTreeRowRepresentation(IEnumerable<string> values, int offset = 0)
        {
            Values = values.ToArray();
            StartingOffset = offset;
        }

        public string[] Values { get; set; }
        public int StartingOffset { get; set; }
    }
}
