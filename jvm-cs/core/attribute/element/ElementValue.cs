using System;

namespace jvm_cs.core.attribute.element
{
    public abstract class ElementValue
    {
        public const char BYTE_TAG = 'B';
        public const char CHAR_TAG = 'C';
        public const char DOUBLE_TAG = 'D';
        public const char FLOAT_TAG = 'F';
        public const char INT_TAG = 'I';
        public const char LONG_TAG = 'J';
        public const char SHORT_TAG = 'S';
        public const char BOOL_TAG = 'Z';
        public const char STRING_TAG = 's';
        public const char ENUM_TAG = 'e';
        public const char CLASS_TAG = 'c';
        public const char ARRAY_TAG = '[';
        public const char ANNOTATION_TAG = '@';
        public char Tag { get; }
        protected DataReader Reader;

        protected ElementValue(char tag, DataReader reader)
        {
            Tag = tag;
            Reader = reader;
            Read(reader);
        }

        public static ElementValue GetElementValue(DataReader reader)
        {
            char tag = reader.ReadChar();
            switch (tag) {
                case ElementValue.CLASS_TAG:
                    return new ClassElementValue(tag, reader);
                case ElementValue.ENUM_TAG:
                    return new EnumElementValue(tag, reader);
                case ElementValue.ANNOTATION_TAG:
                    return new AnnotationElementValue(tag, reader);
                case ElementValue.ARRAY_TAG:
                    return new AnnotationElementValue(tag, reader);
                default:
                    return new ConstantElementValue(tag, reader);
            }
        }

        public abstract void Read(DataReader reader);
    }
}