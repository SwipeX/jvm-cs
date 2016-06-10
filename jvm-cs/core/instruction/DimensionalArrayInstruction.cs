namespace jvm_cs.core.instruction
{
    public class DimensionalArrayInstruction : Instruction
    {
        public byte Dimensions { get; }
        public string Type { get; }

        public DimensionalArrayInstruction(byte opcode, int index, string type, byte dim) : base(opcode, index)
        {
            Dimensions = dim;
            Type = type;
        }
    }
}