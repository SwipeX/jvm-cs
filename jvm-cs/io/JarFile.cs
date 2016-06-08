using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using jvm_cs.core;
using jvm_cs.core.storage;
using Test;

namespace jvm_cs
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
            foreach (ZipArchiveEntry entry in _archive.Entries) {
                var stream = entry.Open();
                byte[] bytes;
                using (var ms = new MemoryStream()) {
                    stream.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                ClassReader reader = new ClassReader(bytes);
                ClassData classData = reader.Read();
                ClassGroup.Classes.Add(classData.Name, classData);
            }
        }
    }
}