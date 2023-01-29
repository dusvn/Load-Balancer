using LoadBalancer.DB.DAO;
using LoadBalancer.DB.DAO.Impl;
using LoadBalancer.DB.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CommonTest.DB.DAO.Impl.DataSet1Test
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class DataSet2DAOimplTests
    {
        [Test]
        [TestCase(1, "CODE_LIMITED", 1)]
        [TestCase(2, "CODE_CONSUMER", 1)]
        [TestCase(3, "CODE_DIGITAL", 1)]
        [TestCase(2, "CODE_CUSTOM", 1)]
        [TestCase(1, "CODE_SINGLENODE", 1)]
        public void TestSavePodatakaDS2(int wid, string code, int wv)
        {
            Mock<DataSet1> mds1 = new Mock<DataSet1>(wid, code, wv, DateTime.Now);

            Mock<IDataSet1DAO> mock = new Mock<IDataSet1DAO>();

            mock.Setup(p => p.Save(mds1.Object as DataSet1)).Returns(1);
        }

        [Test]
        [TestCase()]
        public void BrisanjeSvegaNemaRedovaUBazi()
        {
            Mock<IDataSet1DAO> mock = new Mock<IDataSet1DAO>();

            mock.Setup(p => p.DeleteAll()).Returns(-1); // nema redova u bazi
        }

        [Test]
        [TestCase(1, "CODE_LIMITED", 1)]
        [TestCase(2, "CODE_CONSUMER", 1)]
        [TestCase(3, "CODE_DIGITAL", 1)]
        [TestCase(2, "CODE_CUSTOM", 1)]
        [TestCase(1, "CODE_SINGLENODE", 1)]
        public void BrisanjePodataka1RedUBazi(int wid, string code, int wv)
        {
            DataSet1 ds1 = new DataSet1(wid, code, wv, DateTime.Now);

            Mock<IDataSet1DAO> mock = new Mock<IDataSet1DAO>();

            mock.Setup(p => p.Save(ds1)).Returns(1);
            mock.Setup(p => p.DeleteAll()).Returns(1);
        }

        [Test]
        [TestCase(1, "CODE_LIMITED", 1)]
        [TestCase(2, "CODE_CONSUMER", 1)]
        [TestCase(2, "CODE_DIGITAL", 1)]
        [TestCase(2, "CODE_CUSTOM", 1)]
        [TestCase(1, "CODE_SINGLENODE", 1)]
        public void BrisanjePodataka2RedaUBazi(int wid, string code, int wv)
        {
            DataSet1 ds1 = new DataSet1(wid, code, wv, DateTime.Now);
            DataSet1 ds12 = new DataSet1(wid + 1, code, wv + 1, DateTime.Now);

            Mock<IDataSet1DAO> mock = new Mock<IDataSet1DAO>();

            mock.Setup(p => p.Save(ds1)).Returns(1);
            mock.Setup(p => p.Save(ds12)).Returns(1);
            mock.Setup(p => p.DeleteAll()).Returns(2);
        }

        // druge test metode
        [Test]
        public void FindAllSaveDeleteAll()
        {

            int wid = 1;
            string code = "code1";
            DateTime timeFrom = new DateTime(2020, 1, 1);
            DateTime timeTo = new DateTime(2020, 12, 31);
            List<DataSet1> expectedList = new List<DataSet1>()
        {
            new DataSet1(wid, code, 1, new DateTime(2020, 1, 1)),
            new DataSet1(wid, code, 2, new DateTime(2020, 2, 1)),
            new DataSet1(wid, code, 3, new DateTime(2020, 3, 1))
        };

            DataSet1 ds1 = new DataSet1(wid, code, 1, new DateTime(2020, 1, 1));
            DataSet1 ds2 = new DataSet1(wid, code, 2, new DateTime(2020, 2, 1));
            DataSet1 ds3 = new DataSet1(wid, code, 3, new DateTime(2020, 3, 1));

            DataSet1DAOimpl d = new DataSet1DAOimpl();
            d.DeleteAll();

            d.Save(ds3);
            d.Save(ds1);
            d.Save(ds2);

            var actualList = d.FindAll(wid, code, timeFrom, timeTo).ToList();

            Assert.AreEqual(false, actualList[0].Equals(expectedList[1]));
            Assert.AreEqual(false, actualList[1].Equals(expectedList[2]));
            Assert.AreEqual(false, actualList[2].Equals(expectedList[0]));
            Assert.AreEqual(3, actualList.Count());
        }

        [Test]
        public void FindAllDeleteAll()
        {
            int wid = 1;
            string code = "code1";
            DateTime timeFrom = new DateTime(2020, 1, 1);
            DateTime timeTo = new DateTime(2020, 12, 31);
            List<DataSet1> expectedList = new List<DataSet1>();

            DataSet2DAOimpl d = new DataSet2DAOimpl();
            d.DeleteAll();

            var actualList = d.FindAll(wid, code, timeFrom, timeTo).ToList();

            Assert.IsEmpty(actualList);
        }

        [Test]
        public void FindCodes()
        {
            int wid = 1;
            string code = "code1";
            DateTime timeFrom = new DateTime(2020, 1, 1);
            DateTime timeTo = new DateTime(2020, 12, 31);
            List<DataSet1> expectedList = new List<DataSet1>()
        {
            new DataSet1(wid, code, 1, new DateTime(2020, 1, 1)),
            new DataSet1(wid, code, 2, new DateTime(2020, 2, 1)),
            new DataSet1(wid, code, 3, new DateTime(2020, 3, 1)),
            new DataSet1(wid, "code2", 4, new DateTime(2020, 4, 1))
        };

            DataSet1 ds1 = new DataSet1(wid, code, 1, new DateTime(2020, 1, 1));
            DataSet1 ds2 = new DataSet1(wid, code, 2, new DateTime(2020, 2, 1));
            DataSet1 ds3 = new DataSet1(wid, code, 3, new DateTime(2020, 3, 1));

            DataSet1DAOimpl d = new DataSet1DAOimpl();
            d.DeleteAll();

            d.Save(ds3);
            d.Save(ds1);
            d.Save(ds2);

            var actualList = d.FindCodes(code).ToList();

            Assert.AreEqual(3, actualList.Count());
            Assert.AreEqual(false, actualList[0].Equals(expectedList[1]));
            Assert.AreEqual(false, actualList[1].Equals(expectedList[2]));
            Assert.AreEqual(false, actualList[2].Equals(expectedList[0]));
        }
    }
}
