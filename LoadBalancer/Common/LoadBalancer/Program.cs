using Common;
using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class Program
    {
        public static void Conn()
        {
            ServiceHost sh = new ServiceHost(typeof(LoadBalancer));
            sh.AddServiceEndpoint(typeof(IBalancerService), new NetTcpBinding(), new Uri("net.tcp://localhost:4002/IBalancerService"));
            sh.Open();
            Console.WriteLine("Servis otvoren.");
            
            //Console.Read();
            //sh.Close();
        }
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew( () => Conn() );
            Console.Read();
            LoadBalancer lb = new LoadBalancer();
           // Task task_2 = Task.Factory.StartNew( () => lb.
        }
    }
}
