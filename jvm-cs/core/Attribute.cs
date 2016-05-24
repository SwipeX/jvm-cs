using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs
{
    public class Attribute
    {
        private string _name;
        private uint _length;
        private byte[] _bytes;

        public Attribute(string name, uint length)
        {
            _name = name;
            _length = length;
        }

        public void ReadBytes(DataReader reader)
        {
            switch (_name)
            {
                default:
                    reader.ReadBytes((int)_length);
                    break;
            }
        }

        public string Name()
        {
            return _name;
        }
    }
}