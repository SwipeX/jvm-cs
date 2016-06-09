using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class DeprecatedAttribute : Attribute
    {
         //This class soley alerts that the member is Deprecated
        public DeprecatedAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }
    }
}