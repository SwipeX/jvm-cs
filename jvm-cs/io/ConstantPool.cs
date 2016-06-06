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
                    case Opcodes.INTEGER:
                    case Opcodes.FLOAT:
                    case Opcodes.NAME_TYPE:
                    case Opcodes.INDY:
                        _entries[i] = new ConstantPoolEntry(i, tag,
                            reader.ReadBytes(4));
                        break;

                    case Opcodes.LONG:
                    case Opcodes.DOUBLE:
                        _entries[i] = new ConstantPoolEntry(i, tag,
                            reader.ReadBytes(8));
                        ++i;
                        break;

                    case Opcodes.UTF8:
                        _entries[i] = new ConstantPoolEntry(i, tag,
                            reader.ReadBytes(reader.ReadUInt16()));
                        break;

                    case Opcodes.HANDLE:
                        _entries[i] = new ConstantPoolEntry(i, tag,
                            reader.ReadBytes(3));
                        break;

                    case Opcodes.CLASS:
                    case Opcodes.MTYPE:
                    case Opcodes.STR:
                        _entries[i] = new ConstantPoolEntry(i, tag,
                            reader.ReadBytes(2));
                        break;

                    default:
                        Console.WriteLine("Unexpected tag: " + tag);
                        break;
                }
            }
            ResolveUtf8();
            for (int i = 1; i < _size; i++)
            {
                _entries[i].Resolve();
            }
        }


        public object Value(uint index)
        {
            if (index < _entries.Length)
            {
                if (_entries[index].Value == null)
                    _entries[index].Resolve();
                return _entries[index].Value;
            }
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