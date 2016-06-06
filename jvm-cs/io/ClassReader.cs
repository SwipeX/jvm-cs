using jvm_cs;
using jvm_cs.core;
using jvm_cs.io;
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

        public ClassData Read()
        {
            DataReader reader = new DataReader(new MemoryStream(_bytes));
            uint magic = reader.ReadUInt32();
            if (magic != 0xCAFEBABE)
            {
                throw new InvalidDataException("Magic Number is incorrect.");
            }
            ushort minor = reader.ReadUInt16();
            ushort major = reader.ReadUInt16();
            ushort constantPoolSize = reader.ReadUInt16();
            Console.WriteLine(constantPoolSize);
            ConstantPool constantPool = new ConstantPool(constantPoolSize);
            constantPool.Read(reader);
            ushort access = reader.ReadUInt16();
            string className = (string)constantPool.Value(reader.ReadUInt16());
            string superName = (string)constantPool.Value(reader.ReadUInt16());
            ushort interfaceCount = reader.ReadUInt16();
            for (int i = 0; i < interfaceCount; i++)
            {
                interfaces.Add((string)constantPool.Value(reader.ReadUInt16()));
            }

            ClassData classData = new ClassData(className, superName, access, constantPool, interfaces, _bytes);

            ushort fieldCount = reader.ReadUInt16();
            for (int i = 0; i < fieldCount; i++)
            {
                ushort accessFlags = reader.ReadUInt16();
                ushort nameIndex = reader.ReadUInt16();
                ushort descriptorIndex = reader.ReadUInt16();
                FieldData fieldData = new FieldData(constantPool.Value(nameIndex) as string,
                    constantPool.Value(descriptorIndex) as string, accessFlags, classData);
                ushort attributesCount = reader.ReadUInt16();
                for (int j = 0; j < attributesCount; j++)
                {
                    string attributeName = (string)constantPool.Value(reader.ReadUInt16());
                    uint attributeLength = reader.ReadUInt32();
                    Attribute attribute = new Attribute(attributeName, attributeLength);
                    attribute.ReadBytes(reader);
                    fieldData.Attributes.Add(attribute);
                }
                classData.Fields.Add(fieldData);
            }

            ushort methodCount = reader.ReadUInt16();
            for (int i = 0; i < methodCount; i++)
            {
                ushort accessFlags = reader.ReadUInt16();
                ushort nameIndex = reader.ReadUInt16();
                ushort descriptorIndex = reader.ReadUInt16();
                MethodData methodData = new MethodData(constantPool.Value(nameIndex) as string,
                    constantPool.Value(descriptorIndex) as string, accessFlags, classData);
                ushort attributesCount = reader.ReadUInt16();
                for (int j = 0; j < attributesCount; j++)
                {
                    string attributeName = ((string)constantPool.Value(reader.ReadUInt16())).Trim();
                    uint attributeLength = reader.ReadUInt32();
                    Attribute attribute = attributeName.Equals("Code")
                        ? new CodeAttribute(attributeName, attributeLength, methodData)
                        : new Attribute(attributeName, attributeLength);
                    attribute.ReadBytes(reader);
                    methodData.Attributes.Add(attribute);
                }
                classData.Methods.Add(methodData);
            }

            ushort attributeCount = reader.ReadUInt16();
            for (int i = 0; i < attributeCount; i++)
            {
                string attributeName = (string)constantPool.Value(reader.ReadUInt16());
                uint attributeLength = reader.ReadUInt32();
                Attribute attribute = new Attribute(attributeName, attributeLength);
                attribute.ReadBytes(reader);
                classData.Attribues.Add(attribute);
            }
            return classData;
        }
    }
}