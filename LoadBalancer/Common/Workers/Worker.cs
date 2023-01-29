using Common;
using LoadBalancer.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Workers
{
    public class Worker
    {
        private Logger Log = new Logger(@"FILElog\workerLog.txt");
        List<CollectionDescription> listaCD;
        private static readonly DBService db = new DBService();
        public Worker()
        {
            listaCD = new List<CollectionDescription>();
        }
        public void primiDescription(Description desc, int wid)
        {
            CollectionDescription cd = nadjiPoDatasetu(desc);
            if (cd == null)
            {
                CollectionDescription noviCD = new CollectionDescription();
                noviCD.dataSet = desc.dataSet;
                listaCD.Add(noviCD);
                cd = noviCD;
            }

            foreach(Item i in desc.itemList)
            {
                Log.WorkerReciveLog(wid, i.code, i.value, DateTime.Now);
            }

            foreach (Item item in desc.itemList)
            {
                WorkerProperty wp = new WorkerProperty(item);
                if (cd.HistoricalCollection.Count == 0 || cd.HistoricalCollection.First().code == wp.code)
                {
                    cd.HistoricalCollection.Add(wp);
                }
                else if (cd.HistoricalCollection.First().code != wp.code)
                {
                    WorkerProperty wp2 = cd.HistoricalCollection.First();
                    cd.HistoricalCollection.RemoveAt(0);
                    CollectionDescription noviCd = new CollectionDescription();
                    noviCd.HistoricalCollection.Add(wp);
                    noviCd.HistoricalCollection.Add(wp2);
                    noviCd.dataSet = desc.dataSet;
                    db.Add(noviCd, wid);
                    Log.WorkerSaveLog(wid, wp.code, wp.workerValue, DateTime.Now);
                    Log.WorkerSaveLog(wid, wp2.code, wp2.workerValue, DateTime.Now);
                }

            }
        }
        public CollectionDescription nadjiPoDatasetu(Description desc)
        {
            CollectionDescription ret = null;
            foreach (CollectionDescription cd in listaCD)
            {
                if (cd.dataSet == desc.dataSet)
                {
                    ret = cd;
                    break;
                }
            }
            return ret;
        }
    }
}
