using System.Runtime.Serialization;

namespace Common
{
    public enum Code
    {
        [EnumMember] CODE_ANALOG,
        [EnumMember] CODE_DIGITAL,
        [EnumMember] CODE_CUSTOM,
        [EnumMember] CODE_LIMITSET,
        [EnumMember] CODE_SINGLENODE,
        [EnumMember] CODE_MULTIPLENODE,
        [EnumMember] CODE_CONSUMER,
        [EnumMember] CODE_SOURCE
    }
}
