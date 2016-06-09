using System.Dynamic;
using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class RuntimeVisibleAnnotationsAttribute : RuntimeAnnotationsAttribute
    {
        public RuntimeVisibleAnnotationsAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }
    }
}