using System;

namespace jvm_cs.core.attribute.element
{
    public class ElementValuePair
    {
        public ushort NameIndex { get; private set; }
        public ElementValue Value { get; private set; }

        public void Read(DataReader reader)
        {
            NameIndex = reader.ReadUInt16();
            Value = ElementValue.GetElementValue(reader);
        }
    }
}