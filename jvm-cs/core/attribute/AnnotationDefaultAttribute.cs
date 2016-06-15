using jvm_cs.core.attribute.element;
using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class AnnotationDefaultAttribute : Attribute
    {
        public ElementValue Value { get; private set; }

        public AnnotationDefaultAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            Value = ElementValue.GetElementValue(reader);
        }
    }
}