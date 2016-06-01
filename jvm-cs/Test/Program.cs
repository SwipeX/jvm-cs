using jvm_cs;
using jvm_cs.core.instruction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ClassReader reader =
                new ClassReader(@"C:\Users\TimD\IdeaProjects\JINU\out\production\JINU\pw\dekk\Application.class");
            ClassData data = reader.Read();
            foreach (MethodData md in data.Methods)
            {
                Console.WriteLine(md.Name);
                List<Instruction> instructions = md.Instructions;
                if (instructions == null) continue;
                foreach (Instruction instruction in instructions)
                {
                    Console.WriteLine("     " + instruction.GetType().Name);
                }
            }
        }
    }
}