using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public Code code;
        [DataMember]
        public int value;
        public Item(Code c, int v) { code = c; value = v; }
        public override string ToString()
        {
            return string.Format("{0,-20} {1,-25}", code, value);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-25}",
                                "CODE", "VALUE");
        }
    }
}
