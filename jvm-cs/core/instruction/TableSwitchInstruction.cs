using System.Runtime.InteropServices;

namespace jvm_cs.core.instruction
{
    public class TableSwitchInstruction : Instruction
    {
        public int DefaultOffset { get; private set; }
        public int LowByte { get; private set; }
        public int HighByte { get; private set; }
        public int[] JumpOffsets;
        public Instruction[] JumpInstructions; //set these in resolve

        public TableSwitchInstruction(byte opcode, int index, int offset, int low, int high, int[] jumps) : base(opcode, index)
        {
            DefaultOffset = offset;
            LowByte = low;
            HighByte = high;
            JumpOffsets = jumps;
        }
    }
}