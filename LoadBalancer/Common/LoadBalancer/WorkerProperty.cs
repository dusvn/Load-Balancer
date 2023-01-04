using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class WorkerProperty
    {
        public Code code;
        public int workerValue;
        public WorkerProperty(Item item)
        {
            code = item.code;
            workerValue = item.value;
        }
    }
}
