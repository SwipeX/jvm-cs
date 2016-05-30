using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.core.instruction;
using jvm_cs.io;

namespace jvm_cs.core
{
    public class CodeAttribute : Attribute
    {
        private readonly MethodData _owner;

        public CodeAttribute(string name, uint length, MethodData owner) : base(name, length)
        {
            _owner = owner;
        }

        public new void ReadBytes(DataReader reader)
        {
            _owner.MaxStack = reader.ReadUInt16();
            _owner.MaxLocals = reader.ReadUInt16();
            uint codeLength = reader.ReadUInt32();
            ProcessCode(reader.ReadBytes((int) codeLength));
            ushort exceptionCount = reader.ReadUInt16();
            for (int i = 0; i < exceptionCount; i++)
            {
                ushort startPc = reader.ReadUInt16();
                ushort endPc = reader.ReadUInt16();
                ushort handlerPc = reader.ReadUInt16();
                ushort catchType = reader.ReadUInt16();
            }
            ushort attributesCount = reader.ReadUInt16();
            for (int i = 0; i < attributesCount; i++)
            {
                ushort nameIndex = reader.ReadUInt16();
                uint length = reader.ReadUInt32();
                reader.ReadBytes((int) length);
            }
        }

        private void ProcessCode(byte[] data)
        {
            DataReader reader = new DataReader(new MemoryStream(data));
            Instruction previous = null;
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                Instruction instruction = CreateInstruction(reader);
                instruction.Previous = previous;
                if (previous != null)
                {
                    previous.Next = instruction;
                }
                previous = instruction;
                _owner.Instructions.Add(instruction);
            }
        }

        private Instruction CreateInstruction(DataReader reader)
        {
            bool wide = false;
            byte opcode = reader.ReadByte();
            if (opcode == Opcodes.WIDE)
            {
                wide = true;
                opcode = reader.ReadByte();
            }
            switch (opcode)
            {
                case Opcodes.BIPUSH:
                    return new PushInstruction(opcode, reader.ReadByte());
                case Opcodes.SIPUSH:
                    return new PushInstruction(opcode, reader.ReadUInt16());

                case Opcodes.INVOKEINTERFACE:
                    string[] data = readMethod(reader);
                    byte count = reader.ReadByte();
                    reader.ReadByte(); //Read the zero that java likes to stick here...
                    return new MethodInstruction(opcode, data[0], data[1], data[2], count);
                case Opcodes.GETFIELD:
                case Opcodes.PUTFIELD:
                case Opcodes.GETSTATIC:
                case Opcodes.PUTSTATIC:
                case Opcodes.INVOKESPECIAL:
                case Opcodes.INVOKEVIRTUAL:
                case Opcodes.INVOKESTATIC:
                case Opcodes.INVOKEDYNAMIC:
                    string[] method = readMethod(reader);
                    if (opcode == Opcodes.INVOKEDYNAMIC)
                        reader.ReadBytes(2); //read the 0's because java
                    return new MemberInstruction(opcode, method[0], method[1], method[2]);

                case Opcodes.IINC:
                    return new IncrementInstruction(opcode, wide ? reader.ReadUInt16() : reader.ReadByte(),
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
                    return new VariableInstruction(opcode, wide ? reader.ReadUInt16() : reader.ReadByte());
                case Opcodes.CHECKCAST:
                case Opcodes.ANEWARRAY:
                    return new TypeInstruction(opcode, ConstantPool.Instance.Value(reader.ReadUInt16()) as string);

                default:
                    return new Instruction(opcode);
            }
        }

        private string[] readMethod(DataReader reader)
        {
            ushort index = reader.ReadUInt16();
            string[] value = ((string) ConstantPool.Instance.Value(index)).Split('.');
            string className = value[0];
            string[] nameType = value[1].Split(' ');
            return new[] {className, nameType[0], nameType[1]};
        }
    }
}