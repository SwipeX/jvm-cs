using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using jvm_cs.core;
using jvm_cs.core.member;
using jvm_cs.core.storage;

namespace jvm_cs.io
{
    public class JarFile
    {
        private readonly ZipArchive _archive;

        public JarFile(string filePath)
        {
            _archive = new ZipArchive(new FileStream(filePath, FileMode.Open), ZipArchiveMode.Read);
            ReadArchive();
        }

        private void ReadArchive()
        {
            List<Task> tasks = new List<Task>();
            long now = DateTime.Now.Ticks;
            foreach (ZipArchiveEntry entry in _archive.Entries)
            {
                if (!entry.Name.EndsWith(".class")) continue;
                var stream = entry.Open();
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                stream.Close();

                Task t = Task.Factory.StartNew(() =>
                {
                    ClassReader reader = new ClassReader(bytes);
                    ClassData classData = reader.Read();
                    ClassGroup.Classes.Add(classData.Name, classData);
                });
                tasks.Add(t);
            }
            tasks.RemoveAll(item => item == null);
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Read classes in " + (DateTime.Now.Ticks - now) / 10000);
        }
    }
}