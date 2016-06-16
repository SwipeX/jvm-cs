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

        public ConstantPoolEntry(ConstantPool parent, int index, byte tag, dynamic value, byte[] b)
        {
            _parent = parent;
            Index = index;
            Tag = tag;
            Value = value;
            Bytes = b;
        }

        public void Resolve()
        {
            switch (Tag) {
                case Opcodes.NAME_TYPE:
                    uint k = DataReader.ReadUInt16(new[] {Bytes[0], Bytes[1]});
                    uint j = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
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

        public byte[] Dissolve()
        {
            switch (Tag) {
                case Opcodes.NAME_TYPE:
                    string[] val = Value;
                    return new byte[] {(byte) _parent.IndexOf(val[0]), (byte) _parent.IndexOf(val[1])};
                case Opcodes.IMETH:
                case Opcodes.METH:
                case Opcodes.FIELD:
                    string[] data = Value;
                    byte zero = (byte) _parent.IndexOf(data[0]);
                    byte one = (byte) _parent.IndexOf(new string[] {data[1], data[2]});
                    return new byte[] {zero, one};
                case Opcodes.INVOKE_DYNAMIC://TODO add support
                    return Bytes;
                case Opcodes.INTEGER:
                    return DataWriter.UInt16(Value);
                case Opcodes.FLOAT:
                    return BitConverter.GetBytes(Value);
                case Opcodes.LONG:
                    return DataWriter.UInt64(Value);
                case Opcodes.DOUBLE:
                    return BitConverter.GetBytes(Value);
                case Opcodes.UTF8:
                    return _parent.IndexOf(Value, Opcodes.UTF8);
                case Opcodes.HANDLE:
                    return Bytes;//TODO add support
                case Opcodes.STR:
                    return _parent.IndexOf(Value, Opcodes.STR);
                case Opcodes.MTYPE:
                    return _parent.IndexOf(Value, Opcodes.MTYPE);
                case Opcodes.CLASS:
                    return _parent.IndexOf(Value, Opcodes.CLASS);
                default:
                    Console.WriteLine("Unexpected Constant TAG " + Tag);
                    return new byte[] {0};
            }
        }

        public void Write(DataWriter writer)
        {
            writer.Write(Tag);
            writer.Write(Dissolve());
        }
    }
}