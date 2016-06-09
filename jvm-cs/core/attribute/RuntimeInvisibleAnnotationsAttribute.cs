using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class RuntimeInvisibleAnnotationsAttribute : RuntimeAnnotationsAttribute
    {
        public RuntimeInvisibleAnnotationsAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }
    }
}