using System;
using System.Linq;
using System.Text;

namespace jvm_cs.io
{
    public class ConstantPool
    {
        private static ConstantPoolEntry[] _entries;
        private static int _size;
        public static ConstantPool Instance { get; private set; }

        public ConstantPool(int size)
        {
            Instance = this;
            _size = size;
            _entries = new ConstantPoolEntry[_size];
            _entries[0] = new ConstantPoolEntry(-1, 0, null);
        }

        public static bool HasEntries()
        {
            return _entries != null && _entries.Length > 0;
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
                        _entries[i] = new ConstantPoolEntry((int)reader.BaseStream.Position, tag,
                            reader.ReadBytes(4));
                        break;

                    case Opcodes.LONG:
                    case Opcodes.DOUBLE:
                        _entries[i] = new ConstantPoolEntry((int)reader.BaseStream.Position, tag,
                            reader.ReadBytes(8));
                        ++i;
                        break;

                    case Opcodes.UTF8:
                        _entries[i] = new ConstantPoolEntry((int)reader.BaseStream.Position, tag,
                            reader.ReadBytes(reader.ReadUInt16()));
                        break;

                    case Opcodes.HANDLE:
                        _entries[i] = new ConstantPoolEntry((int)reader.BaseStream.Position, tag,
                            reader.ReadBytes(3));
                        break;

                    default:
                        _entries[i] = new ConstantPoolEntry((int)reader.BaseStream.Position, tag,
                            reader.ReadBytes(2));
                        break;
                }
            }
        }

        public void Resolve()
        {
            ResolveUtf8();
            int x = 0;
            foreach (ConstantPoolEntry cpe in _entries)
            {
                if (cpe == null || cpe.Index < 0) continue;
                switch (cpe.Tag)
                {
                    case Opcodes.NAME_TYPE:
                    case Opcodes.IMETH:
                    case Opcodes.METH:
                    case Opcodes.FIELD:
                        uint index1 = DataReader.ReadUInt16(new[] { cpe.Bytes[0], cpe.Bytes[1] });
                        uint index2 = DataReader.ReadUInt16(new[] { cpe.Bytes[2], cpe.Bytes[3] });
                        string className = (string)Value(index1);
                        string nameType = (string)Value(index2);
                        cpe.Value = className + "." + nameType;
                        break;

                    case Opcodes.INDY:
                        //bootstrap_method_attr_index???
                        uint i = DataReader.ReadUInt16(new[] { cpe.Bytes[2], cpe.Bytes[3] });
                        cpe.Value = Value(i);
                        break;

                    case Opcodes.INT:
                        cpe.Value = DataReader.ReadUInt32(cpe.Bytes);
                        break;

                    case Opcodes.FLOAT:
                        cpe.Value = DataReader.ReadSingle(cpe.Bytes);
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
                        byte kind = cpe.Bytes[0];
                        ushort idx = DataReader.ReadUInt16(new[] { cpe.Bytes[1], cpe.Bytes[2] });
                        cpe.Value = Value(idx);
                        break;

                    case Opcodes.STR:
                    case Opcodes.MTYPE:
                    case Opcodes.CLASS:
                        uint index = DataReader.ReadUInt16(cpe.Bytes);
                        cpe.Value = Value(index);
                        break;
                }
                Console.WriteLine(x++ + " : " + cpe.Tag + " " + cpe.Value);
            }
        }

        public object Value(uint index)
        {
            if (index < _entries.Length)
                return _entries[index].Value;
            else
            {
                Console.WriteLine(index + " requested OOB");
                return "";
            }
        }

        private void ResolveUtf8()
        {
            foreach (ConstantPoolEntry cpe in _entries.Where(cpe => cpe != null && cpe.Tag == Opcodes.UTF8))
            {
                cpe.Value = Encoding.UTF8.GetString(cpe.Bytes);
            }
        }
    }
}