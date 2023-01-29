using Common;
using LoadBalancer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace LoadBalancerTest
{
    [TestFixture]
    public class LoadBalancerCTests
    {
        private LoadBalancerC lb;

        [SetUp]
        public void Setup()
        {
            lb = new LoadBalancerC();
        }

        [Test]
        public void LoadBalancerCKonstruktor()
        {
            Assert.AreEqual(4, LoadBalancerC.DescriptionList.Count);
        }

        [Test]
        public void OdrediDataset()
        {
            Item i1 = new Item(Code.CODE_ANALOG, 1);
            Item i2 = new Item(Code.CODE_DIGITAL, 2);
            Item i3 = new Item(Code.CODE_CUSTOM, 3);
            Item i4 = new Item(Code.CODE_LIMITSET, 4);
            Item i5 = new Item(Code.CODE_SINGLENODE, 5);
            Item i6 = new Item(Code.CODE_MULTIPLENODE, 6);
            Item i7 = new Item(Code.CODE_SOURCE, 7);
            Item i8 = new Item(Code.CODE_CONSUMER, 8);

            Assert.AreEqual(1, lb.OdrediDataset(i1));
            Assert.AreEqual(1, lb.OdrediDataset(i2));
            Assert.AreEqual(2, lb.OdrediDataset(i3));
            Assert.AreEqual(2, lb.OdrediDataset(i4));
            Assert.AreEqual(3, lb.OdrediDataset(i5));
            Assert.AreEqual(3, lb.OdrediDataset(i6));
            Assert.AreEqual(4, lb.OdrediDataset(i7));
            Assert.AreEqual(4, lb.OdrediDataset(i8));

            Assert.AreNotEqual(2, lb.OdrediDataset(i1));
            Assert.AreNotEqual(3, lb.OdrediDataset(i2));
            Assert.AreNotEqual(4, lb.OdrediDataset(i3));
            Assert.AreNotEqual(1, lb.OdrediDataset(i4));
            Assert.AreNotEqual(2, lb.OdrediDataset(i5));
            Assert.AreNotEqual(4, lb.OdrediDataset(i6));
            Assert.AreNotEqual(3, lb.OdrediDataset(i7));
            Assert.AreNotEqual(1, lb.OdrediDataset(i8));
        }

        [Test]
        public void SmestiUListu()
        {
            Item i = new Item(Code.CODE_ANALOG, 1);
            Description d = new Description(1);
            LoadBalancerC.DescriptionList = new List<Description> { d };

            lb.SmestiUListu(i, d.dataSet);

            Assert.IsTrue(LoadBalancerC.DescriptionList[0].itemList.Contains(i));
        }

        [Test]
        public void SmestiUListuNull()
        {
            Item i = null;
            Description d = new Description(1);
            LoadBalancerC.DescriptionList = new List<Description> { d };

            Assert.Throws<NullReferenceException>(
                () =>
                {
                    lb.SmestiUListu(i, d.dataSet);
                }
                );
        }

        [Test]
        public void Najpopunjeniji()
        {
            Description d1 = new Description(1);
            Item i1 = new Item(Code.CODE_ANALOG, 1);
            Item i2 = new Item(Code.CODE_DIGITAL, 2);
            Item i3 = new Item(Code.CODE_ANALOG, 3);
            d1.itemList.Add(i1);
            d1.itemList.Add(i2);
            d1.itemList.Add(i3);

            Description d2 = new Description(2);
            Item i5 = new Item(Code.CODE_CUSTOM, 3);
            Item i4 = new Item(Code.CODE_LIMITSET, 4);
            d2.itemList.Add(i4);
            d2.itemList.Add(i5);

            Description d3 = new Description(3);

            LoadBalancerC.DescriptionList = new List<Description> { d1, d2, d3 };

            Assert.AreEqual(d1, lb.DobaviDesctription());
            Assert.AreNotEqual(d2, lb.DobaviDesctription());
            Assert.AreNotEqual(d3, lb.DobaviDesctription());
        }

        [Test]
        public void ZapisiIteme()
        {
            Description d = new Description(1);
            LoadBalancerC.DescriptionList = new List<Description> { d };
            Item i = new Item(Code.CODE_ANALOG, 1);

            lb.ZapisiItem(i);

            Assert.AreEqual(1, d.itemList.Count);
            Assert.AreEqual(i, d.itemList[0]);
        }

        /*[Test]
        public void TestKonekcije()
        {
            TestKonekcije();

            Assert.Pass();
        }*/

        /*[Test]
        public void UpaliWorker()
        {
            //int a = lb.UpaliWorker();
            //Console.WriteLine(a);

            //LoadBalancerC.servis.upaliWorker();
            Assert.IsNotNull(LoadBalancerC.servis.upaliWorker());
        }*/
    }
}
