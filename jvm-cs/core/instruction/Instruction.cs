namespace jvm_cs.core.instruction
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