using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.core.member;

namespace jvm_cs.core.instruction
{
    public class FieldInstruction : MemberInstruction
    {
        public FieldInstruction(byte opcode, int index, string owner, string name, string desc, MethodData parent)
            : base(opcode, index, owner, name, desc, parent)
        {
        }
    }
}