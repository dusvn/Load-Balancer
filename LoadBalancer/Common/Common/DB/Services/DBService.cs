using Common;
using LoadBalancer.DB.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace LoadBalancer.DB.Services
{
    [ExcludeFromCodeCoverage]
    public class DBService
    {

        private static readonly DataSet1Service db1 = new DataSet1Service();
        private static readonly DataSet2Service db2 = new DataSet2Service();
        private static readonly DataSet3Service db3 = new DataSet3Service();
        private static readonly DataSet4Service db4 = new DataSet4Service();
        //dodavanje entiteta u bazu
        public void Add(CollectionDescription cd, int wid)
        {
            if (cd.HistoricalCollection == null)
            {
                throw new ArgumentNullException("Collection Description nije inicijalizovan.");
            }

            switch (cd.dataSet)
            {
                case 1:
                    foreach (WorkerProperty wp in cd.HistoricalCollection)
                    {
                        if (wp.code == Code.CODE_DIGITAL)
                        {
                            string c = wp.code.ToString();
                            try
                            {
                                db1.SaveDataSet(new DataSet1(wid, c, wp.workerValue, DateTime.Now));
                            }
                            catch (DbException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            //fali log upis
                            continue;
                        }

                        bool deadband = false;
                        List<DataSet1> dsList = db1.FindCodes(wp.code.ToString());
                        foreach (DataSet1 ds in dsList)
                        {
                            if (Math.Abs(ds.Value - wp.workerValue) < ds.Value * 0.02)
                            {
                                deadband = true;
                                break;
                            }
                        }

                        if (!deadband)
                        {
                            string c = wp.code.ToString();
                            try
                            {
                                db1.SaveDataSet(new DataSet1(wid, c, wp.workerValue, DateTime.Now));
                            }
                            catch (DbException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            //fali log upis
                        }
                    }
                    break;
                case 2:
                    foreach (WorkerProperty wp in cd.HistoricalCollection)
                    {
                        bool deadband = false;
                        List<DataSet2> dsList = db2.FindCodes(wp.code.ToString());
                        foreach (DataSet2 ds in dsList)
                        {
                            if (Math.Abs(ds.Value - wp.workerValue) < ds.Value * 0.02)
                            {
                                deadband = true;
                                break;
                            }
                        }

                        if (!deadband)
                        {
                            string c = wp.code.ToString();
                            try
                            {
                                db2.SaveDataSet(new DataSet2(wid, c, wp.workerValue, DateTime.Now));
                            }
                            catch (DbException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            //fali log upis
                        }
                    }
                    break;
                case 3:
                    foreach (WorkerProperty wp in cd.HistoricalCollection)
                    {
                        bool deadband = false;
                        List<DataSet3> dsList = db3.FindCodes(wp.code.ToString());
                        foreach (DataSet3 ds in dsList)
                        {
                            if (Math.Abs(ds.Value - wp.workerValue) < ds.Value * 0.02)
                            {
                                deadband = true;
                                break;
                            }
                        }

                        if (!deadband)
                        {
                            string c = wp.code.ToString();
                            try
                            {
                                db3.SaveDataSet(new DataSet3(wid, c, wp.workerValue, DateTime.Now));
                            }
                            catch (DbException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            //fali log upis
                        }
                    }
                    break;
                case 4:
                    foreach (WorkerProperty wp in cd.HistoricalCollection)
                    {
                        bool deadband = false;
                        List<DataSet4> dsList = db4.FindCodes(wp.code.ToString());
                        foreach (DataSet4 ds in dsList)
                        {
                            if (Math.Abs(ds.Value - wp.workerValue) < ds.Value * 0.02)
                            {
                                deadband = true;
                                break;
                            }
                        }

                        if (!deadband)
                        {
                            string c = wp.code.ToString();
                            try
                            {
                                db4.SaveDataSet(new DataSet4(wid, c, wp.workerValue, DateTime.Now));
                            }
                            catch (DbException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            //fali log upis
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public List<WorkerProperty> GetItems(int wid, Code code, DateTime from, DateTime to)
        {
            List<WorkerProperty> ret = new List<WorkerProperty>();
            string c;
            if (code == Code.CODE_ANALOG || code == Code.CODE_DIGITAL)
            {
                c = code.ToString();
                List<DataSet1> dsList = db1.FindAll(wid, c, from, to);
                foreach (DataSet1 ds in dsList)
                {
                    Code cc;
                    Code.TryParse(ds.Code, out cc);
                    ret.Add(new WorkerProperty(cc, ds.Value));
                }
            }
            else if (code == Code.CODE_CUSTOM || code == Code.CODE_LIMITSET)
            {
                c = code.ToString();
                List<DataSet2> dsList = db2.FindAll(wid, c, from, to);
                foreach (DataSet2 ds in dsList)
                {
                    Code cc;
                    Code.TryParse(ds.Code, out cc);
                    ret.Add(new WorkerProperty(cc, ds.Value));
                }
            }
            else if (code == Code.CODE_SINGLENODE || code == Code.CODE_MULTIPLENODE)
            {
                c = code.ToString();
                List<DataSet3> dsList = db3.FindAll(wid, c, from, to);
                foreach (DataSet3 ds in dsList)
                {
                    Code cc;
                    Code.TryParse(ds.Code, out cc);
                    ret.Add(new WorkerProperty(cc, ds.Value));
                }
            }
            else if (code == Code.CODE_CONSUMER || code == Code.CODE_SOURCE)
            {
                c = code.ToString();
                List<DataSet4> dsList = db4.FindAll(wid, c, from, to);
                foreach (DataSet4 ds in dsList)
                {
                    Code cc;
                    Code.TryParse(ds.Code, out cc);
                    ret.Add(new WorkerProperty(cc, ds.Value));
                }
            }
            //logovanje fali
            return ret;
        }

        //brisanje svih entiteta
        public void DeleteAll()
        {
            db1.DeleteAll();
            db2.DeleteAll();
            db3.DeleteAll();
            db4.DeleteAll();
        }
    }
}
