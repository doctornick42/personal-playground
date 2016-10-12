using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.DataStructures.BinaryTrees
{
    public class BinarySearchTree<T> : BinaryTree<T>
    {
        private IComparer<T> _comparer;

        public BinarySearchTree() : this(Comparer<T>.Default)
        {
        }

        public BinarySearchTree(IComparer<T> comparer) : base()
        {
            _comparer = comparer;
        }

        public bool Contains(T data)
        {
            BinaryTreeNode<T> current = Root;
            int result;

            while (current != null)
            {
                result = _comparer.Compare(current.Value, data);
                if (result == 0)
                {
                    return true;
                }
                else if (result > 0)
                {
                    current = current.Left;
                }
                else if (result < 0)
                {
                    current = current.Right;
                }
            }

            return false;
        }
    }
}
