using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class ConstantValueAttribute : Attribute
    {
        public object Constant { get; private set; }

        public ConstantValueAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            Constant = Owner.Owner.Pool.Value(reader.ReadUInt16());
        }
    }
}