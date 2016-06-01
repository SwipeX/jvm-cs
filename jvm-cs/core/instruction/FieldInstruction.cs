using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class FieldInstruction : MemberInstruction
    {
        public FieldInstruction(byte opcode, string owner, string name, string desc)
            : base(opcode, owner, name, desc)
        {
        }
    }
}