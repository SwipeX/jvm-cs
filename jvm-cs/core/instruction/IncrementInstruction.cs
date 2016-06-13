using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.io;

namespace jvm_cs.core.instruction
{
    public class IncrementInstruction : Instruction
    {
        public int VarIndex; //IINC
        public int Value;

        public IncrementInstruction(byte opcode, int index, int varIndex, int value) : base(opcode, index)
        {
            VarIndex = varIndex;
            Value = value;
        }

        public override string ToString()
        {
            return base.ToString() + " " + VarIndex + " " + Value;
        }

        public override void Write(DataWriter writer)
        {
            base.Write(writer);
            writer.WriteUInt16((ushort) VarIndex);
            writer.WriteUInt16((ushort) Value);
        }
    }
}