// Guids.cs
// MUST match guids.h
using System;

namespace VSShellHideDebugLocation.AboutBoxPackage
{
    static class GuidList
    {
        public const string guidAboutBoxPackagePkgString = "e4e629ec-afe2-45c6-a7d2-52d1050f5c91";
        public const string guidAboutBoxPackageCmdSetString = "1853293a-b060-4dce-adbd-4d54aa37f233";

        public static readonly Guid guidAboutBoxPackageCmdSet = new Guid(guidAboutBoxPackageCmdSetString);
    };
}