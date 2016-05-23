using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs
{
    public class ClassData
    {
        public List<Attribute> Attribues { get; }
        public List<FieldData> Fields { get; }
        public List<MethodData> Methods { get; }
        public List<string> Interfaces { get; }
        public ConstantPool Pool { get; }
        public int Access { get; }
        public string Name { get; }
        public string SuperName { get; }

        public byte[] Bytes { get; set; }

        public ClassData(string name, string supername, int access, ConstantPool constantPool, List<string> interfaces,
            byte[] bytes)
        {
            Name = name;
            SuperName = supername;
            Access = access;
            Pool = constantPool;
            Interfaces = interfaces;
            Fields = new List<FieldData>();
            Methods = new List<MethodData>();
            Bytes = bytes;
        }
    }
}