using System;
using System.Security.Cryptography.X509Certificates;

namespace jvm_cs.core.instruction
{
    public class BranchInstruction : Instruction
    {
        private readonly int _branchOffset;
        public Label Label;

        public BranchInstruction(byte opcode, int index, int branchOffest) : base(opcode, index)
        {
            _branchOffset = branchOffest;
        }

        public int TotalOffset()
        {
            return (int) (Index + _branchOffset);
        }

        public override string ToString()
        {
            return base.ToString() + " " + Label.JumpIndex;
        }
    }
}