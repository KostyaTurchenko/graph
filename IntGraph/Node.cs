using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntGraph
{
    public class Node
    {
        public PairGraph Parent { get; internal set; }
        public int Value { get; set; }
        public List<Node> Edges { get; set; }
        internal Node(int value, PairGraph gr)
        {
            Value = value;
            Parent = gr;
            Edges = new List<Node>();
        }
        public void AddEdge(Node node)
        {
            if (node.Parent != Parent)
                throw new ArgumentException();
            if (Edges.Contains(node))
                return;
            Edges.Add(node);
        }
        public List<int> GetMaxWay()
        {
            List<int> Last = new List<int>() { Value };
            List<int> Max = null;
            for (int i = 0; i < Edges.Count; i++)
            {
                Node T = Edges[i];
                Edges.RemoveAt(i);
                List<int> list = T.GetMaxWay();
                if (Max == null || Max.Count < list.Count)
                    Max = list;
                Edges.Insert(i, T);
            }
            if (Max != null)
            Last.AddRange(Max);
            return Last;
        }
    }
}
