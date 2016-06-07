using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class IncrementInstruction : Instruction
    {
        public int VarIndex;//IINC
        public int Value;

        public IncrementInstruction(byte opcode, int index,  int varIndex, int value) : base(opcode,index)
        {
            VarIndex = varIndex;
            Value = value;
        }
    }
}
