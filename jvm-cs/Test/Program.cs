﻿using System;
using jvm_cs.io;

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
                 new JarFile(@"C:\Users\TimD\Downloads\gp.jar");
         //   ClassReader reader = new ClassReader(@"C:\Users\TimD\IdeaProjects\Test\out\production\Test\Test.class");
        //    byte[] b = ClassWriter.Write(reader.Read());
         //   ClassReader reader2 = new ClassReader(b);
          //  reader2.Read();
//               // new ClassReader(@"C:\Users\TimD\Desktop\Boot.class");
//            ClassData data = reader.Read();
//            foreach (MethodData md in data.Methods)
//            {
//                Console.WriteLine(md.Name);
//                List<Instruction> instructions = md.Instructions;
//                if (instructions == null) continue;
//                foreach (Instruction instruction in instructions)
//                {
//                    Console.WriteLine("     " + instruction);
//                }
//            }
        }
    }
}