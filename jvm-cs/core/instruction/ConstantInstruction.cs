namespace jvm_cs.core.instruction
{
    public class ConstantInstruction : Instruction
    {
        public dynamic Constant { get; private set; }

        public ConstantInstruction(byte opcode, int index, dynamic constant) : base(opcode, index)
        {
            Constant = constant;
        }
    }
}