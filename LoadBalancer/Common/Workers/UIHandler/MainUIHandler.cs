using Common;
using LoadBalancer.DB.Services;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Workers.UIHandler
{
    [ExcludeFromCodeCoverage]
    public class MainUIHandler
    {
        private static readonly DBService db = new DBService();
        public void handleMainMenu(WorkerList wl)
        {
            string unos;
            do
            {
                Console.WriteLine("Odaberite Reader radnju za Workere: ");
                Console.WriteLine("1 - Ispis Itema po intervalu od Workera");
                Console.WriteLine("X - Izlaz iz programa");
                unos = Console.ReadLine();
                Logger ReadLog = new Logger(@"FILElog\readerLog.txt");
                int code;
                int workerid;
                DateTime pocetni;
                DateTime krajnji;
                bool uspesanUnos;
                switch (unos)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Unesite koji kod zelite da pretrazujete: ");
                            Console.WriteLine("1 - CODE_ANALOG");
                            Console.WriteLine("2 - CODE_DIGITAL");
                            Console.WriteLine("3 - CODE_CUSTOM");
                            Console.WriteLine("4 - CODE_LIMITSET");
                            Console.WriteLine("5 - CODE_SINGLENODE");
                            Console.WriteLine("6 - CODE_MULTIPLENODE");
                            Console.WriteLine("7 - CODE_CONSUMER");
                            Console.WriteLine("8 - CODE_SOURCE");
                            uspesanUnos = int.TryParse(Console.ReadLine(), out code);
                        } while (!uspesanUnos || (code > 8 || code < 1));
                        do
                        {
                            Console.WriteLine("Unesite redni broj Workera (0 - " + wl.getWorkerCount() + "):");
                            uspesanUnos = int.TryParse(Console.ReadLine(), out workerid);
                        } while (!uspesanUnos || (workerid > wl.getWorkerCount() || workerid < 0));
                        do
                        {
                            Console.WriteLine("Unesite datum ODAKLE cete da ispisujete podatke [format -> 2023-01-22 14:10:32]: ");
                            uspesanUnos = DateTime.TryParse(Console.ReadLine(), out pocetni);
                        } while (!uspesanUnos);
                        do
                        {
                            Console.WriteLine("Unesite datum DOKLE cete da ispisujete podatke [format -> 2023-01-22 14:10:32]: ");
                            uspesanUnos = DateTime.TryParse(Console.ReadLine(), out krajnji);
                        } while (!uspesanUnos);
                        try
                        {
                            Console.WriteLine(Item.GetFormattedHeader());
                            foreach (WorkerProperty wp in db.GetItems(workerid, (Code)(code - 1), pocetni, krajnji))
                            {
                                Console.WriteLine(wp.ToString());
                            }
                            ReadLog.ReadLog(pocetni, krajnji, DateTime.Now, workerid, (Code)(code - 1));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            } while (!unos.ToUpper().Equals("X"));
        }
    }
}
