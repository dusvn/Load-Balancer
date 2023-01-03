using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Writer
    {
        Random r;
        public void generisiIteme(IBalancerService kanal)
        {
            r = new Random();
            while (true)
            {
                int c = r.Next(0, 8);
                int v = r.Next(int.MinValue, int.MaxValue);
                Item item = new Item((Code)c, v);
                Console.WriteLine("Poslacemo Item Code: " + item.code + " Value: " + item.value);
                kanal.zapisiIteme(item);
                Thread.Sleep(2000);
            }
        }
    }
}
