using Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers
{
    public class WorkerList : IWorkerService
    {
        public static List<Worker> workers;
        public WorkerList()
        {
            workers = new List<Worker>();
            for (int i = 0; i < 4; ++i)
            {
                workers.Add(new Worker());
            }
        }

        public int getWorkerCount()
        {
            return workers.Count();
        }

        public void primiDescNaWorkeru(int i, Description desc)
        {
            Task task = Task.Factory.StartNew(() => workers[i].primiDescription(desc, i));
        }

        public void upaliWorker()
        {
            workers.Add(new Worker());
        }

        public void ugasiWorker()
        {
            if (workers.Count() > 0)
            {
                workers.RemoveAt(workers.Count() - 1);
            }
        }

        public void TestKonekcije()
        {
            return;
        }
    }
}
