using System;
using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class ExceptionsAttribute : Attribute
    {
        public int[] IndexTable;
        public string[] ThrownClasses;


        public ExceptionsAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
        }

        public override void ReadBytes(DataReader reader)
        {
            uint count = reader.ReadUInt16();
            IndexTable = new int[count];
            ThrownClasses = new string[count];
            for (int i = 0; i < count; i++) {
                IndexTable[i] = reader.ReadUInt16();
                ThrownClasses[i] = Owner.Owner.Pool.Value(IndexTable[i]) as string;
            }
        }
    }
}