using Common;
using Common.DB.Model;
using Common.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LoadBalancer
{
    public class LoadBalancerC : IBalancerService
    {
        private Logger Log = new Logger(@"FILElog\loadBalancerLog.txt");
        public static IWorkerService servis { get; set; }
        public static List<Description> DescriptionList;
        private static readonly DBLBService db = new DBLBService();
        public Description DobaviDesctription()
        {
            Description desc = null;
            int najCount = 0;
            foreach (Description d in DescriptionList)
            {
                int trenCount = d.itemList.Count();
                if ((trenCount != 0) && (trenCount > najCount))
                {
                    najCount = trenCount;
                    desc = d;
                }
            }
            return desc;
        }
        public LoadBalancerC()
        {
            DescriptionList = new List<Description>();
            for (int i = 0; i < 4; i++)
            {
                DescriptionList.Add(new Description(i + 1));
            }
        }
        public void ZapisiItem(Item item)
        {
            Log.LBReciveLog(item.code, item.value, DateTime.Now);
            int ds = OdrediDataset(item);
            SmestiUListu(item, ds);
            ItemLB idb = new ItemLB(item.code.ToString(), item.value);
            db.Save(idb);

        }
        public int OdrediDataset(Item item)
        {
            if (item.code == Code.CODE_ANALOG || item.code == Code.CODE_DIGITAL)
            {
                return 1;
            }
            else if (item.code == Code.CODE_CUSTOM || item.code == Code.CODE_LIMITSET)
            {
                return 2;
            }
            else if (item.code == Code.CODE_SINGLENODE || item.code == Code.CODE_MULTIPLENODE)
            {
                return 3;
            }
            else if (item.code == Code.CODE_CONSUMER || item.code == Code.CODE_SOURCE)
            {
                return 4;
            }
            return -1;
        }
        public void SmestiUListu(Item item, int ds)
        {
            foreach (Description d in DescriptionList)
            {
                if (ds == d.dataSet)
                {
                    d.itemList.Add(item);
                    Console.WriteLine("Item " + item.ToString() + " je dodat u description " + d.ToString());
                    break;
                }

            }
        }
        public void SaljiDescriptione(IWorkerService kanal)
        {
            while (true)
            {
                for (int i = 0; i < kanal.getWorkerCount(); i++)
                {
                    Description d = DobaviDesctription();
                    if (d != null)
                    {
                        foreach (Item it in d.itemList)
                        {
                            Log.LBSendLog(it.code, it.value, DateTime.Now, i);
                            db.Remove(it.code.ToString(), it.value);
                        }
                        kanal.primiDescNaWorkeru(i, d);
                        Console.WriteLine("Pozvana metoda da se posalje na Workera " + d.ToString());
                        d.itemList.Clear();
                    }
                    Thread.Sleep(5000);
                }
            }
        }

        public void TestKonekcije()
        {
            return;
        }

        public int UpaliWorker()
        {
            servis.upaliWorker();
            return servis.getWorkerCount();
        }

        public int UgasiWorker()
        {
            servis.ugasiWorker();
            return servis.getWorkerCount();
        }
    }
}
