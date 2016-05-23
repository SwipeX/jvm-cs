using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            byte[] opcodeArray = reader.ReadBytes((int)codeLength);
            Instruction previous = null;
            foreach (byte opcode in opcodeArray)
            {
                Instruction instruction = new Instruction(opcode) { Previous = previous };
                if (previous != null) { previous.Next = instruction; }
                previous = instruction;
                _owner.Instructions.Add(instruction);
            }
            ushort exceptionTableCount = reader.ReadUInt16();
            for (int i = 0; i < exceptionTableCount; i++)
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
                reader.ReadBytes((int)length);
            }
        }
    }
}