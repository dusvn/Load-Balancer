using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class Worker
    {
        CollectionDescription cd;
        public Worker()
        {
            cd = new CollectionDescription();
        }
        public void primiDescription(Description desc)
        {
            cd.dataSet = desc.dataSet;
            foreach(Item item in desc.ItemList)
            {
                WorkerProperty wp = new WorkerProperty(item);
                cd.HistoricalCollection.Add(wp);
            }
        }
    }
}
