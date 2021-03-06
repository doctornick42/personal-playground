﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.DataStructures.BinaryTrees
{
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> _root;

        public BinaryTree()
        {
            _root = null;
        }

        public virtual void Clear()
        {
            _root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
            }
        }
    }
}
