using jvm_cs.core.member;
using jvm_cs.io;

namespace jvm_cs.core.attribute
{
    public class SyntheticAttribute : Attribute
    {
        //This class soley alerts that the member is synthetic, and access flags are preferred...
        public SyntheticAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

    }
}