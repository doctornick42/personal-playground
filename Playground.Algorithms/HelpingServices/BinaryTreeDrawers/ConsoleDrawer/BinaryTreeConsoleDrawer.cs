using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Algorithms.DataStructures.BinaryTrees;
using Playground.Algorithms.HelpingServices.BinaryTreeDrawers.Interfaces;

namespace Playground.Algorithms.HelpingServices.BinaryTreeDrawers.ConsoleDrawer
{
    public class BinaryTreeConsoleDrawer<T> : IBinaryTreeDrawer<T>
    {
        private readonly int _maxWidth = Console.BufferWidth;

        private List<TreeRowConsoleRepresentation<T>> PrepareTreeToBeDrawn(BinaryTree<T> tree)
        {
            List<TreeRowConsoleRepresentation<T>> result = new List<TreeRowConsoleRepresentation<T>>();

            if (tree.Root == null) { return result; }

            int middlePosition = _maxWidth / 2;
            TreeNodeConsoleRepresentation<T> rootNodeRepresentation = new TreeNodeConsoleRepresentation<T>(tree.Root, -1, middlePosition);
            TreeRowConsoleRepresentation<T> rootRow = new TreeRowConsoleRepresentation<T>(rootNodeRepresentation);

            result.Add(rootRow);

            var currentLevel = GetNextLevel(rootNodeRepresentation);

            while (currentLevel.Length > 0)
            {
                result.Add(new TreeRowConsoleRepresentation<T>(currentLevel));

                currentLevel = GetNextLevel(currentLevel);
            }

            return result;
        }

        private void DrawRows(List<TreeRowConsoleRepresentation<T>> rows)
        {
            foreach (var row in rows)
            {
                int relationsLevelTop = Console.CursorTop;
                int nodesLevelTop = Console.CursorTop + 1;
                List<int> occupiedPlaces = new List<int>();

                foreach (var node in row.Values)
                {
                    while (occupiedPlaces.Contains(node.Offset))
                    {
                        node.Offset = node.Offset + 2;
                    }

                    if (node.ParentOffset > -1)
                    {
                        int currentCursorTop = Console.CursorTop;

                        if (node.Offset < node.ParentOffset)
                        {
                            Console.SetCursorPosition(node.Offset + 1, relationsLevelTop);
                            Console.Write("/");
                        }
                        else if (node.Offset > node.ParentOffset)
                        {
                            Console.SetCursorPosition(node.Offset - 1, relationsLevelTop);
                            Console.Write("\\");
                        }
                        else
                        {
                            Console.SetCursorPosition(node.Offset, relationsLevelTop);
                            Console.Write("|");
                        }
                    }
                    Console.SetCursorPosition(node.Offset, nodesLevelTop);
                    occupiedPlaces.Add(node.Offset);
                    Console.Write(node.Node.Value);
                }

                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
        }

        private TreeNodeConsoleRepresentation<T>[] GetNextLevel(TreeNodeConsoleRepresentation<T> root)
        {
            return GetNextLevel(new TreeNodeConsoleRepresentation<T>[1] { root });
        }

        private TreeNodeConsoleRepresentation<T>[] GetNextLevel(TreeNodeConsoleRepresentation<T>[] currentLevel)
        {
            List<TreeNodeConsoleRepresentation<T>> resultAsList = new List<TreeNodeConsoleRepresentation<T>>();
            for (int i = 0; i < currentLevel.Length; i++)
            {
                TreeNodeConsoleRepresentation<T> currentNode = currentLevel[i];
                if (currentNode.Node != null)
                {
                    TreeNodeConsoleRepresentation<T> leftChild = new TreeNodeConsoleRepresentation<T>(currentNode.Node.Left,
                        currentNode.Offset, currentNode.Offset - 2);

                    TreeNodeConsoleRepresentation<T> rightChild = new TreeNodeConsoleRepresentation<T>(currentNode.Node.Right,
                        currentNode.Offset, currentNode.Offset + 2);

                    if (currentNode.Node.Left != null) { resultAsList.Add(leftChild); }
                    if (currentNode.Node.Right != null) { resultAsList.Add(rightChild); }

                }
            }

            return resultAsList.ToArray();
        }

        public void Draw(BinaryTree<T> tree)
        {
            List<TreeRowConsoleRepresentation<T>> rows = PrepareTreeToBeDrawn(tree);
            DrawRows(rows);
        }   
    }   
}
