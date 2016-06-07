namespace jvm_cs.core.instruction
{
    public class Instruction
    {
        public byte Opcode { get; }
        public Instruction Previous { get; set; }
        public Instruction Next { get; set; }
        public int Index { get; private set; }

        public Instruction(byte opcode, int index)
        {
            Opcode = opcode;
            Index = index;
        }

        public bool HasNext()
        {
            return Next != null;
        }

        public bool HasPrevious()
        {
            return Previous != null;
        }
    }
}