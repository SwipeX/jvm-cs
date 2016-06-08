using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class VariableInstruction : Instruction
    {
        public uint VarIndex { get; }

        public VariableInstruction(byte opcode, int index, uint varIndex) : base(opcode, index)
        {
            VarIndex = varIndex;
        }

        public override string ToString()
        {
            return base.ToString() + " " + VarIndex;
        }
    }
}