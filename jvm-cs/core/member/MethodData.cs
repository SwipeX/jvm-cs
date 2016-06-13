using System;
using System.Collections.Generic;
using jvm_cs.core.instruction;
using jvm_cs.visitor;

namespace jvm_cs.core.member
{
    public class MethodData : MemberData
    {
        public List<Instruction> Instructions { get; }
        public List<ExceptionData> Exceptions { get; }
        public string Desc { get; }
        public ClassData Owner { get; }
        //Two fields below set by CodeAttribute
        public int MaxStack;
        public int MaxLocals;

        public MethodData(string name, string desc, int access, ClassData owner) : base(name, access)
        {
            Desc = desc;
            Owner = owner;
            Instructions = new List<Instruction>();
            Exceptions = new List<ExceptionData>();
        }

        public override string ToString()
        {
            return Owner + "." + Name + " " + Desc;
        }

        public void Visit(MethodVisitor visitor)
        {
            Attributes.ForEach(visitor.VisitAttribute);
            foreach (Instruction instruction in Instructions) {
                int opcode = instruction.Opcode;

                switch (opcode) {
                    case Opcodes.MULTIANEWARRAY:
                        visitor.VisitDimensionalArrayInstr(instruction as DimensionalArrayInstruction);
                        break;
                    case Opcodes.LDC:
                    case Opcodes.LDC_W:
                    case Opcodes.LDC2_W:
                        visitor.VisitConstantInstr(instruction as ConstantInstruction);
                        break;
                    case Opcodes.BIPUSH:
                    case Opcodes.SIPUSH:
                        visitor.VisitPushInstr(instruction as PushInstruction);
                        break;
                    case Opcodes.IFEQ:
                    case Opcodes.IFNE:
                    case Opcodes.IFLT:
                    case Opcodes.IFGE:
                    case Opcodes.IFGT:
                    case Opcodes.IFLE:
                    case Opcodes.IF_ICMPEQ:
                    case Opcodes.IF_ICMPNE:
                    case Opcodes.IF_ICMPLT:
                    case Opcodes.IF_ICMPGE:
                    case Opcodes.IF_ICMPGT:
                    case Opcodes.IF_ICMPLE:
                    case Opcodes.IF_ACMPEQ:
                    case Opcodes.IFNONNULL:
                    case Opcodes.IFNULL:
                    case Opcodes.IF_ACMPNE:
                    case Opcodes.GOTO:
                    //JSR,RET deprecated since Java 5.0
                    case Opcodes.JSR:
                        visitor.VisitJumpInstr(instruction as BranchInstruction);
                        break;
                    case Opcodes.GETFIELD:
                    case Opcodes.PUTFIELD:
                    case Opcodes.GETSTATIC:
                    case Opcodes.PUTSTATIC:
                    case Opcodes.INVOKESPECIAL:
                    case Opcodes.INVOKEVIRTUAL:
                    case Opcodes.INVOKESTATIC:
                    case Opcodes.INVOKEDYNAMIC:
                    case Opcodes.INVOKEINTERFACE:
                        visitor.VisitMethodInstr(instruction as MethodInstruction);
                        break;
                    case Opcodes.IINC:
                        visitor.VisitIncrementInstr(instruction as IncrementInstruction);
                        break;
                    case Opcodes.RET:
                    case Opcodes.ALOAD:
                    case Opcodes.ILOAD:
                    case Opcodes.FLOAD:
                    case Opcodes.DLOAD:
                    case Opcodes.LLOAD:
                    case Opcodes.ASTORE:
                    case Opcodes.ISTORE:
                    case Opcodes.FSTORE:
                    case Opcodes.DSTORE:
                    case Opcodes.LSTORE:
                        visitor.VisitVariableInstr(instruction as VariableInstruction);
                        break;
                    case Opcodes.TABLESWITCH:
                        visitor.VisitTableSwitchInstr(instruction as TableSwitchInstruction);
                        break;
                    case Opcodes.LOOKUPSWITCH:
                        visitor.VisitLookupSwitchInstr(instruction as LookupSwitchInstruction);
                        break;
                    case Opcodes.CHECKCAST:
                    case Opcodes.ANEWARRAY:
                    case Opcodes.INSTANCEOF:
                    case Opcodes.NEW:
                        visitor.VisitTypeInstr(instruction as TypeInstruction);
                        break;
                    default:
                    {
                        visitor.VisitInstr(instruction);
                        break;
                    }
                }
            }
        }
    }
}