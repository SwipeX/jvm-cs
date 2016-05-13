using jvm_cs;
using System;
using System.Collections.Generic;
using System.IO;
using Attribute = jvm_cs.Attribute;

namespace Test
{
    public class ClassReader
    {
        private string _fileLocation;
        private byte[] _bytes;
        private ushort _minor;
        private ushort _major;
        private string _className;
        private string _superName;
        private ushort _access;
        private List<string> interfaces = new List<string>();

        public ClassReader(string fileLocation)
        {
            _fileLocation = fileLocation;
            _bytes = File.ReadAllBytes(_fileLocation);
        }

        public ClassReader(byte[] bytes)
        {
            _bytes = bytes;
        }

        public void Read()
        {
            DataReader reader = new DataReader(new MemoryStream(_bytes));
            uint magic = reader.ReadUInt32();
            if (magic != 0xCAFEBABE)
            {
                throw new InvalidDataException("Magic Number is incorrect.");
            }
            _minor = reader.ReadUInt16();
            _major = reader.ReadUInt16();
            ushort constantPoolSize = reader.ReadUInt16();
            ConstantPool constantPool = new ConstantPool(constantPoolSize);
            constantPool.Read(reader);
            constantPool.Resolve();
            _access = reader.ReadUInt16();
            _className = (string)constantPool.Value(reader.ReadUInt16());
            _superName = (string)constantPool.Value(reader.ReadUInt16());
            ushort interfaceCount = reader.ReadUInt16();
            for (int i = 0; i < interfaceCount; i++)
            {
                interfaces.Add((string)constantPool.Value(reader.ReadUInt16()));
            }
            ushort fieldCount = reader.ReadUInt16();
            for (int i = 0; i < fieldCount; i++)
            {
                ushort accessFlags = reader.ReadUInt16();
                ushort nameIndex = reader.ReadUInt16();
                ushort descriptorIndex = reader.ReadUInt16();
                ushort attributesCount = reader.ReadUInt16();
                for (int j = 0; j < attributesCount; j++)
                {
                    string attributeName = (string)constantPool.Value(reader.ReadUInt16());
                    uint attributeLength = reader.ReadUInt32();
                    Attribute attribute = new Attribute(attributeName, attributeLength);
                    attribute.readBytes(reader);
                }
            }
            ushort methodCount = reader.ReadUInt16();
            for (int i = 0; i < methodCount; i++)
            {
                ushort accessFlags = reader.ReadUInt16();
                ushort nameIndex = reader.ReadUInt16();
                ushort descriptorIndex = reader.ReadUInt16();
                Console.WriteLine(constantPool.Value(nameIndex) + " " + constantPool.Value(descriptorIndex));
                ushort attributesCount = reader.ReadUInt16();
                for (int j = 0; j < attributesCount; j++)
                {
                    string attributeName = (string)constantPool.Value(reader.ReadUInt16());
                    uint attributeLength = reader.ReadUInt32();
                    Attribute attribute = new Attribute(attributeName, attributeLength);
                    attribute.readBytes(reader);
                }
            }
        }
    }
}