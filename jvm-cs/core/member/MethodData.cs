using System.Collections.Generic;
using jvm_cs.core.instruction;

namespace jvm_cs.core.member
{
    public class MethodData : MemberData
    {
        public List<Instruction> Instructions { get; }
        public string Desc { get; }
        public ClassData Owner { get; }

        public int MaxStack;

        public int MaxLocals;

        public MethodData(string name, string desc, int access, ClassData owner) : base(name, access)
        {
            Desc = desc;
            Owner = owner;
            Instructions = new List<Instruction>();
        }

        public override string ToString()
        {
            return Owner + "." + Name + " " + Desc;
        }
    }
}