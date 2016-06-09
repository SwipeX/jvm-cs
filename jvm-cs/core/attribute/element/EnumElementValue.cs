namespace jvm_cs.core.attribute.element
{
    public class EnumElementValue : ElementValue
    {
        public int TypeNameIndex { get; private set; }
        public int ConstNameIndex { get; private set; }

        public EnumElementValue(char tag, DataReader reader) : base(tag, reader)
        {
        }

        public override void Read(DataReader reader)
        {
            TypeNameIndex = reader.ReadUInt16();
            ConstNameIndex = reader.ReadUInt16();
        }
    }
}