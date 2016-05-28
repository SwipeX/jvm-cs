using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs.core
{
        public class InnerClassData
        {
            public String Name;
            public String OuterName;
            public String InnerName;
            public int Access;
        
            public InnerClassData(string name, string outerName,
                     string innerName,  int access)
            {
                this.Name = name;
                this.OuterName = outerName;
                this.InnerName = innerName;
                this.Access = access;
            }
    }
}
