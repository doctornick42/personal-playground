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
        public const int MAX_WIDTH = 500;

        public void Draw(BinaryTree<T> tree)
        {
            if (tree.Root == null) { return; }

            List<ConsoleTreeRowRepresentation> rows = new List<ConsoleTreeRowRepresentation>();

            int middlePosition = MAX_WIDTH / 2;
            ConsoleTreeNodeRepresentation rootNodeRepresentation = new ConsoleTreeNodeRepresentation(tree.Root.Value.ToString(), 0, middlePosition);
            ConsoleTreeRowRepresentation rootRow = new ConsoleTreeRowRepresentation(rootNodeRepresentation);

            rows.Add(rootRow);

            var currentLevel = GetNextLevel(rootNodeRepresentation);

            while (currentLevel.Length > 0)
            {
                string[] currentLevelNodeValues = currentLevel
                    .Select(x => new ConsoleTreeNodeRepresentation(x.Value.ToString()))
                    .ToArray();
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

        private NodeAndParentOffset<T>[] GetNextLevel(NodeAndParentOffset<T> root)
        {
            return GetNextLevel(new NodeAndParentOffset<T>[1] { root });
        }

        private NodeAndParentOffset<T>[] GetNextLevel(NodeAndParentOffset<T>[] currentLevel)
        {
            List<NodeAndParentOffset<T>> resultAsList = new List<NodeAndParentOffset<T>>();
            for (int i = 0; i < currentLevel.Length; i++)
            {
                NodeAndParentOffset<T> currentNode = currentLevel[i];
                if (currentNode.Node != null)
                {
                    NodeAndParentOffset<T> leftChild = new NodeAndParentOffset<T>()
                    {
                        Node = currentNode.Node.Left,
                        ParentOffset = currentNode.Offset,
                        Offset = currentNode.Offset - 1
                    };

                    NodeAndParentOffset<T> rightChild = new NodeAndParentOffset<T>()
                    {
                        Node = currentNode.Node.Right,
                        ParentOffset = currentNode.Offset,
                        Offset = currentNode.Offset + 1
                    };

                    if (currentNode.Node.Left != null) { resultAsList.Add(leftChild); }
                    if (currentNode.Node.Right != null) { resultAsList.Add(rightChild); }

                }
            }

            return resultAsList.ToArray();
        }
    }

    public struct ConsoleTreeRowRepresentation
    {
        public ConsoleTreeRowRepresentation(IEnumerable<ConsoleTreeNodeRepresentation> values)
        {
            Values = values.ToArray();
        }

        public ConsoleTreeRowRepresentation(ConsoleTreeNodeRepresentation rootValue)
        {
            Values = new ConsoleTreeNodeRepresentation[1] { rootValue };
        }

        public ConsoleTreeNodeRepresentation[] Values { get; set; }
    }

    public struct ConsoleTreeNodeRepresentation
    {
        public ConsoleTreeNodeRepresentation(string value, int parentOffset, int offset)
        {
            Value = value;
            Offset = offset;
            ParentOffset = offset;
        }

        public string Value { get; set; }
        public int Offset { get; set; }
        public int ParentOffset { get; set; }
    }

    public struct NodeAndParentOffset<T>
    {
        public BinaryTreeNode<T> Node { get; set; }
        public int Offset { get; set; }
        public int ParentOffset { get; set; }
    }
}
