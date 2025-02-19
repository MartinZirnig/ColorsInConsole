using CustomizedConsoleColor.Imports;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CustomizedConsoleColor
{
    /// <summary>
    /// Class for Simple applying Colors and Effects into Console
    /// </summary>
    public static class ColorfulConsole
    {
        private const string INVALID_POSITION_RECEIVED_ERROR = "Invalid value, position must be greater than {0} and lower than {1}";
        public const int MINIMAL_BUFFER = 0;

        private const string CLEARING_CODE = ConsoleEffect.CLEAR_CONSOLE + ConsoleEffect.CURSOR_START;


        /// <summary>
        /// Set Foreground color of console
        /// </summary>
        /// <param name="color">new color</param>
        public static void SetForegroundColor(RgbColor color)
        {
            Console.Write(string.Format(RgbColor.FOREGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));
        }
        /// <summary>
        /// Set Background color of console
        /// </summary>
        /// <param name="color">new color</param>
        public static void SetBackgroundColor(RgbColor color)
        {
            Console.Write(string.Format(RgbColor.BACKGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));
        }
        /// <summary>
        /// Set Foreground and Background color
        /// </summary>
        /// <param name="colors">nwe color</param>
        public static void SetColors(ConsoleColorSetting colors)
        {
            Console.Write(colors.Command);
        }
        /// <summary>
        /// applies effect to next text
        /// </summary>
        /// <param name="effect">new effect</param>
        public static void ApplyEffect(ConsoleEffect effect)
        {
            Console.Write(effect.Code);
        }
        /// <summary>
        /// Refresh all text effects
        /// </summary>
        public static void RefreshFormatting()
        {
            Console.Write(ConsoleEffect.RESET_FORMATING);
        }
        /// <summary>
        /// Set colors to default
        /// </summary>
        public static void RefreshColor()
        {
            Console.Write(RgbColor.RESET_COLOR_CODE);
        }
        /// <summary>
        /// Refresh formatting and color of console
        /// </summary>
        public static void Refresh()
        {
            Console.Write(ConsoleEffect.ResetEffects);
        }
        /// <summary>
        /// Clear Console
        /// </summary>
        public static void Clear()
        {
            Console.Write(CLEARING_CODE);
        }
        /// <summary>
        /// Set position of cursor in console
        /// </summary>
        /// <param name="left">X position</param>
        /// <param name="top">Y position</param>
        public static void SetPosition(int left, int top)
        {
            Console.Write(string.Format(ConsoleEffect.SET_CURSOR_POSITION, top, left));
        }
        /// <summary>
        /// Read character written in console
        /// </summary>
        /// <param name="left">left (X) position of character</param>
        /// <param name="top">top (Y) position of character</param>
        /// <returns></returns>
        public static char ReadWrittenChar(short left, short top)
        {
            if (left < MINIMAL_BUFFER || left > Console.WindowWidth)
                throw new ArgumentException(string.Format(INVALID_POSITION_RECEIVED_ERROR, MINIMAL_BUFFER, nameof(Console.WindowWidth)));
            else if (top < MINIMAL_BUFFER || top > Console.WindowHeight)
                throw new ArgumentException(string.Format(INVALID_POSITION_RECEIVED_ERROR, MINIMAL_BUFFER, nameof(Console.WindowHeight)));


            return ConsoleReader.Read(left, top);
        }
        /// <summary>
        /// Read string written in console, can read just on one line and stops at the end of it
        /// </summary>
        /// <param name="left">left (X) position of character</param>
        /// <param name="top">top (Y) position of character</param>
        /// <param name="length">count of characters to read (negative value is all line)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ReadWrittenString(short left, short top, int length)
        {
            if (left < MINIMAL_BUFFER || left > Console.WindowWidth)
                throw new ArgumentException(string.Format(INVALID_POSITION_RECEIVED_ERROR, MINIMAL_BUFFER, nameof(Console.WindowWidth)));
            else if (top < MINIMAL_BUFFER || top > Console.WindowHeight)
                throw new ArgumentException(string.Format(INVALID_POSITION_RECEIVED_ERROR, MINIMAL_BUFFER, nameof(Console.WindowHeight)));

            if (length < MINIMAL_BUFFER) length = int.MaxValue;

            StringBuilder builder = new StringBuilder();

            for (short charIndex = 0; charIndex < length; charIndex++)
            {
                short position = (short)(charIndex + left);
                if (position > Console.BufferWidth) break;

                builder.Append(ConsoleReader.Read(position, top));
            }


            return builder.ToString();
        }
    }
}
