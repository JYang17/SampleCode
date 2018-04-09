///////////////////////////////////////////////////////
//                  Console Attacher
//                   Version 1.0
//               Powered by nankezhishi
//                nankezhishi@gmail.com
///////////////////////////////////////////////////////

using System.Runtime.InteropServices;

namespace WpfConsole
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleAttacher
    {
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// 
        /// </summary>
        public static void AttachParentConsole()
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
        }

        [DllImport("Kernel32.dll", EntryPoint = "AttachConsole", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void AttachConsole(int dwProcessId);
    }
}
