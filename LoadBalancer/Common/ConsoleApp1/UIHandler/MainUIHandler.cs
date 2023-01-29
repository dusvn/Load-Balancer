using Client;
using Common;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1.UIHandler
{
    public class MainUIHandler
    {
        public void handleMainMenu(IBalancerService kanal, Writer w)
        {
            string unos;
            Console.WriteLine("Trenutan broj workera je 4");
            do
            {
                Console.WriteLine("Odaberite radnju na Klijentskoj strani: ");
                Console.WriteLine("1 - Pokreni / Zaustavi automatsko generisanje i slanje Itema");
                Console.WriteLine("2 - Upali 1 worker");
                Console.WriteLine("3 - Ugasi 1 worker");
                Console.WriteLine("X - Izlaz iz programa");

                unos = Console.ReadLine();
                switch (unos)
                {
                    case "1":
                        Task task = Task.Factory.StartNew(() => w.generisiIteme(kanal));
                        string generacija;
                        if (w.GeneracijaItema())
                        {
                            generacija = "ukljucena";
                        }
                        else
                        {
                            generacija = "iskljucena";
                        }
                        //Console.WriteLine("Generacija itema je " + generacija);
                        break;
                    case "2":
                        Console.WriteLine("Trenutan broj workera je " + kanal.UpaliWorker());
                        break;
                    case "3":
                        Console.WriteLine("Trenutan broj workera je " + kanal.UgasiWorker());
                        break;
                }
            } while (!unos.ToUpper().Equals("X"));
        }
    }
}
