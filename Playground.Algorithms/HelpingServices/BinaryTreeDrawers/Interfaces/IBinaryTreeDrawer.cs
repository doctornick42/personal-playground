using Playground.Algorithms.DataStructures.BinaryTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.HelpingServices.BinaryTreeDrawers.Interfaces
{
    public interface IBinaryTreeDrawer<T> 
    {
        void Draw(BinaryTree<T> tree);
    }
}
