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
            ClassName = pool.Value(reader.ReadInt16()) as string;
            MethodName = pool.Value(reader.ReadInt16()) as string;
        }
    }
}