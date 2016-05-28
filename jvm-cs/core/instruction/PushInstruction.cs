using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class PushInstruction : Instruction
    {
        public int PushValue;//Bipush,Sipush,Newarray
        public PushInstruction(byte opcode, int pushValue) : base(opcode)
        {
            PushValue = pushValue;
        }
    }
}
