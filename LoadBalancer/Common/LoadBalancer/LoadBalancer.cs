using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Configuration;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class LoadBalancer : IBalancerService
    {
        Description one;
        Description two;
        Description three;
        Description four;
        public ListDescription descriptionList; // da li treba private ? 
        public static List<Worker> workers;
        public LoadBalancer()
        {
        
            One = new Description(1);
            Two = new Description(2);
            Three = new Description(3);
            Four = new Description(4);

            workers = new List<Worker>();
            workers.Add(new Worker());
            descriptionList = new ListDescription(new List<Description>() {
                One, Two, Three, Four
            }
        );

        }



        public Description One { get => one; set => one = value; }
        public Description Two { get => two; set => two = value; }
        public Description Three { get => three; set => three = value; }
        public Description Four { get => four; set => four = value; }
       
        public void zapisiIteme(Item item)
        {
            Console.WriteLine("Primljen je item Code: " + item.code + " Value: " + item.value);
            int ds = odrediDataset(item);
            smestiUListu(item,ds);
        }
        
        public int odrediDataset(Item item) // treba da nam odredi koji je dataset u pitanju 
        {
            if (item.code == Code.CODE_ANALOG || item.code == Code.CODE_DIGITAL)
                return 1;
            else if (item.code == Code.CODE_CUSTOM || item.code == Code.CODE_LIMITSET)
                return 2;
            else if (item.code == Code.CODE_SINGLENODE || item.code == Code.CODE_MULTIPLENODE)
                return 3;
            else if (item.code == Code.CODE_SOURCE || item.code == Code.CODE_CONSUMER)
                return 4;
            else
                return -1; // ako je podudlao karsona 
        }
       
        void smestiUListu(Item item, int ds)
        {

            foreach (Description d in descriptionList.List)
            {
                if (ds == d.dataSet) d.ItemList.Add(item);
            }
        }


        // drugi parametar je zbog radvajanja 
        public void Export(string file, string txt)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(file, true);
                sw.Write(txt + "\n");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try { sw.Close(); } catch (Exception e) { Console.WriteLine(e.Message); }

            }
        }


        public void save_local(Item item)
        {
            Console.WriteLine("Code: " + item.code + " Value: " + item.value);

                foreach(Description d in descriptionList.List)
                {
                    Console.WriteLine("Saving...\n");
                    if (odrediDataset(item) == 1)
                    {
                        d.ItemList.Add(item);
                        Export("../../../../first_local_save.txt", item.ToString());

                    }
                    else if (odrediDataset(item) == 2)
                    {
                        d.ItemList.Add(item);
                        Export("../../../../first_local_save.txt", item.ToString());

                    }
                    else if (odrediDataset(item) == 3)
                    {
                        d.ItemList.Add(item);
                        Export("../../../../first_local_save.txt", item.ToString());

                    }
                    else if (odrediDataset(item) == 4)
                    {
                        d.ItemList.Add(item);
                        Export("../../../../first_local_save.txt", item.ToString());
                    }

                }
            
        }


    }
}
