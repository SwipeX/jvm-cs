using System;
using System.Linq;

namespace jvm_cs.core
{
    public static class Utilities
    {
        private static readonly string[] SystemPackages =
        {
            @"java.lang.",
            @"java.",
            @"javax.",
            @"com.sun.",
            @"com.oracle."
        };

        public static bool SystemClass(string className)
        {
            return SystemPackages.Any(className.StartsWith);
        }
    };
}