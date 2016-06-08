using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class TypeInstruction : Instruction
    {
        public string Type { get; }

        public TypeInstruction(byte opcode, int index, string type) : base(opcode, index)
        {
            Type = type;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Type;
        }
    }
}