using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class LoadBalancer : IBalancerService
    {
        private List<Description> DescriptionList;
        private static List<Worker> workers;
        public LoadBalancer()
        {
            DescriptionList = new List<Description>();
            for(int i=0; i<4; i++)
            {
                DescriptionList.Add(new Description(i+1));
            }
        }
        public void zapisiIteme(Item item)
        {
            Console.WriteLine("Primljen je item Code: " + item.code + " Value: " + item.value);
            int ds = 1;
            odrediDataset(item, ds);
            smestiUListu(item, ds);
        }
        void odrediDataset(Item item, int ds)
        {
            if (item.code == Code.CODE_ANALOG || item.code == Code.CODE_DIGITAL)
                ds = 1;
            else if (item.code == Code.CODE_CUSTOM || item.code == Code.CODE_LIMITSET)
                ds = 2;
            else if (item.code == Code.CODE_SINGLENODE || item.code == Code.CODE_MULTIPLENODE)
                ds = 3;
            else if (item.code == Code.CODE_SOURCE || item.code == Code.CODE_CONSUMER)
                ds = 4;
        }
        void smestiUListu(Item item, int ds)
        {
            foreach (Description d in DescriptionList)
            {
                if (ds == d.dataSet) d.ItemList.Add(item);
            }
        }
        void saljiDescriptione()
        {
            while (true)
            {
                for(int i = 0; i < brWorkera; i++)
                {
                    workers[i].primiDescription(DescriptionList[0]);
                    DescriptionList[0].ItemList.Clear();

                    Thread.Sleep(5000);
                }
            }
        }
    }
}
