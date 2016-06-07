using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.io;

namespace jvm_cs
{
    public class ConstantPoolEntry
    {
        public int Index { get; }
        public byte Tag { get; set; }
        public byte[] Bytes { get; set; }
        public dynamic Value { get; set; }

        public ConstantPoolEntry(int index, byte tag, byte[] value)
        {
            Index = index;
            Tag = tag;
            Bytes = value;
        }

        public void Resolve()
        {
            switch (Tag)
            {
                case Opcodes.NAME_TYPE:
                    uint k = DataReader.ReadUInt16(new[] {Bytes[0], Bytes[1]});
                    uint j = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
                    string data = (string) ConstantPool.Instance.Value(k);
                    string desc = (string) ConstantPool.Instance.Value(j);
                    Value = new string[] {data, desc};
                    break;
                case Opcodes.IMETH:
                case Opcodes.METH:
                case Opcodes.FIELD:
                    uint classIndex = DataReader.ReadUInt16(new[] {Bytes[0], Bytes[1]});
                    uint nameTypeIndex = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
                    string className = (string) ConstantPool.Instance.Value(classIndex);
                    string[] nameType = (string[]) ConstantPool.Instance.Value(nameTypeIndex);
                    Value = new string[] {className, nameType[0], nameType[1]};
                    break;

                case Opcodes.INDY:
                    //bootstrap_method_attr_index???
                    uint i = DataReader.ReadUInt16(new[] {Bytes[2], Bytes[3]});
                    Value = ConstantPool.Instance.Value(i);
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
                    Value = ConstantPool.Instance.Value(idx);
                    break;

                case Opcodes.STR:
                case Opcodes.MTYPE:
                case Opcodes.CLASS:
                    uint index = DataReader.ReadUInt16(Bytes);
                    Value = ConstantPool.Instance.Value(index);
                    break;

                default:
                    Console.WriteLine("Unexpected Constant TAG");
                    break;
            }
//            if (Value is string[])
//            {
//                string[] a = Value as string[];
//                if (a.Length == 3)
//                    Console.WriteLine(Index + ": " + Tag + " : " + a[0] + " " + a[1] + " " + a[2]);
//                else
//                    Console.WriteLine(Index + ": " + Tag + " : " + a[0] + " " + a[1]);
//            }
//            else
//                Console.WriteLine(Index + ": " + Tag + " : " + Value);
        }
    }
}