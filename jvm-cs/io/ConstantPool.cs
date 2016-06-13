using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jvm_cs.io
{
    public class ConstantPool
    {
        private ConstantPoolEntry[] _entries;
        private int _size;

        public ConstantPool(int size)
        {
            _size = size;
            _entries = new ConstantPoolEntry[_size];
        }

        public void Read(DataReader reader)
        {
            for (int i = 1; i < _size; i++) {
                byte tag = reader.ReadByte();
                switch (tag) {
                    case Opcodes.FIELD:
                    case Opcodes.METH:
                    case Opcodes.IMETH:
                    case Opcodes.INTEGER:
                    case Opcodes.FLOAT:
                    case Opcodes.NAME_TYPE:
                    case Opcodes.INVOKE_DYNAMIC:
                        _entries[i] = new ConstantPoolEntry(this, i, tag,
                            reader.ReadBytes(4));
                        break;

                    case Opcodes.LONG:
                    case Opcodes.DOUBLE:
                        _entries[i] = new ConstantPoolEntry(this, i, tag,
                            reader.ReadBytes(8));
                        i++;
                        _entries[i] = _entries[i - 1];
                        break;

                    case Opcodes.UTF8:
                        ushort length = reader.ReadUInt16();
                        byte[] bytes = reader.ReadBytes(length);
                        _entries[i] = new ConstantPoolEntry(this, i, tag,
                            Encoding.UTF8.GetString(bytes));
                        break;

                    case Opcodes.HANDLE:
                        _entries[i] = new ConstantPoolEntry(this, i, tag,
                            reader.ReadBytes(3));
                        break;

                    case Opcodes.CLASS:
                    case Opcodes.MTYPE:
                    case Opcodes.STR:
                        _entries[i] = new ConstantPoolEntry(this, i, tag,
                            reader.ReadBytes(2));
                        break;

                    default:
                        Console.WriteLine("Unexpected tag: " + tag);
                        break;
                }
            }
            for (int i = 1; i < _size; i++) {
                _entries[i].Resolve();
            }
        }

        public object Value(long index)
        {
            if (index <= 0 || index >= _size)
                throw new ArgumentException(index + " was requested, which is out of bounds");
            if (_entries[index].Value == null)
                _entries[index].Resolve();
            return _entries[index].Value;
        }

        public ushort IndexOf(object value)
        {
            var constantPoolEntry = _entries.FirstOrDefault(e => e != null && e.Value != null && e.Value.Equals(value));
            return (ushort) (constantPoolEntry?.Index ?? ushort.MaxValue);
        }

        public override string ToString()
        {
            return $"Entries: {_entries}, Size: {_size}";
        }

        public void Write(DataWriter writer)
        {
            writer.Write(_entries.Length);
            foreach (var constantPoolEntry in _entries) { constantPoolEntry.Write(writer); }
        }
    }
}