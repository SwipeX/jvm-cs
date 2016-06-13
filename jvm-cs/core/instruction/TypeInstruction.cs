using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.core.member;
using jvm_cs.io;

namespace jvm_cs.core.instruction
{
    public class TypeInstruction : Instruction
    {
        public string Type { get; }
        public MethodData Parent { get; }

        public TypeInstruction(byte opcode, int index, string type, MethodData parent) : base(opcode, index)
        {
            Type = type;
            Parent = parent;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Type;
        }

        public override void Write(DataWriter writer)
        {
            base.Write(writer);
        }
    }
}