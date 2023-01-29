using Common;
using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.Threading.Tasks;

namespace LoadBalancer
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        public static void Conn()
        {
            ServiceHost sh = new ServiceHost(typeof(LoadBalancerC));
            sh.AddServiceEndpoint(typeof(IBalancerService), new NetTcpBinding(), new Uri("net.tcp://localhost:4002/IBalancerService"));
            sh.Open();
            Console.WriteLine("Servis otvoren.");

            //Console.Read();
            //sh.Close();
        }
        public static IWorkerService CreateChannel(string address)
        {
            try
            {
                ChannelFactory<IWorkerService> cf = new ChannelFactory<IWorkerService>(new NetTcpBinding(), new EndpointAddress(address));
                IWorkerService kanal = cf.CreateChannel();
                return kanal;
            }
            catch
            {
                throw new AddressAccessDeniedException("Neuspesna konekcija na server.");
            }
        }
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(() => Conn());
            IWorkerService kanal = null;
            Console.WriteLine("Pokusavam da se konektujem na Workere.");
            while (true)
            {
                try
                {
                    kanal = CreateChannel("net.tcp://localhost:4001/IWorkerService");
                    kanal.TestKonekcije();
                    break;
                }
                catch (EndpointNotFoundException e)
                {

                }
            }
            Console.WriteLine("Konekcija uspela.");
            LoadBalancerC lb = new LoadBalancerC();
            LoadBalancerC.servis = kanal;
            lb.SaljiDescriptione(kanal);
            Console.Read();

        }
    }
}
