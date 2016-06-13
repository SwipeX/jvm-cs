using System;
using jvm_cs.core.member;
using jvm_cs.io;

namespace jvm_cs.core.attribute
{
    public class SourceFileAttribute : Attribute
    {
        public string SourceFile { get; private set; }

        public SourceFileAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            SourceFile = Owner.Pool.Value(reader.ReadUInt16());
        }

        public override void Write(DataWriter writer)
        {
            writer.Write(Owner.Pool.IndexOf(SourceFile));
        }
    }
}