using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common
{
    [KnownType(typeof(List<Item>))]
    [DataContract]
    public class Description
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public List<Item> itemList { get; set; }
        [DataMember]
        public int dataSet { get; set; }
        public static uint count = 0;


        public Description(int ds)
        {
            if (ds < 1 || ds > 4)
            {
                throw new ArgumentException("Argument ne sme biti veci od 4 ili manji od 1");
            }
            else
            {
                id = ++count;
                itemList = new List<Item>();
                dataSet = ds;
            }
        }

        public void Add(Item item)
        {
            itemList.Add(item);
        }

        public override string ToString()
        {
            string ispis = "\n";
            foreach (Item i in itemList)
            {
                ispis += i.ToString() + '\n';
            }
            return ispis;
        }
    }
}
