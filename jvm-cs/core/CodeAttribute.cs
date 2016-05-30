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
            byte opcode = reader.ReadByte();
            switch (opcode)
            {
                case Opcodes.BIPUSH:
                    return new PushInstruction(opcode, reader.ReadByte());
                case Opcodes.SIPUSH:
                    return new PushInstruction(opcode, reader.ReadUInt16());
                case Opcodes.GETFIELD:
                case Opcodes.PUTFIELD:
                case Opcodes.GETSTATIC:
                case Opcodes.PUTSTATIC:
                case Opcodes.INVOKESPECIAL:
                case Opcodes.INVOKEVIRTUAL:
                case Opcodes.INVOKESTATIC:
                    ushort index = reader.ReadUInt16();
                    string[] value = ((string)ConstantPool.Instance.Value(index)).Split('.');
                    string className = value[0];
                    string[] nameType = value[1].Split(' ');
                    return new MemberInstruction(opcode, className, nameType[0], nameType[1]);
                default:
                    return new Instruction(opcode);
            }
        }
    }
}