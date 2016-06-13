using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.core.member;

namespace jvm_cs.core.instruction
{
    public class MethodInstruction : MemberInstruction
    {
        public int Count { get; private set; } //used for invokeinterface

        public MethodInstruction(byte opcode, int index,  string owner, string name, string desc, MethodData parent) : base(opcode,index, owner, name, desc, parent)
        {
        }
        public MethodInstruction(byte opcode,  int index, string owner, string name, string desc, int count,MethodData parent) : base(opcode,index, owner, name, desc, parent)
        {
            Count = count;
        }
    }
}