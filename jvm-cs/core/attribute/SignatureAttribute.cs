using jvm_cs.core.member;
using jvm_cs.io;

namespace jvm_cs.core.attribute
{
    public class SignatureAttribute : Attribute
    {
        public string Signature { get; private set; }

        public SignatureAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            ConstantPool pool;
            if (Owner is ClassData) {
                pool = Owner.Pool;
            } else {
                pool = Owner.Owner.Pool;
            }
            Signature = pool.Value(reader.ReadUInt16()) as string;
        }

        public override void Write(DataWriter writer)
        {
            ConstantPool pool;
            if (Owner is ClassData) {
                pool = Owner.Pool;
            } else {
                pool = Owner.Owner.Pool;
            }
            ushort idx = pool.IndexOf(Signature);
            writer.Write(idx);
        }
    }
}