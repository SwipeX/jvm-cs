namespace jvm_cs.core.attribute.element
{
    public class ClassElementValue : ElementValue
    {
        public ClassElementValue(char tag, DataReader reader) : base(tag, reader)
        {
        }

        public override void Read(DataReader reader)
        {
            ushort classInfoIndex = reader.ReadUInt16();
        }
    }
}