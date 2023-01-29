using Common;
using NUnit.Framework;
using Workers;
using Assert = NUnit.Framework.Assert;

namespace WorkersTest
{
    [TestFixture]
    public class WorkerListTests
    {
        private WorkerList wl;

        [SetUp]
        public void SetUp()
        {
            wl = new WorkerList();
        }

        [Test]
        public void WorkerListTestsGetWorkerCount()
        {
            Assert.AreEqual(4, wl.getWorkerCount());
        }

        [Test]
        public void WorkerListPrimiDescNaWorkeru()
        {
            int workerIndex = 2;
            Description desc = new Description(1);
            Description desc1 = new Description(2);

            WorkerList.workers[workerIndex].primiDescription(desc, workerIndex);

            wl.primiDescNaWorkeru(workerIndex, desc);
            wl.primiDescNaWorkeru(workerIndex, desc1);

            var worker = WorkerList.workers[workerIndex].nadjiPoDatasetu(desc);

            Assert.AreEqual(worker.dataSet, desc.dataSet);
        }

        [Test]
        public void WorkerListUpaliWorker()
        {
            wl.upaliWorker();

            Assert.AreEqual(5, wl.getWorkerCount());
        }

        [Test]
        public void WorkerListUgasiWorker()
        {
            wl.ugasiWorker();

            Assert.AreEqual(3, wl.getWorkerCount());
        }
    }
}
