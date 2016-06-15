using System.IO;
using jvm_cs.core;
using jvm_cs.core.member;

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
            writer.WriteUInt16(pool.IndexOf(classData.Name, Opcodes.CLASS));
            writer.WriteUInt16(pool.IndexOf(classData.SuperName, Opcodes.CLASS));
            writer.WriteUInt16((ushort) classData.Interfaces.Count);
            classData.Interfaces.ForEach(i => writer.WriteUInt16(pool.IndexOf(i, Opcodes.CLASS)));
            writer.WriteUInt16((ushort) classData.Fields.Count);
            classData.Fields.ForEach(f => f.Write(writer));
            writer.WriteUInt16((ushort) classData.Methods.Count);
            classData.Methods.ForEach(m => m.Write(writer));
            writer.WriteUInt16((ushort) classData.Attributes.Count);
            classData.Attributes.ForEach(a => a.Write(writer));
            return stream.GetBuffer();
        }

        public static void Write(ClassData classData, string path)
        {
            byte[] bytes = Write(classData);
            BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create));
            writer.Write(bytes);
            writer.Close();
        }
    }
}