using Common;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CommonTest
{
    [TestFixture]
    public class CollectionDescriptionTest
    {
        /*[Test]
        public void CollectionDescriptionKonstruktorID()
        {

            CollectionDescription collection = new CollectionDescription();

            Assert.AreEqual(1, collection.Count);
        }*/

        [Test]
        public void CollectionDescriptionKonstruktorHistoricalCollection()
        {
            CollectionDescription collection = new CollectionDescription();

            Assert.IsNotNull(collection.HistoricalCollection);
        }

        [Test]
        public void CollectionDescriptionKonstruktorDataSet()
        {
            CollectionDescription collection = new CollectionDescription();

            Assert.AreEqual(-1, collection.dataSet);
        }

        [Test]
        public void CollectionDescriptionProveraInkrementa()
        {
            CollectionDescription collection1 = new CollectionDescription();
            CollectionDescription collection2 = new CollectionDescription();

            Assert.AreEqual(collection2.Count, collection2.id);
        }

        [Test]
        public void CollectionDescriptionJedinstveniId()
        {
            CollectionDescription collection1 = new CollectionDescription();
            CollectionDescription collection2 = new CollectionDescription();
            CollectionDescription collection3 = new CollectionDescription();

            Assert.AreNotEqual(collection1.id, collection2.id);
            Assert.AreNotEqual(collection1.id, collection3.id);
            Assert.AreNotEqual(collection2.id, collection3.id);
        }

        [Test]
        public void CollectionDescriptionHistoricalCollectionDodavanjeItema()
        {
            Item i = new Item(Code.CODE_ANALOG, 3);

            CollectionDescription collection = new CollectionDescription();
            WorkerProperty worker = new WorkerProperty(i);
            collection.HistoricalCollection.Add(worker);

            Assert.IsNotEmpty(collection.HistoricalCollection);
        }
        [Test]
        public void CollectionDescriptionHistoricalCollectionBrisanjeItema()
        {
            Item i = new Item(Code.CODE_ANALOG, 3);

            CollectionDescription collection = new CollectionDescription();
            WorkerProperty worker = new WorkerProperty(i);

            WorkerProperty wdummy = new WorkerProperty(Code.CODE_SOURCE, 2);

            Item.GetFormattedHeader();
            i.ToString();

            collection.HistoricalCollection.Add(worker);
            collection.HistoricalCollection.Remove(worker);

            Assert.IsEmpty(collection.HistoricalCollection);
        }
    }

}
