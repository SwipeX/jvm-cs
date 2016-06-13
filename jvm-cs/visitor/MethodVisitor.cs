using System;
using jvm_cs.core;
using jvm_cs.core.instruction;
using Attribute = jvm_cs.core.attribute.Attribute;

namespace jvm_cs.visitor
{
    public class MethodVisitor
    {
        public void VisitAttribute(Attribute attr)
        {
        }

        public void VisitInstr(Instruction instruction)
        {
        }

        public void VisitPushInstr(PushInstruction instruction)
        {
        }

        public void VisitVariableInstr(VariableInstruction instruction)
        {
        }

        public void VisitTypeInstr(TypeInstruction instruction)
        {
        }

        public void VisitFieldInstr(FieldInstruction instruction)
        {
        }


        public void VisitMethodInstr(MethodInstruction instruction)
        {
        }

        public void VisitJumpInstr(BranchInstruction instruction)
        {
        }

        public void VisitLabel(Label label)
        {
        }

        public void VisitConstantInstr(ConstantInstruction instruction)
        {
        }

        public void VisitIncrementInstr(IncrementInstruction instruction)
        {
        }

        public void VisitTableSwitchInstr(TableSwitchInstruction instruction)
        {
        }

        public void VisitLookupSwitchInstr(LookupSwitchInstruction linstruction)
        {
        }

        public void VisitDimensionalArrayInstr(DimensionalArrayInstruction instruction)
        {
        }
    }
}