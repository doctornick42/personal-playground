using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.DataStructures.BinaryTrees
{
    public class Node<T>
    {
        private T _data;
        private NodeList<T> _neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this._data = data;
            this._neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return _neighbors;
            }

            set
            {
                _neighbors = value;
            }
        }
    }
}
