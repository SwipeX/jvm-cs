using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class VariableInstruction : Instruction
    {
        public int Index { get; }

        public VariableInstruction(byte opcode, int index) : base(opcode)
        {
            Index = index;
        }
    }
}
