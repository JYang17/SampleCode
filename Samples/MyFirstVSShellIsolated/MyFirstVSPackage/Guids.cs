// Guids.cs
// MUST match guids.h
using System;

namespace Microsoft.MyFirstVSPackage
{
    static class GuidList
    {
        public const string guidMyFirstVSPackagePkgString = "65617004-5ea4-454e-a4c0-7e8fe386ea87";
        public const string guidMyFirstVSPackageCmdSetString = "8176e2ad-f681-4b51-9b76-311e70a3316d";

        public static readonly Guid guidMyFirstVSPackageCmdSet = new Guid(guidMyFirstVSPackageCmdSetString);
    };
}