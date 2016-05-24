using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core
{
    public class Instruction
    {
        public byte Opcode { get; }
        public Instruction Previous { get; set; }
        public Instruction Next { get; set; }

        public Instruction(byte opcode)
        {
            Opcode = opcode;
        }

        public bool hasNext()
        {
            return Next != null;
        }

        public bool hasPrevious()
        {
            return Previous != null;
        }
    }
}