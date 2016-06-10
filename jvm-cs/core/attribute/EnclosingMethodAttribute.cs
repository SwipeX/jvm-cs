using jvm_cs.core.member;
using jvm_cs.io;

namespace jvm_cs.core.attribute
{
    public class EnclosingMethodAttribute : Attribute
    {
        public string ClassName { get; private set; }
        public string MethodName { get; private set; }

        public EnclosingMethodAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            ConstantPool pool = Owner.Pool;
            ushort[] data = {reader.ReadUInt16(), reader.ReadUInt16()};
            ClassName = data[0] > 0 ? pool.Value(data[0]) as string : "";
            MethodName = data[1] > 0 ? pool.Value(data[1]) as string : "";
        }
    }
}