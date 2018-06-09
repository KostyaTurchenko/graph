using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntGraph
{
    public class Pair
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public static List<Pair> PairsFromString(string str)
        {
            String[] Split = str.Split(new char[] { ' ', '\r', '\n', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (Split.Length % 2 != 0)
                throw new Exception();
            List<Pair> pairs = new List<Pair>();
            for (int i = 0; i < Split.Length/2; i++)
            {
                pairs.Add(new Pair(int.Parse(Split[2 * i]), int.Parse(Split[2 * i + 1])));
            }
            return pairs;
        }

        public Pair(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }
}
