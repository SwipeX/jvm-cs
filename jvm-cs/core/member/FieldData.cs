using System.Collections.Generic;
using jvm_cs.core.attribute;

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
    }
}