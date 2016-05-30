using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class FieldInstruction : MemberInstruction
    {
        public FieldInstruction(string owner, string name, string desc, byte opcode) : base(owner, name, desc, opcode)
        {
        }
    }
}
