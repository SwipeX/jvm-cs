using jvm_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    internal static class Program
    {
        private static void Main()
        {
            new ClassReader(@"C:\Users\TimD\IdeaProjects\JINU\out\production\JINU\pw\dekk\Application.class").Read();
        }
    }
}