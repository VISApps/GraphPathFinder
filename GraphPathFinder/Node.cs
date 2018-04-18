using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinder
{
    class Node
    {
        public int child = 0;
        public int parent = 0;
        public Node(int child, int parent)
        {
            this.child = child;
            this.parent = parent;
        }
    }
}
