using System;
using System.Linq;

namespace jvm_cs.io
{
    public class ConstantPoolEntry
    {
        public int Index { get; }
        public byte Tag { get; set; }
        public byte[] Bytes { get; set; }
        public dynamic Value { get; set; }
        private ConstantPool _parent;

        public ConstantPoolEntry(ConstantPool parent, int index, byte tag, byte[] value)
        {
            _parent = parent;
            Index = index;
            Tag = tag;
            Bytes = value;
        }

        public ConstantPoolEntry(ConstantPool parent, int index, byte tag, dynamic value)
        {
            _parent = parent;
            Index = index;
            Tag = tag;
            Value = value;
        }

        public void Resolve()
        {
            switch (Tag) {
                case Opcodes.NAME_TYPE:
                    uint k = DataReader.ReadUInt16(new[] {Bytes[0], Bytes[1]});
                    uint j = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
                    if (_parent.Value(j) is string[])
                        Console.WriteLine(Index + " " + Tag + " " + k + " " + j);
                    string data = (string) _parent.Value(k);
                    string desc = (string) _parent.Value(j);
                    Value = new[] {data, desc};
                    break;
                case Opcodes.IMETH:
                case Opcodes.METH:
                case Opcodes.FIELD:
                    uint classIndex = DataReader.ReadUInt16(new[] {Bytes[0], Bytes[1]});
                    uint nameTypeIndex = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
                    string className = (string) _parent.Value(classIndex);
                    string[] nameType = (string[]) _parent.Value(nameTypeIndex);
                    Value = new[] {className, nameType[0], nameType[1]};
                    break;

                case Opcodes.INVOKE_DYNAMIC:
                    //bootstrap_method_attr_index???
                    uint i = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
                    Value = _parent.Value(i);
                    break;

                case Opcodes.INTEGER:
                    Value = DataReader.ReadUInt32(Bytes);
                    break;

                case Opcodes.FLOAT:
                    Value = DataReader.ReadSingle(Bytes);
                    break;

                case Opcodes.LONG:
                    Value = DataReader.ReadUInt64(Bytes);
                    break;

                case Opcodes.DOUBLE:
                    Value = DataReader.ReadDouble(Bytes);
                    break;

                case Opcodes.UTF8:
                    //already resolved
                    break;

                case Opcodes.HANDLE:
                    byte kind = Bytes[0];
                    ushort idx = DataReader.ReadUInt16(new[] {Bytes[1], Bytes[2]});
                    Value = _parent.Value(idx);
                    break;

                case Opcodes.STR:
                case Opcodes.MTYPE:
                case Opcodes.CLASS:
                    uint index = DataReader.ReadUInt16(Bytes);
                    Value = _parent.Value(index);
                    break;

                default:
                    Console.WriteLine("Unexpected Constant TAG " + Tag);
                    break;
            }
        }

        public void Write(DataWriter writer)
        {
            writer.Write(Bytes);
        }
    }
}