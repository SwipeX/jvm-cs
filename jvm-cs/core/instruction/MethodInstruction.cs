using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class MethodInstruction :Instruction
    {          
        public string Owner;
        public string Name;
        public string Desc;

        public MethodInstruction(string owner, string name, string desc, byte opcode) : base(opcode)
        {
            this.Owner = owner;
            this.Name = name;
            this.Desc = desc;
        }
    }
}
