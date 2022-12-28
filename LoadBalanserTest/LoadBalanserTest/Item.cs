using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalanserTest
{
    public class Item
    {
        public Code code { get; }
        public int value { get; }
        public Item(Code c, int v) { code = c; value = v; }
    }
}
