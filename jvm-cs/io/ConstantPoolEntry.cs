using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs
{
    public class ConstantPoolEntry
    {
        public int Index { get; }
        public byte Tag { get; set; }
        public byte[] Bytes { get; set; }
        public object Value { get; set; }

        public ConstantPoolEntry(int index, byte tag, byte[] value)
        {
            Index = index;
            Tag = tag;
            Bytes = value;
        }
    }
}