using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skribble
{
    public class Pair
    {
        public int i { get; set; }
        public int j { get; set; }

        public Pair(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;
            return pair != null &&
                   i == pair.i &&
                   j == pair.j;
        }

        public override int GetHashCode()
        {
            var hashCode = -118560031;
            hashCode = hashCode * -1521134295 + i.GetHashCode();
            hashCode = hashCode * -1521134295 + j.GetHashCode();
            return hashCode;
        }
    }
}
