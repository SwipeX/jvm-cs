using System.Collections.Generic;

namespace jvm_cs.core.instruction
{
    public class LookupSwitchInstruction : Instruction

    {
        public int DefaultOffset { get; }
        public int Count { get; }
        public Dictionary<int, int> OffsetPairs;

        public LookupSwitchInstruction(byte opcode, int index, int offset, int count, Dictionary<int, int> pairs) : base(opcode, index)
        {
            DefaultOffset = offset;
            Count = count;
            OffsetPairs = pairs;
        }
    }
}