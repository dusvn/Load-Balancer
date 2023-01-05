using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class Description
    {
        public uint id { get; set; }
        public List<Item> ItemList { get; set; }
        public int dataSet { get; set; }
        private static uint count = 0;

        public Description(int ds)
        {
            id = ++count;
            ItemList = new List<Item>();
            dataSet = ds;
        }
    }
}
