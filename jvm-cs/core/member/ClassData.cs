using System.Collections.Generic;
using jvm_cs.core.attribute;
using jvm_cs.core.member;
using jvm_cs.core.storage;
using jvm_cs.io;
using jvm_cs.visitor;

namespace jvm_cs.core
{
    public class ClassData : MemberData
    {
        public List<FieldData> Fields { get; }
        public List<MethodData> Methods { get; }
        public List<string> Interfaces { get; }
        public List<InnerClassData> InnerClasses { get; }
        public ConstantPool Pool { get; }
        public string SuperName { get; }
        public byte[] Bytes { get; set; }

        public ClassData(string name, string supername, int access, ConstantPool constantPool, List<string> interfaces,
            byte[] bytes) : base(name, access)
        {
            SuperName = supername;
            Pool = constantPool;
            Interfaces = interfaces;
            Fields = new List<FieldData>();
            Methods = new List<MethodData>();
            InnerClasses = new List<InnerClassData>();
            Bytes = bytes;
        }

        public ClassData SuperClass()
        {
            ClassData super;
            if (Utilities.SystemClass(SuperName))
                return null;
            return !ClassGroup.Classes.TryGetValue(SuperName, out super) ? null : super;
        }

        public override string ToString()
        {
            return Name;
        }

        public void Visit(ClassVisitor visitor)
        {
            visitor.VisitClass(Access, Name, SuperName, Interfaces);
            Attributes.ForEach(visitor.VisitAttribute);
            Fields.ForEach(visitor.VisitField);
            Methods.ForEach(visitor.VisitMethod);
            InnerClasses.ForEach(visitor.VisitInnerClass);
            visitor.CompleteVisit();
        }
    }
}