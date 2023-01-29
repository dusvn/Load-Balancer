using System.Collections.Generic;

namespace Common
{
    public class CollectionDescription
    {
        public uint id { get; }
        public List<WorkerProperty> HistoricalCollection { get; set; }
        public int dataSet { get; set; }
        private static uint count = 0;

        public uint Count { get { return count; } }

        public CollectionDescription()
        {
            id = ++count;
            HistoricalCollection = new List<WorkerProperty>();
            dataSet = -1;
        }
    }
}
