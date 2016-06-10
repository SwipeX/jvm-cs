using jvm_cs.io;

namespace jvm_cs.core.member
{
    public class ExceptionData
    {
        public ushort StartLocation { get; }
        public ushort EndLocation { get; }
        public ushort HandlerLocation { get; }
        public string CatchType { get; }

        public ExceptionData(ushort start, ushort end, ushort handler, string type)
        {
            StartLocation = start;
            EndLocation = end;
            HandlerLocation = handler;
            CatchType = type;
        }

        public static ExceptionData Read(DataReader reader, ConstantPool pool)
        {
            ushort[] data = {reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16()};
            return new ExceptionData(data[0], data[1], data[2], data[3] == 0 ? "0" : pool.Value(data[3]) as string);
        }
    }
}