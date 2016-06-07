using System.Collections.Generic;
using System.Linq;

namespace jvm_cs.core.instruction
{
    public static class Instructions
    {
        public static Instruction AtIndex(List<Instruction> instructions, long index)
        {
            return instructions.FirstOrDefault(instruction => instruction.Index == index);
        }

        public static bool IsInheritied(FieldData field)
        {
            ClassData super = field.Owner.Super();
            return super != null && super.Fields.Any(f => f.Name.Equals(field.Name));
        }
    }
}