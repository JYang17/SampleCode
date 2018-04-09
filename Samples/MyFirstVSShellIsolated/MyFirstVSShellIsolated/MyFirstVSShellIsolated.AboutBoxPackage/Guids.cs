// Guids.cs
// MUST match guids.h
using System;

namespace MyFirstVSShellIsolated.AboutBoxPackage
{
    static class GuidList
    {
        public const string guidAboutBoxPackagePkgString = "ba8147b5-f495-401e-978a-4fded993353c";
        public const string guidAboutBoxPackageCmdSetString = "d73c844f-e40e-42ae-8459-fad5c2905a13";

        public static readonly Guid guidAboutBoxPackageCmdSet = new Guid(guidAboutBoxPackageCmdSetString);
    };
}