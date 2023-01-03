using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public static IBalancerService CreateChannel(string address)
        {
            try
            {
                ChannelFactory<IBalancerService> cf = new ChannelFactory<IBalancerService>(new NetTcpBinding(), new EndpointAddress(address));
                IBalancerService kanal = cf.CreateChannel();
                return kanal;
            }
            catch
            {
                throw new AddressAccessDeniedException("Neuspesna konekcija na server.");
            }
        }
        static void Main(string[] args)
        {
            Writer w = new Writer();
            IBalancerService kanal = CreateChannel("net.tcp://localhost:4002/IBalancerService");
            w.generisiIteme(kanal);
        }
    }
}
