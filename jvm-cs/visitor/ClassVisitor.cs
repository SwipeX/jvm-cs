using System;
using System.Collections.Generic;
using jvm_cs.core.member;
using Attribute = jvm_cs.core.attribute.Attribute;

namespace jvm_cs.visitor
{
    public class ClassVisitor
    {
        public void VisitClass(int access, string name, string superName, List<string> interfaces)
        {
        }

        public void VisitInnerClass(InnerClassData data)
        {
        }

        public void VisitAttribute(Attribute attr)
        {
        }

        public void VisitField(FieldData field)
        {
        }

        public void VisitMethod(MethodData method)
        {
        }

        public void CompleteVisit()
        {
        }
    }
}