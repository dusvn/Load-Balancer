using System.Diagnostics.CodeAnalysis;

namespace Common.DB.Model
{
    public class ItemLB
    {
        public string Code { get; set; }
        public int Value { get; set; }

        public ItemLB(string code, int value)
        {
            Code = code;
            Value = value;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return string.Format("{0,-20} {1,-25}", Code, Value);
        }

        [ExcludeFromCodeCoverage]
        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-25}",
                                "CODE", "VALUE");
        }
    }
}
