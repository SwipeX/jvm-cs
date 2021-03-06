﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.core.member;

namespace jvm_cs.core.instruction
{
    public class MemberInstruction : Instruction
    {
        public MethodData Parent { get; }
        public string Owner;
        public string Name;
        public string Desc;

        public MemberInstruction(byte opcode, int index, string owner, string name, string desc, MethodData parent) : base(opcode, index)
        {
            this.Owner = owner;
            this.Name = name;
            this.Desc = desc;
            Parent = parent;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Owner + "." + Name + " " + Desc;
        }
    }
}