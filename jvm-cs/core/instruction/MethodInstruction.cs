using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class MethodInstruction : MemberInstruction
    {
        public int Count { get; private set; } //used for invokeinterface

        public MethodInstruction(byte opcode, string owner, string name, string desc) : base(opcode, owner, name, desc)
        {
        }
        public MethodInstruction(byte opcode, string owner, string name, string desc, int count) : base(opcode, owner, name, desc)
        {
            Count = count;
        }
    }
}