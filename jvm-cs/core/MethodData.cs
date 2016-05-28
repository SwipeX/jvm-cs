using jvm_cs.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.core.instruction;

namespace jvm_cs
{
    public class MethodData
    {
        public List<Attribute> Attributes { get; }
        public List<Instruction> Instructions { get; }
        public string Name { get; }
        public string Desc { get; }
        public ClassData Owner { get; }
        public int Access { get; set; }

        public int MaxStack;

        public int MaxLocals;

        public MethodData(string name, string desc, int access, ClassData owner)
        {
            Name = name;
            Desc = desc;
            Access = access;
            Owner = owner;
            Attributes = new List<Attribute>();
        }
    }
}