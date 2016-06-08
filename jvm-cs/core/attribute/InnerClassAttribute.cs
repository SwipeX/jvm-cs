using jvm_cs.core.attribute;
using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class InnerClassAttribute : Attribute
    {
        public InnerClassAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            uint count = reader.ReadUInt16();
            for (int i = 0; i < count; i++) {
                string infoIn = Owner.Pool.Value(reader.ReadInt16());
                string infoOut = Owner.Pool.Value(reader.ReadInt16());
                string innerName = Owner.Pool.Value(reader.ReadInt16());
                ushort innerAccess = reader.ReadUInt16();
                Owner.InnerClasses.Add(new InnerClassData(innerName, innerAccess, infoIn, infoOut));
            }
        }
    }
}