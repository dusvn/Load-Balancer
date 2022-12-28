using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalanserTest
{
    public class LoadBalancer
    {
        private List<Description> DescriptionList;
        void primiIteme(Item item)
        {
            int ds=1;
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
            foreach(Description d in DescriptionList)
            {
                if (ds == d.dataSet) d.ItemList.Add(item);
            }
        }
    }
}
