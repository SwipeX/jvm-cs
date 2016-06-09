using System;

namespace jvm_cs.core.attribute.element
{
    public class AnnotationElementValue : ElementValue
    {
        public ElementValuePair[] Values { get; private set; }
        public ushort TypeIndex { get; private set; }

        public AnnotationElementValue(char tag, DataReader reader) : base(tag, reader)
        {
        }

        public override void Read(DataReader reader)
        {
            TypeIndex = reader.ReadUInt16();
            ushort count = reader.ReadUInt16();
            Values = new ElementValuePair[count];
            for (int i = 0; i < count; i++) {
                Values[i] = new ElementValuePair();
                Values[i].Read(reader);
            }
        }
    }
}