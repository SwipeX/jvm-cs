using System.Collections.Generic;
using Attribute = jvm_cs.core.attribute.Attribute;

namespace jvm_cs.core.member
{
    public abstract class MemberData
    {
        public List<Attribute> Attributes { get; }
        public int Access { get; }
        public string Name { get; }

        protected MemberData(string name, int access)
        {
            Name = name;
            Access = access;
            Attributes = new List<Attribute>();
        }
    }
}