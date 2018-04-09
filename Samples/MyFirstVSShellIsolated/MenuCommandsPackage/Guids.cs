// Guids.cs
// MUST match guids.h
using System;

namespace Fabrikam.MenuCommandsPackage
{
    static class GuidList
    {
        public const string guidMenuCommandsPackagePkgString = "0dcddf16-789b-4f81-bb31-ff766cbefaf5";
        public const string guidMenuCommandsPackageCmdSetString = "dfef4ebd-19c6-4881-8449-470a315b8c13";

        public static readonly Guid guidMenuCommandsPackageCmdSet = new Guid(guidMenuCommandsPackageCmdSetString);
    };
}