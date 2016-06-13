using System.IO;
using jvm_cs.core;

namespace jvm_cs.io
{
    public class ClassWriter
    {
        public const uint Magic = 0xCAFEBABE;

        public static byte[] Write(ClassData classData)
        {
            MemoryStream stream = new MemoryStream();
            DataWriter writer = new DataWriter(stream);
            ConstantPool pool = classData.Pool;
            writer.WriteUInt32(Magic);
            writer.WriteUInt16(classData.MinorVersion);
            writer.WriteUInt16(classData.MajorVersion);
            pool.Write(writer);
            writer.WriteUInt16((ushort) classData.Access);
            writer.WriteUInt16(pool.IndexOf(classData.Name));
            writer.WriteUInt16(pool.IndexOf(classData.SuperName));
            classData.Interfaces.ForEach(i => writer.WriteUInt16(pool.IndexOf(i)));
            //fields
            //methods
            //attributes
            return stream.GetBuffer();
        }
    }
}