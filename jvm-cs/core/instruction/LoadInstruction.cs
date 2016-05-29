using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
   public class LoadInstruction : Instruction
   {
       public dynamic Value;

       public LoadInstruction(byte opcode, dynamic value) : base(opcode)
       {
           Value = value;
       }
   }
}
