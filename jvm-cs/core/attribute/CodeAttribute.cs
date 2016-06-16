using System.Collections.Generic;
using System.IO;
using jvm_cs.core.instruction;
using jvm_cs.core.member;
using jvm_cs.io;

namespace jvm_cs.core.attribute
{
    public class CodeAttribute : Attribute
    {
        private List<Attribute> Attributes { get; }

        public CodeAttribute(string name, uint length, MemberData owner) : base(name, length, owner)
        {
            Attributes = new List<Attribute>();
        }

        public override void ReadBytes(DataReader reader)
        {
            Owner.MaxStack = reader.ReadUInt16();
            Owner.MaxLocals = reader.ReadUInt16();
            uint codeLength = reader.ReadUInt32();
            ProcessCode(reader.ReadBytes((int) codeLength));
            ushort exceptionCount = reader.ReadUInt16();
            for (int i = 0; i < exceptionCount; i++) {
                Owner.Exceptions.Add(ExceptionData.Read(reader, Owner.Owner.Pool));
            }
            ushort attributesCount = reader.ReadUInt16();
            for (int i = 0; i < attributesCount; i++) {
                ushort nameIndex = reader.ReadUInt16();
                uint length = reader.ReadUInt32();
                Attribute subAttribute = new Attribute(Owner.Owner.Pool.Value(nameIndex) as string, length, null as MemberData);
                subAttribute.ReadBytes(reader);
                Attributes.Add(subAttribute);
            }
        }

        public override void Write(DataWriter writer)
        {
            writer.WriteUInt16(Owner.MaxStack);
            writer.WriteUInt16(Owner.MaxLocals);
            byte[] code = PackInstructions(Owner.Instructions);
            writer.WriteUInt16((ushort) code.Length);
            writer.Write(code);
            List<ExceptionData> exceptions = Owner.Exceptions;
            writer.WriteUInt16((ushort) exceptions.Count);
            exceptions.ForEach(ex => ex.Write(writer, Owner.Owner.Pool));
        }

        private byte[] PackInstructions(List<Instruction> instructions)
        {
            return null;
        }

        private void ProcessCode(byte[] data)
        {
            DataReader reader = new DataReader(new MemoryStream(data));
            Instruction previous = null;
            while (reader.BaseStream.Position != reader.BaseStream.Length) {
                Instruction instruction = CreateInstruction(reader);
                instruction.Previous = previous;
                if (previous != null) {
                    previous.Next = instruction;
                }
                previous = instruction;
                Owner.Instructions.Add(instruction);
            }
            Resolve(Owner.Instructions);
        }

        private void Resolve(List<Instruction> instructions)
        {
            foreach (Instruction instruction in instructions) {
                if (instruction is BranchInstruction) {
                    BranchInstruction branchInstruction = (BranchInstruction) instruction;
                    branchInstruction.Label = new Label(branchInstruction, branchInstruction.TotalOffset(), instructions);
                } else if (instruction is MathInstruction) {
                    MathInstruction mathInstruction = (MathInstruction) instruction;
                } else if (instruction is TableSwitchInstruction) {
                    TableSwitchInstruction tis = (TableSwitchInstruction) instruction;
                    for (int i = 0; i < tis.JumpOffsets.Length; i++) {
                        tis.Labels[i] = new Label(tis, tis.JumpOffsets[i], instructions);
                    }
                }
            }
        }

        private Instruction CreateInstruction(DataReader reader)
        {
            bool wide = false;
            int index = (int) reader.BaseStream.Position;
            byte opcode = reader.ReadByte();
            if (opcode == Opcodes.WIDE) {
                wide = true;
                opcode = reader.ReadByte();
            }
            switch (opcode) {
                case Opcodes.MULTIANEWARRAY:
                    return new DimensionalArrayInstruction(opcode, index, Owner.Owner.Pool.Value(reader.ReadUInt16()), reader.ReadByte());
                case Opcodes.LDC:
                case Opcodes.LDC_W:
                case Opcodes.LDC2_W:
                    return new ConstantInstruction(opcode, index, Owner.Owner.Pool.Value(opcode > Opcodes.LDC || wide ? reader.ReadUInt16() : reader.ReadByte()));
                case Opcodes.BIPUSH:
                    return new PushInstruction(opcode, index, reader.ReadByte());

                case Opcodes.SIPUSH:
                    return new PushInstruction(opcode, index, reader.ReadUInt16());

                case Opcodes.INVOKEINTERFACE:
                    string[] data = ReadMethod(reader);
                    byte count = reader.ReadByte();
                    reader.ReadByte(); //Read the zero that java likes to stick here...
                    return new MethodInstruction(opcode, index, data[0], data[1], data[2], count, Owner);
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
                    return new BranchInstruction(opcode, index, wide ? reader.ReadInt32() : reader.ReadInt16());
                case Opcodes.RET:
                    return new VariableInstruction(opcode, index, wide ? reader.ReadUInt16() : reader.ReadByte());
                case Opcodes.GETFIELD:
                case Opcodes.PUTFIELD:
                case Opcodes.GETSTATIC:
                case Opcodes.PUTSTATIC:
                case Opcodes.INVOKESPECIAL:
                case Opcodes.INVOKEVIRTUAL:
                case Opcodes.INVOKESTATIC:
                case Opcodes.INVOKEDYNAMIC:
                    string[] method = ReadMethod(reader);
                    if (opcode == Opcodes.INVOKEDYNAMIC)
                        reader.ReadBytes(2); //read the 0's because java
                    return new MemberInstruction(opcode, index, method[0], method[1], method[2], Owner);

                case Opcodes.IINC:
                    return new IncrementInstruction(opcode, index, wide ? reader.ReadInt16() : reader.ReadByte(),
                        wide ? reader.ReadInt16() : reader.ReadByte());

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
                    return new VariableInstruction(opcode, index, wide ? reader.ReadUInt16() : reader.ReadByte());

                case Opcodes.TABLESWITCH:
                    ReadPadding(reader);
                    int[] values = {reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32()};
                    int offsetCount = values[2] - values[1] + 1;
                    int[] jumps = new int[offsetCount];
                    for (int i = 0; i < offsetCount; i++)
                        jumps[i] = reader.ReadInt32();
                    return new TableSwitchInstruction(opcode, index, values[0], values[1], values[2], jumps);
                case Opcodes.LOOKUPSWITCH:
                    ReadPadding(reader);
                    int offset = reader.ReadInt32();
                    int pairCount = reader.ReadInt32();
                    Dictionary<int, int> pairs = new Dictionary<int, int>(pairCount);
                    for (int i = 0; i < pairCount; i++) {
                        pairs.Add(reader.ReadInt32(), reader.ReadInt32());
                    }
                    return new LookupSwitchInstruction(opcode, index, offset, pairCount, pairs);
                case Opcodes.CHECKCAST:
                case Opcodes.ANEWARRAY:
                case Opcodes.INSTANCEOF:
                case Opcodes.NEW:
                    return new TypeInstruction(opcode, index, Owner.Owner.Pool.Value(reader.ReadUInt16()) as string, Owner);
                default:
                {
                    if (opcode >= Opcodes.IADD && opcode <= Opcodes.LXOR) {
                        return new MathInstruction(opcode, index);
                    } else if (opcode >= Opcodes.I2L && opcode <= Opcodes.I2S) {
                        return new ConversionInstruction(opcode, index);
                    } else if (opcode >= Opcodes.ICONST_M1 && opcode <= Opcodes.DCONST_1) {
                        return new NumericInstruction(opcode, index);
                    }
                    return new Instruction(opcode, index);
                }
            }
        }

        private void ReadPadding(DataReader reader)
        {
            int padding = (int) (4 - reader.BaseStream.Position % 4);
            padding = (padding == 4 ? 0 : padding);
            for (int j = 0; j < padding; j++)
                reader.ReadByte();
        }

        private string[] ReadMethod(DataReader reader)
        {
            ushort index = reader.ReadUInt16();
            object o = Owner.Owner.Pool.Value(index);
            string[] strings = o as string[];
            if (strings == null) return new[] {"", "", ""}; //TODO avoid this
            string[] value = strings;
            return new[] {value[0], value[1], value.Length == 3 ? value[2] : ""}; //TODO seperate dynamic
        }
    }
}