﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jvm_cs.io;

namespace jvm_cs.core.instruction
{
    public class PushInstruction : Instruction
    {
        public int PushValue; //Bipush,Sipush,Newarray

        public PushInstruction(byte opcode, int index, int pushValue) : base(opcode, index)
        {
            PushValue = pushValue;
        }

        public override string ToString()
        {
            return base.ToString() + " " + PushValue;
        }

        public override void Write(DataWriter writer)
        {
            base.Write(writer);
            writer.Write(PushValue);
        }
    }
}