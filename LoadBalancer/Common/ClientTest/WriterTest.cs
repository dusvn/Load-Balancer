using Client;
using LoadBalancer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace ClientTest
{
    [TestFixture]
    public class WriterTest
    {
        private Random r;
        private bool generacijaItema;

        [SetUp]
        public void SetUp()
        {
            r = new Random();
            generacijaItema = false;
        }

        [Test]
        public void GeneracijaItema()
        {
            Assert.IsFalse(generacijaItema);
        }

        /*[Test]
        public void TestGenerisiIteme()
        {
            LoadBalancerC lb = new LoadBalancerC();
            Writer w = new Writer();

            w.generisiIteme(lb);

            Assert.IsNotEmpty(LoadBalancerC.DescriptionList);
        }*/
    }
}
