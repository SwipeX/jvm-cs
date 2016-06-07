using System;
using System.Security.Cryptography.X509Certificates;

namespace jvm_cs.core.instruction
{
    public class BranchInstruction : Instruction
    {
        private readonly uint _branchOffset;
        public Instruction Destination { get; internal set; }

        public BranchInstruction(byte opcode, int index, uint branchOffest) : base(opcode, index)
        {
            _branchOffset = branchOffest;
        }

        public long TotalOffset()
        {
            return Index + _branchOffset;
        }
    }
}