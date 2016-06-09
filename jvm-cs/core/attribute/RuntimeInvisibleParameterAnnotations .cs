using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class RuntimeInvisibleParameterAnnotations : RuntimeAnnotationsAttribute
    {
        public RuntimeInvisibleParameterAnnotations(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }
    }
}