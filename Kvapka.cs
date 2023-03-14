using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3
{
    internal class Kvapka
    {
        private char drop { get; }

        public Kvapka(char drop)
        {
            this.drop = drop;
        }

        public char Drop { get { return drop; } }
    }
}
