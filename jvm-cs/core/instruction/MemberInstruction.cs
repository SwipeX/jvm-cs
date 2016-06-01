﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core.instruction
{
    public class MemberInstruction : Instruction
    {
        public string Owner;
        public string Name;
        public string Desc;

        public MemberInstruction(byte opcode, string owner, string name, string desc) : base(opcode)
        {
            this.Owner = owner;
            this.Name = name;
            this.Desc = desc;
        }
    }
}