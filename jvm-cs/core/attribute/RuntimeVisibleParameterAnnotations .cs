using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class RuntimeVisibleParameterAnnotations : RuntimeAnnotationsAttribute
    {
        public RuntimeVisibleParameterAnnotations(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }
    }
}