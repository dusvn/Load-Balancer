using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IBalancerService
    {
        [OperationContract]
        void ZapisiItem(Item item);

        [OperationContract]
        void TestKonekcije();

        [OperationContract]
        int UpaliWorker();
        [OperationContract]
        int UgasiWorker();
    }
}
