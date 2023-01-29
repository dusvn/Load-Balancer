using Common;
using ConsoleApp1.UIHandler;
using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;

namespace Client
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        private static readonly MainUIHandler mainUIHandler = new MainUIHandler();
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
            IBalancerService kanal = null;
            Console.WriteLine("Pokusavam da se konektujem na Load Balancer.");
            while (true)
            {
                try
                {
                    kanal = CreateChannel("net.tcp://localhost:4002/IBalancerService");
                    kanal.TestKonekcije();
                    break;
                }
                catch (EndpointNotFoundException e)
                {

                }
            }
            mainUIHandler.handleMainMenu(kanal, w);
            w.Log.GasenjeLog(DateTime.Now);
        }
    }
}
