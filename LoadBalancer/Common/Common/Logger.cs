using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logger
    {
        private string fileName;
        StreamWriter streamWriter;

        public string FileName { get => fileName; set => fileName = value; }
        public StreamWriter StreamWriter { get => streamWriter; set => streamWriter = value; }

        public Logger(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("Argument ne sme biti null.");
            }
            else if (!fileName.Contains(@"\"))
            {
                throw new ArgumentException("Pogresan format stringa.");
            }
            else
            {
                this.FileName = fileName;
            }
        }

        public void WorkerSaveLog(int wid, Code code, int value, DateTime dt)
        {
            if (code < 0 || value < 1 || value > 10000 || wid < 0)
            {
                throw new ArgumentException("Pogresni argumenti.");
            }
            else if (code > (Code)7)
            {
                throw new ArgumentException("Kod ne sme biti veci od 7");
            }
            else if (dt > DateTime.Now)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dt.ToString() + ": WORKER " + wid + " SACUVAO -> Code: " + code.ToString() + ", Value: " + value;
            UpisUFajl(t);
        }

        public void WorkerReciveLog(int wid, Code code, int value, DateTime dt)
        {
            if (code < 0 || value < 1 || value > 10000 || wid < 0)
            {
                throw new ArgumentException("Pogresni argumenti.");
            }
            else if (code > (Code)7)
            {
                throw new ArgumentException("Kod ne sme biti veci od 7");
            }
            else if (dt > DateTime.Now)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dt.ToString() + ": WORKER " + wid + " PRIMIO -> Code: " + code.ToString() + ", Value: " + value;
            UpisUFajl(t);
        }

        public void WriterLog(Code code, int value, DateTime dt)
        {
            if (code < 0 || value <= 0 || value > 10000)
            {
                throw new ArgumentException("Pogresni argumenti.");
            }
            else if (code > (Code)7)
            {
                throw new ArgumentException("Kod ne sme biti veci od 7");
            }
            else if (dt > DateTime.Now)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dt.ToString() + ": WRITER POSLAO -> Code: " + code.ToString() + ", Value: " + value;
            UpisUFajl(t);
        }

        public void LBReciveLog(Code code, int value, DateTime dt)
        {
            if (code < 0 || value <= 0 || value > 10000)
            {
                throw new ArgumentException("Pogresni argumenti.");
            }
            else if (code > (Code)7)
            {
                throw new ArgumentException("Kod ne sme biti veci od 7");
            }
            else if (dt > DateTime.Now)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dt.ToString() + ": LOAD BALANCER PRIMIO -> Code: " + code.ToString() + ", Value: " + value;
            UpisUFajl(t);
        }

        public void LBSendLog(Code code, int value, DateTime dt, int wid)
        {
            if (code < 0 || value <= 0 || value > 10000 || wid < 0)
            {
                throw new ArgumentException("Pogresni argumenti.");
            }
            else if (code > (Code)7)
            {
                throw new ArgumentException("Kod ne sme biti veci od 7");
            }
            else if (dt > DateTime.Now)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dt.ToString() + ": LOAD BALANCER POSLAO -> Workeru " + wid + ": Code: " + code.ToString() + ", Value: " + value;
            UpisUFajl(t);
        }

        public void GasenjeLog(DateTime dt)
        {
            if (dt > DateTime.Now)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dt.ToString() + ": APLIKACIJA UGASENA(Balanser je lipsa)\n" + "===============================================================================================";
            UpisUFajl(t);
        }

        public void ReadLog(DateTime dtFrom, DateTime dtTo, DateTime dtWhen, int wid, Code code)
        {
            if (wid < 0)
            {
                throw new ArgumentException("Argumenti ne smeju biti negativni");
            }
            else if (dtFrom > DateTime.Now || dtWhen > DateTime.Now || dtFrom > dtTo)
            {
                throw new ArgumentException("Datum je pogresan");
            }

            string t = "\n" + dtWhen.ToString() + ": READER ISCITAO-> Worker_" + wid + " data from: " + dtFrom.ToString() + " to: " + dtTo.ToString() + ", code: " + code.ToString();
            UpisUFajl(t);
        }



        public void UpisUFajl(string tekst)
        {
            using (StreamWriter = new StreamWriter(FileName, true))
            {
                StreamWriter.WriteLine(tekst);
            }
        }
    }
}
