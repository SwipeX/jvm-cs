using System;
using System.IO;
using System.Linq;

namespace jvm_cs.io
{
    public class DataWriter : BinaryWriter
    {
        public DataWriter(Stream output) : base(output)
        {
        }


        public override void Write(double num)
        {
            base.Write((byte[]) BitConverter.GetBytes(num).Reverse());
        }

        public override void Write(float num)
        {
            base.Write((byte[]) BitConverter.GetBytes(num).Reverse());
        }

        public override void Write(short num)
        {
            base.Write(new byte[] {(byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public override void Write(ushort num)
        {
            base.Write(new byte[] {(byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public override void Write(uint num)
        {
            base.Write(new byte[] {(byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public override void Write(int num)
        {
            base.Write(new byte[] {(byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public override void Write(ulong num)
        {
            base.Write(new byte[]
            {
                (byte) (num >> 48 & 0xFF), (byte) (num >> 42 & 0xFF), (byte) (num >> 36 & 0xFF), (byte) (num >> 30 & 0xFF),
                (byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)
            });
        }

        public override void Write(long num)
        {
            base.Write(new byte[]
            {
                (byte) (num >> 48 & 0xFF), (byte) (num >> 42 & 0xFF), (byte) (num >> 36 & 0xFF), (byte) (num >> 30 & 0xFF),
                (byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)
            });
        }
    }
}