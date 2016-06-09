using System;
using jvm_cs.core.attribute.element;
using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class RuntimeAnnotationsAttribute : Attribute
    {
        public int Count { get; private set; }
        public AnnotationElementValue[] Values;

        public RuntimeAnnotationsAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            Count = reader.ReadUInt16();
            Values = new AnnotationElementValue[Count];
            for (int i = 0; i < Count; i++) {
                Values[i] = new AnnotationElementValue('@', reader);
            }
        }
    }
}