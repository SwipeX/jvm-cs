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

        public void WriteDouble(double num)
        {
            base.Write((byte[]) BitConverter.GetBytes(num).Reverse());
        }

        public void WriteFloat(float num)
        {
            base.Write((byte[]) BitConverter.GetBytes(num).Reverse());
        }

        public void WriteInt16(short num)
        {
            base.Write(new byte[] {(byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public void WriteUInt16(ushort num)
        {
            base.Write(new byte[] {(byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public static byte[] UInt16(ushort num)
        {
            return new byte[] {(byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)};
        }

        public void WriteUInt32(uint num)
        {
            base.Write(new byte[] {(byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public void WriteInt32(int num)
        {
            base.Write(new byte[] {(byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)});
        }

        public void WriteUInt64(ulong num)
        {
            base.Write(new byte[]
            {
                (byte) (num >> 48 & 0xFF), (byte) (num >> 42 & 0xFF), (byte) (num >> 36 & 0xFF), (byte) (num >> 30 & 0xFF),
                (byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)
            });
        }

        public static byte[] UInt64(ulong num)
        {
            return new byte[]
            {
                (byte) (num >> 48 & 0xFF), (byte) (num >> 42 & 0xFF), (byte) (num >> 36 & 0xFF), (byte) (num >> 30 & 0xFF),
                (byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)
            };
        }

        public void WriteInt64(long num)
        {
            base.Write(new byte[]
            {
                (byte) (num >> 48 & 0xFF), (byte) (num >> 42 & 0xFF), (byte) (num >> 36 & 0xFF), (byte) (num >> 30 & 0xFF),
                (byte) (num >> 24 & 0xFF), (byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF)
            });
        }
    }
}