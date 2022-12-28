using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadBalanserTest
{
    public class Writer
    {
        Random r;
        public void generisiIteme()
        {
            while (true)
            {
                int c = r.Next(1,9);
                int v = r.Next(int.MinValue, int.MaxValue);
                Item item = new Item((Code)c, v);
                posaljiItem(item);
                Thread.Sleep(2000);
            }
        }
        Item posaljiItem(Item item)
        {
            return item;
        }
    }
}
