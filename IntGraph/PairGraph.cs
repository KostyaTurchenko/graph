using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntGraph
{
    public class PairGraph
    {
        public List<Node> Items { get; set; } = new List<Node>();
        public void Add(int value) => Items.Add(new Node(value, this));
        public PairGraph(List<Pair> pairs)
        {
            foreach (Pair pair in pairs)
            {
                Node A = null;
                Node B = null;
                foreach (Node item in Items)
                {
                    if (item.Value == pair.Left)
                        A = item;
                    if (item.Value == pair.Right)
                        B = item;
                    if (A != null && B != null)
                        break;
                }
                if(A==null)
                {
                    Add(pair.Left);
                    A = Items[Items.Count - 1];
                }
                if (B == null)
                {
                    Add(pair.Right);
                    B = Items[Items.Count - 1];
                }
                A.AddEdge(B);
            }
        }
        public List<int> GetMaxWay()
        {
            List<int> Way = null;
            foreach (Node item in Items)
            {
                List<int> WayT = item.GetMaxWay();
                if (Way == null || Way.Count < WayT.Count)
                    Way = WayT;
            }
            return Way;
        }
    }
}