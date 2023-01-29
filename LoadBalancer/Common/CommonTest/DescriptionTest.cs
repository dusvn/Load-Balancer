using Common;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace CommonTest
{
    [TestFixture]
    class DescriptionTest
    {
        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void DescriptionKonstruktorDobriParametri(int ds)
        {
            Description.count = 0;

            Description d = new Description(ds);

            Assert.AreEqual(d.id, Description.count);
            Assert.AreEqual(d.dataSet, ds);
            Assert.AreEqual(1, Description.count);
            Assert.IsNotNull(d.itemList);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        public void DescriptionKonstruktorGranicniParametri(int ds)
        {
            Description.count = 0;

            Description d = new Description(ds);

            Assert.AreEqual(d.id, Description.count);
            Assert.AreEqual(d.dataSet, ds);
            Assert.AreEqual(1, Description.count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(-18)]
        public void DescriptionKonstruktorLosiParametri(int ds)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Description d = new Description(ds);
                }
                );
        }

        [Test]
        public void AddTest()
        {
            Item i = new Item(Code.CODE_ANALOG, 3);
            Description d = new Description(2);

            d.Add(i);

            i.ToString();

            Assert.IsNotNull(d.itemList);
        }
    }
}
