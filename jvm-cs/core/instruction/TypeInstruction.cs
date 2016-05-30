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

        public TypeInstruction(byte opcode,string type) : base(opcode)
        {
            Type = type;
        }
    }
}