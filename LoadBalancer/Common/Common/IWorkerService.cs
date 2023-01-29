using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IWorkerService
    {
        [OperationContract]
        void primiDescNaWorkeru(int i, Description desc);
        [OperationContract]
        int getWorkerCount();
        [OperationContract]
        void upaliWorker();
        [OperationContract]
        void ugasiWorker();
        [OperationContract]
        void TestKonekcije();
    }
}
