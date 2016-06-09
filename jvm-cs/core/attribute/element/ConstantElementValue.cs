using jvm_cs.io;

namespace jvm_cs.core.attribute.element
{
    public class ConstantElementValue : ElementValue
    {
        public ushort ValueIndex { get; private set; } //get from constant pool @ this index

        public ConstantElementValue(char tag, DataReader reader) : base(tag, reader)
        {
        }

        public override void Read(DataReader reader)
        {
            ValueIndex = reader.ReadUInt16();
        }
    }
}