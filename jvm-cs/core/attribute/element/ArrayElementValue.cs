namespace jvm_cs.core.attribute.element
{
    public class ArrayElementValue : ElementValue
    {
        public ElementValue[] Values { get; private set; }

        public ArrayElementValue(char tag, DataReader reader) : base(tag, reader)
        {
        }

        public override void Read(DataReader reader)
        {
            ushort elementValueEntriesLength = reader.ReadUInt16();
            Values = new ElementValue[elementValueEntriesLength];
            for (int i = 0; i < Values.Length; i++) {
                Values[i] = ElementValue.GetElementValue(reader);
            }
        }
    }
}