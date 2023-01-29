using Common;
using NUnit.Framework;
using Workers;
using Assert = NUnit.Framework.Assert;

namespace WorkersTest
{
    [TestFixture]
    public class WorkerTests
    {
        private Worker w;
        private Description d;

        [SetUp]
        public void SetUp()
        {
            w = new Worker();
            d = new Description(2);
        }

        [Test]
        public void PrimiDescription()
        {
            w.primiDescription(d, 1);

            Description d2 = new Description(4);
            w.primiDescription(d2, 1);


            CollectionDescription cd = w.nadjiPoDatasetu(d);
            Assert.AreEqual(d.dataSet, cd.dataSet);
            Assert.IsNotNull(cd);
            Assert.AreNotEqual(d2.dataSet, cd.dataSet);
        }

        [Test]
        public void PrimiDescriptionSaDescriptionom()
        {
            Item i = new Item(Code.CODE_ANALOG, 3);
            d.Add(i);

            w.primiDescription(d, 1);

            CollectionDescription cd = w.nadjiPoDatasetu(d);
            Assert.AreEqual(1, cd.HistoricalCollection.Count);
            Assert.IsInstanceOf<WorkerProperty>(cd.HistoricalCollection[0]);
        }

        [Test]
        public void NadjiPoDatasetu()
        {
            d.dataSet = 3;

            CollectionDescription cd = w.nadjiPoDatasetu(d);

            Assert.IsNull(cd);
        }

        /*[Test]
        public void DodavanjeViseItemaUCollection()
        {
            Item i1 = new Item(Code.CODE_ANALOG, 3);
            Item i2 = new Item(Code.CODE_DIGITAL, 12);
            d.Add(i1);
            d.Add(i2);

            w.primiDescription(d, 1);

            CollectionDescription cd = w.nadjiPoDatasetu(d);

            Assert.AreEqual(cd.HistoricalCollection[0].code, i1.code);
            Assert.AreEqual(cd.HistoricalCollection[0].workerValue, i1.value);
            Assert.AreEqual(cd.HistoricalCollection[1].code, i2.code);
            Assert.AreEqual(cd.HistoricalCollection[1].workerValue, i2.value);
        }*/

        [Test]
        public void DodavanjeUViseCollectiona()
        {
            Description dn = new Description(4);

            w.primiDescription(d, 1);
            w.primiDescription(dn, 1);

            CollectionDescription cd1 = w.nadjiPoDatasetu(d);
            Assert.AreEqual(d.dataSet, cd1.dataSet);
            Assert.IsNotNull(cd1);

            CollectionDescription cd2 = w.nadjiPoDatasetu(dn);
            Assert.IsNotNull(cd2);
            Assert.AreEqual(dn.dataSet, cd2.dataSet);
        }
    }
}