using Playground.Algorithms.DataStructures.BinaryTrees;

namespace Playground.Algorithms.HelpingServices.BinaryTreeDrawers.ConsoleDrawer
{
    public class TreeNodeConsoleRepresentation<T>
    {
        public TreeNodeConsoleRepresentation(BinaryTreeNode<T> node, int parentOffset, int offset)
        {
            Node = node;
            Offset = offset;
            ParentOffset = parentOffset;
        }

        public BinaryTreeNode<T> Node { get; set; }
        public int Offset { get; set; }
        public int ParentOffset { get; set; }
    }
}
