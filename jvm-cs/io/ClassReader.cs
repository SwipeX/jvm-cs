using System;
using System.Collections.Generic;
using System.IO;
using jvm_cs.core;
using jvm_cs.core.attribute;
using jvm_cs.core.member;
using Attribute = jvm_cs.core.attribute.Attribute;

namespace jvm_cs.io
{
    public class ClassReader
    {
        private byte[] _bytes;
        private List<string> _interfaces = new List<string>();
        private ConstantPool _constantPool;

        public ClassReader(string fileLocation)
        {
            _bytes = File.ReadAllBytes(fileLocation);
        }

        public ClassReader(byte[] bytes)
        {
            _bytes = bytes;
        }

        public ClassData Read()
        {
            DataReader reader = new DataReader(new MemoryStream(_bytes));
            uint magic = reader.ReadUInt32();
            if (magic != 0xCAFEBABE) {
                throw new InvalidDataException("Magic Number is incorrect.");
            }
            ushort minor = reader.ReadUInt16();
            ushort major = reader.ReadUInt16();
            ushort constantPoolSize = reader.ReadUInt16();
            _constantPool = new ConstantPool(constantPoolSize);
            _constantPool.Read(reader);
            ushort access = reader.ReadUInt16();
            string className = (string) _constantPool.Value(reader.ReadUInt16());
            string superName = (string) _constantPool.Value(reader.ReadUInt16());
            ushort interfaceCount = reader.ReadUInt16();
            for (int i = 0; i < interfaceCount; i++) {
                _interfaces.Add((string) _constantPool.Value(reader.ReadUInt16()));
            }

            ClassData classData = new ClassData(className, superName, access, _constantPool, _interfaces, _bytes);

            ushort fieldCount = reader.ReadUInt16();
            for (int i = 0; i < fieldCount; i++) {
                ushort accessFlags = reader.ReadUInt16();
                ushort nameIndex = reader.ReadUInt16();
                ushort descriptorIndex = reader.ReadUInt16();
                FieldData fieldData = new FieldData(_constantPool.Value(nameIndex) as string,
                    _constantPool.Value(descriptorIndex) as string, accessFlags, classData);
                ReadAttributes(fieldData, reader, _constantPool);
                classData.Fields.Add(fieldData);
            }

            ushort methodCount = reader.ReadUInt16();
            for (int i = 0; i < methodCount; i++) {
                ushort accessFlags = reader.ReadUInt16();
                ushort nameIndex = reader.ReadUInt16();
                ushort descriptorIndex = reader.ReadUInt16();
                MethodData methodData = new MethodData(_constantPool.Value(nameIndex) as string,
                    _constantPool.Value(descriptorIndex) as string, accessFlags, classData);
                ReadAttributes(methodData, reader, _constantPool);
                classData.Methods.Add(methodData);
            }
            ReadAttributes(classData, reader, _constantPool);
            reader.Close();
            return classData;
        }

        public static void ReadAttributes(MemberData owner, DataReader reader, ConstantPool pool)
        {
            ushort attributesCount = reader.ReadUInt16();
            for (int j = 0; j < attributesCount; j++) {
                string attributeName = ((string) pool.Value(reader.ReadUInt16())).Trim();
                uint attributeLength = reader.ReadUInt32();
                Attribute attribute = null;
                switch (attributeName) {
                    case "Exceptions":
                        attribute = new ExceptionsAttribute(attributeName, attributeLength, owner);
                        break;
                    case "Code":
                        attribute = new CodeAttribute(attributeName, attributeLength, owner);
                        break;
                    case "InnerClasses":
                        attribute = new InnerClassAttribute(attributeName, attributeLength, owner);
                        break;
                    case "ConstantValue":
                        attribute = new ConstantValueAttribute(attributeName, attributeLength, owner);
                        break;
                    case "EnclosingMethod":
                        attribute = new EnclosingMethodAttribute(attributeName, attributeLength, owner);
                        break;
                    case "Synthetic":
                        attribute = new SyntheticAttribute(attributeName, attributeLength, owner);
                        break;
                    case "Signature":
                        attribute = new SignatureAttribute(attributeName, attributeLength, owner);
                        break;
                    case "SourceFile":
                        attribute = new SourceFileAttribute(attributeName, attributeLength, owner);
                        break;
                    case "Deprecated":
                        attribute = new DeprecatedAttribute(attributeName, attributeLength, owner);
                        break;
                    case "RuntimeInvisibleAnnotations":
                        attribute = new RuntimeInvisibleAnnotationsAttribute(attributeName, attributeLength, owner);
                        break;
                    case "RuntimeVisibleAnnotations":
                        attribute = new RuntimeVisibleAnnotationsAttribute(attributeName, attributeLength, owner);
                        break;
                    case "RuntimeVisibleParameterAnnotations":
                        attribute = new RuntimeVisibleParameterAnnotations(attributeName, attributeLength, owner);
                        break;
                    case "RuntimeInvisibleParameterAnnotations":
                        attribute = new RuntimeInvisibleParameterAnnotations(attributeName, attributeLength, owner);
                        break;
                    default:
                        attribute = new Attribute(attributeName, attributeLength, owner);
                        break;
                }
                attribute.ReadBytes(reader);
                owner.Attributes.Add(attribute);
            }
        }
    }
}