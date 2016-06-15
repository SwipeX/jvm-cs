using System.Collections.Generic;
using jvm_cs.core.attribute;
using jvm_cs.io;
using jvm_cs.visitor;

namespace jvm_cs.core.member
{
    public class FieldData : MemberData
    {
        public string Desc { get; }
        public ClassData Owner { get; }

        public FieldData(string name, string desc, int access, ClassData owner) : base(name, access)
        {
            Desc = desc;
            Owner = owner;
        }

        public override string ToString()
        {
            return Name + " " + Desc;
        }

        public void Visit(FieldVisitor visitor)
        {
            Attributes.ForEach(visitor.VisitAttribute);
        }

        public void Write(DataWriter writer)
        {
            writer.WriteInt16((short) Access);
            writer.WriteUInt16(Owner.Pool.IndexOf(Name));
            writer.WriteUInt16(Owner.Pool.IndexOf(Desc));
            writer.WriteUInt16((ushort) Attributes.Count);
            Attributes.ForEach(a => a.Write(writer));
        }
    }
}