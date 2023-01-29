using Common;
using System;
using System.Threading;

namespace Client
{
    public class Writer
    {
        public Logger Log = new Logger(@"FILElog\writerLog.txt");
        string generacija;
        Random r;
        bool generacijaItema = false;
        public bool GeneracijaItema()
        {
            return generacijaItema;
        }
        public void generisiIteme(IBalancerService kanal)
        {
            r = new Random();
            generacijaItema = !generacijaItema;
            if (generacijaItema)
            {
                generacija = "ukljucena";
            }
            else
            {
                generacija = "iskljucena";
            }
            Console.WriteLine("Generacija itema je " + generacija);
            while (generacijaItema)
            {
                int c = r.Next(0, 8);
                int v = r.Next(1, 10000);
                Item item = new Item((Code)c, v);
                kanal.ZapisiItem(item);
                Log.WriterLog(item.code, item.value, DateTime.Now);
                Thread.Sleep(2000);
            }
        }
    }
}
