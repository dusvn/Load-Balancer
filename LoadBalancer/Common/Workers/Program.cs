using Common;
using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.Threading.Tasks;
using Workers.UIHandler;

namespace Workers
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        private static readonly MainUIHandler mainUIHandler = new MainUIHandler();
        public static void Conn()
        {
            ServiceHost sh = new ServiceHost(typeof(WorkerList));
            sh.AddServiceEndpoint(typeof(IWorkerService), new NetTcpBinding(), new Uri("net.tcp://localhost:4001/IWorkerService"));
            sh.Open();
            Console.WriteLine("Servis otvoren.");

            //Console.Read();
            //sh.Close();
        }
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(() => Conn());
            WorkerList wl = new WorkerList();
            mainUIHandler.handleMainMenu(wl);
        }
    }
}
