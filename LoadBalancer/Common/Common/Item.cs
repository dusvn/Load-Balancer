using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public Code code;
        [DataMember]
        public int value;
        public Item(Code c, int v) { code = c; value = v; }
        public override string ToString()
        {
            return code + " " + value;
        }
    }
}
