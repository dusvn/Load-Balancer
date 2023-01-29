using System.Diagnostics.CodeAnalysis;

namespace Common
{
    public class WorkerProperty
    {
        public Code code;
        public int workerValue;
        public WorkerProperty(Item item)
        {
            code = item.code;
            workerValue = item.value;
        }

        public WorkerProperty(Code c, int v)
        {
            code = c;
            workerValue = v;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return string.Format("{0,-20} {1,-25}", code, workerValue);
        }

        [ExcludeFromCodeCoverage]
        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-25}",
                                "CODE", "VALUE");
        }
    }
}
