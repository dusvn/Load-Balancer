using System;
using System.Diagnostics.CodeAnalysis;

namespace LoadBalancer.DB.Model
{
    public class DataSet1
    {
        public int Wid { get; set; }
        public string Code { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }

        public DataSet1(int wid, string code, int value, DateTime time)
        {
            this.Wid = wid;
            this.Code = code;
            this.Value = value;
            this.Time = time;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return string.Format("{0,-20} {1,-25} {2,-25}", Code, Value, Time);
        }

        [ExcludeFromCodeCoverage]
        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-25} {2,-25}",
                                "CODE", "VALUE", "TIME");
        }
    }
}
