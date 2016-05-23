using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs
{
    public class ConstantPool
    {
        private ConstantPoolEntry[] _entries;
        private int _size;

        public ConstantPool(int size)
        {
            _size = size;
            _entries = new ConstantPoolEntry[_size];
            _entries[0] = new ConstantPoolEntry(-1, 0, null);
        }

        public void Read(DataReader reader)
        {
            for (int i = 1; i < _size; i++)
            {
                byte tag = reader.ReadByte();
                switch (tag)
                {
                    case Opcodes.FIELD:
                    case Opcodes.METH:
                    case Opcodes.IMETH:
                    case Opcodes.INT:
                    case Opcodes.FLOAT:
                    case Opcodes.NAME_TYPE:
                    case Opcodes.INDY:
                        _entries[i] = new ConstantPoolEntry((int) reader.BaseStream.Position, tag, reader.ReadBytes(4));
                        break;

                    case Opcodes.LONG:
                    case Opcodes.DOUBLE:
                        _entries[i] = new ConstantPoolEntry((int) reader.BaseStream.Position, tag, reader.ReadBytes(8));
                        ++i;
                        break;

                    case Opcodes.UTF8:
                        _entries[i] = new ConstantPoolEntry((int) reader.BaseStream.Position, tag,
                            reader.ReadBytes(reader.ReadUInt16()));
                        break;

                    case Opcodes.HANDLE:
                        _entries[i] = new ConstantPoolEntry((int) reader.BaseStream.Position, tag, reader.ReadBytes(3));
                        break;

                    default:
                        _entries[i] = new ConstantPoolEntry((int) reader.BaseStream.Position, tag, reader.ReadBytes(2));
                        break;
                }
            }
        }

        public void Resolve()
        {
            ResolveUtf8();
            foreach (ConstantPoolEntry cpe in _entries)
            {
                switch (cpe.Tag)
                {
                    case Opcodes.NAME_TYPE:
                    case Opcodes.IMETH:
                    case Opcodes.METH:
                    case Opcodes.FIELD:
                        uint index1 = DataReader.ReadUInt16(new[] {cpe.Bytes[0], cpe.Bytes[1]});
                        uint index2 = DataReader.ReadUInt16(new[] {cpe.Bytes[2], cpe.Bytes[3]});
                        string Class = (string) Value(index1);
                        string desc = (string) Value(index2);
                        cpe.Value = Class + "." + desc;
                        break;

                    case Opcodes.INT:
                        cpe.Value = DataReader.ReadUInt32(cpe.Bytes);
                        break;

                    case Opcodes.FLOAT:
                        cpe.Value = DataReader.ReadSingle(cpe.Bytes);
                        break;

                    case Opcodes.INDY:
                        break;

                    case Opcodes.LONG:
                        cpe.Value = DataReader.ReadUInt64(cpe.Bytes);
                        break;

                    case Opcodes.DOUBLE:
                        cpe.Value = DataReader.ReadDouble(cpe.Bytes);
                        break;

                    case Opcodes.UTF8:
                        //already resolved
                        break;

                    case Opcodes.HANDLE:
                        byte a = cpe.Bytes[0];
                        ushort b = DataReader.ReadUInt16(new[] {cpe.Bytes[1], cpe.Bytes[2]});
                        cpe.Value = new int[] {a, b};
                        break;

                    case Opcodes.CLASS:
                        uint index = DataReader.ReadUInt16(cpe.Bytes);
                        cpe.Value = Value(index);
                        break;
                }
            }
        }

        public object Value(uint index)
        {
            return _entries[index].Value;
        }

        private void ResolveUtf8()
        {
            foreach (ConstantPoolEntry cpe in _entries)
            {
                if (cpe.Tag != Opcodes.UTF8) continue;
                cpe.Value = Encoding.UTF8.GetString(cpe.Bytes);
            }
        }
    }
}