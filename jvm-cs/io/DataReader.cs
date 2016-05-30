using System;
using System.IO;
using System.Linq;
using System.Text;

namespace jvm_cs
{
    /*
     * Note: this class uses Big-Endian instead of Little-Endian
     */

    public class DataReader : BinaryReader
    {
        public DataReader(Stream input) : base(input)
        {
        }

        public DataReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public DataReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public override ulong ReadUInt64()
        {
            return ReadUInt64(ReadBytes(8));
        }

        public static ulong ReadUInt64(byte[] buffer)
        {
            return (ulong)((buffer[0] << 48) | (buffer[1] << 42) | (buffer[2] << 36)
                            | (buffer[3] << 30) | (buffer[4] << 24) | (buffer[5] << 16) | (buffer[6] << 8) | buffer[7]);
        }

        public override uint ReadUInt32()
        {
            return ReadUInt32(ReadBytes(4));
        }

        public static uint ReadUInt32(byte[] buffer)
        {
            return (uint)((buffer[0] << 24) | (buffer[1] << 16) | (buffer[2] << 8) | buffer[3]);
        }

        public override ushort ReadUInt16()
        {
            return ReadUInt16(ReadBytes(2));
        }

        public static ushort ReadUInt16(byte[] buffer)
        {
            return (ushort)((buffer[0] << 8) | buffer[1]);
        }

        public static ushort ReadInt16(byte[] buffer)
        {
            return (ushort)((buffer[1] << 8) | buffer[0]);
        }
        public static float ReadSingle(byte[] buffer)
        {
            return BitConverter.ToSingle(buffer, 0);
        }

        public static Double ReadDouble(byte[] buffer)
        {
            return BitConverter.ToDouble(buffer, 0);
        }

        public override Double ReadDouble()
        {
            return ReadDouble(ReadBytes(8).Reverse().ToArray());
        }

        public override float ReadSingle()
        {
            return ReadSingle(ReadBytes(4).Reverse().ToArray());
        }
    }
}