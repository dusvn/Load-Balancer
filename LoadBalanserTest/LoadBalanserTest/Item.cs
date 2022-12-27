using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalanserTest
{
    public enum Code { CODE_ANALOG, CODE_DIGITAL, CODE_CUSTOM, CODE_LIMITSET, CODE_SINGLENODE, CODE_MULTIPLENODE, CODE_CONSUMER, CODE_SOURCE }
    class Item
    {
        Code code { get; }
        int value { get; }
        public Item(Code c, int v) { code = c; value = v; }
    }
}
