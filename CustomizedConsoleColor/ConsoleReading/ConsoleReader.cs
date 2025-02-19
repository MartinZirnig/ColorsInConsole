using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedConsoleColor.Imports
{
    internal static class ConsoleReader
    {
        public const int COUT_HANDLE = -11;


        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern nint GetStdHandle(int type);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadConsoleOutputCharacterW(
            nint handle, [Out] StringBuilder buffer, uint length, COORD position, out uint read);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadConsoleOutputCharacterA(
            nint handle, [Out] StringBuilder buffer, uint length, COORD position, out uint read);

        public static char ReadUnicode(short x, short y)
        {
            var result = new StringBuilder();
            if (ReadConsoleOutputCharacterW(GetStdHandle(COUT_HANDLE), result, 1, new COORD(x, y), out _))
                return result.ToString().FirstOrDefault();
            return '\0';
        }
        public static char ReadNonUnicode(short x, short y)
        {
            var result = new StringBuilder();
            if (ReadConsoleOutputCharacterW(GetStdHandle(COUT_HANDLE), result, 1, new COORD(x, y), out _))
                return result.ToString().FirstOrDefault();
            return '\0';
        }

        public static char Read(short x, short y)
        {
            if (IsConsoleEncodingUnicode())
                return ReadUnicode(x, y);
            return ReadNonUnicode(x, y);
        }
        public static bool IsConsoleEncodingUnicode()
        {
            return Console.OutputEncoding.Equals("UTF-8")
                || Console.OutputEncoding.Equals("UTF-7")
                || Console.OutputEncoding.Equals("UTF-32");
        }
    }
}
