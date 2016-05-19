﻿using System;
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

        public void readBytes(DataReader reader)
        {
            switch (_name)
            {
                case "Code":
                    ushort maxStack = reader.ReadUInt16();
                    ushort maxLocals = reader.ReadUInt16();
                    uint codeLength = reader.ReadUInt32();
                    byte[] code = reader.ReadBytes((int)codeLength);
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
                    break;

                default:
                    reader.ReadBytes((int)_length);
                    break;
            }
        }
    }
}