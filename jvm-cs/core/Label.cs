using System.Collections.Generic;
using jvm_cs.core.instruction;

namespace jvm_cs.core
{
    public class Label
    {
        public int Index { get; }
        public int JumpIndex { get; }
        public Instruction Start { get; }
        public Instruction Destintation { get; }

        public Label(int idx, int jump, Instruction from, Instruction to)
        {
            Index = idx;
            JumpIndex = jump;
            Start = from;
            Destintation = to;
        }

        public Label(Instruction from, int jump, List<Instruction> instructions)
        {
            Index = from.Index;
            Start = from;
            JumpIndex = jump;
            Destintation = Instructions.AtIndex(instructions, jump);
        }

        public override string ToString()
        {
            return Index + " " + JumpIndex;
        }
    }
}