using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class CollectionDescription
    {
        public uint id { get; }
        public List<WorkerProperty> HistoricalCollection { get; set; }
        public int dataSet { get; set; }
        private static uint count = 0;

        public CollectionDescription()
        {
            id = ++count;
            HistoricalCollection = new List<WorkerProperty>();
        }
    }
}
