using System.Collections.Generic;
using System.Linq;

namespace Playground.Algorithms.HelpingServices.BinaryTreeDrawers.ConsoleDrawer
{
    public class TreeRowConsoleRepresentation<T>
    {
        public TreeRowConsoleRepresentation(IEnumerable<TreeNodeConsoleRepresentation<T>> values)
        {
            Values = values.ToArray();
        }

        public TreeRowConsoleRepresentation(TreeNodeConsoleRepresentation<T> rootValue)
        {
            Values = new TreeNodeConsoleRepresentation<T>[1] { rootValue };
        }

        public TreeNodeConsoleRepresentation<T>[] Values { get; set; }
    }
}
