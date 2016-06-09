using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class BootstrapMethodsAttribute : Attribute
    {
        public ushort[] MethodRefs { get; private set; }
        public ushort[] Arguments { get; private set; }

        public BootstrapMethodsAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            ushort methodCount = reader.ReadUInt16();
            for (int i = 0; i < methodCount; i++) {
                MethodRefs[i] = reader.ReadUInt16();
                ushort argumentCount = reader.ReadUInt16();
                for (int j = 0; j < argumentCount; j++) {
                    Arguments[j] = reader.ReadUInt16();//assign these to methodref
                }
            }
        }
    }
}