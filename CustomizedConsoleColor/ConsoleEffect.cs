using CustomizedConsoleColor.Imports;
using System.Diagnostics;
using System.Text;

namespace CustomizedConsoleColor
{
    /// <summary>
    /// Representation of simple console effects
    /// </summary>
    public struct ConsoleEffect
    {
        // Effect codes
        private const string ACTIVATE_FLASHING = "\u001b[5m";
        private const string DEACTIVATE_FLASHING = "\u001b[25m";
        private const string ACTIVATE_UNDERLINE = "\u001b[4m";
        private const string DEACTIVATE_UNDERLINE = "\u001b[24m";
        private const string ACTIVATE_BOLD = "\u001b[1m";
        private const string DEACTIVATE_BOLD = "\u001b[21m";
        internal const string RESET_EFFECTS =
            DEACTIVATE_FLASHING + DEACTIVATE_BOLD + ACTIVATE_UNDERLINE;
        internal const string RESET_FORMATING = "\u001b[0m";
        internal const string CLEAR_CONSOLE = "\u001b[2J";
        internal const string CURSOR_START = "\u001b[0;0H";
        internal const string SET_CURSOR_POSITION = "\u001b[{0};{1}H";

        // public construction
        /// <summary>
        /// Activate Flushing effect
        /// </summary>
        public static ConsoleEffect Flashing => new ConsoleEffect(ACTIVATE_FLASHING);
        /// <summary>
        /// Deactivate Flushing effect
        /// </summary>
        public static ConsoleEffect StopFlashing => new ConsoleEffect(DEACTIVATE_FLASHING);
        /// <summary>
        /// Activate Underline effect
        /// </summary>
        public static ConsoleEffect Underline => new ConsoleEffect(ACTIVATE_UNDERLINE);
        /// <summary>
        /// Deactivate Underline effect
        /// </summary>
        public static ConsoleEffect StopUnderline => new ConsoleEffect(DEACTIVATE_UNDERLINE);
        /// <summary>
        /// Activate Bold effect
        /// </summary>
        public static ConsoleEffect Bold => new ConsoleEffect(ACTIVATE_BOLD);
        /// <summary>
        /// Deactivate Bold effect
        /// </summary>
        public static ConsoleEffect StopBold => new ConsoleEffect(DEACTIVATE_BOLD);
        /// <summary>
        /// Deactivate all effects 
        /// </summary>
        public static ConsoleEffect ResetEffects => new ConsoleEffect(RESET_EFFECTS);
        /// <summary>
        /// Deactivate all effects and reset colors
        /// </summary>
        public static ConsoleEffect ResetFormatting => new ConsoleEffect(RESET_FORMATING);
        /// <summary>
        /// Clear text in console
        /// </summary>
        public static ConsoleEffect ClearConsole => new ConsoleEffect(CLEAR_CONSOLE);
        /// <summary>
        /// Move cursor to start location (position 0, 0)
        /// </summary>
        public static ConsoleEffect ResetCursor => new ConsoleEffect(CURSOR_START);
        /// <summary>
        /// Set cursor position to specified location
        /// </summary>
        /// <param name="left">x position</param>
        /// <param name="top">y position</param>
        public static ConsoleEffect SetCursor(int left, int top) => 
            new ConsoleEffect(string.Format(SET_CURSOR_POSITION, top, left));
        /// <summary>
        /// Set Foreground color
        /// </summary>
        /// <param name="color">grb color instance</param>
        public static ConsoleEffect SetForegroundColor(RgbColor color) => 
            new ConsoleEffect(string.Format(RgbColor.FOREGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));
        /// <summary>
        /// Set Background color
        /// </summary>
        /// <param name="color">grb color instance</param>
        public static ConsoleEffect SetBackgroundColor(RgbColor color) => 
            new ConsoleEffect(string.Format(RgbColor.BACKGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));



        // actual value
        internal string Code;

        /// <summary>
        /// Generated Construction
        /// </summary>
        public ConsoleEffect()
        {
            this.Code = string.Empty;
        }
        // Recommended construction
        private ConsoleEffect(string code)
        {
            this.Code = code;
        }
        /// <summary>
        /// append another effect
        /// </summary>
        /// <param name="addon">another effect</param>
        public void SafeAppend(ConsoleEffect addon)
        {
            if (!this.Code.Contains(addon.Code))
                this.Code += addon.Code;
        }
        /// <summary>
        /// Append another effect into existing effect
        /// <para>Note: effects can be stack and one effect may contains more same formatting. For check use function SafeAppend </para>
        /// </summary>
        /// <param name="left">source instance</param>
        /// <param name="right">appending instance</param>
        /// <returns>Modified source</returns>
        public static ConsoleEffect operator +(ConsoleEffect left, ConsoleEffect right)
        {
            left.Code += right.Code;
            return left;
        }
        /// <summary>
        /// Remove effect from existing effect
        /// </summary>
        /// <param name="left">source instance</param>
        /// <param name="right">appending instance</param>
        /// <returns>Modified source</returns>
        public static ConsoleEffect operator -(ConsoleEffect left, ConsoleEffect right)
        {
            int position = left.Code.LastIndexOf(right.Code);
            if (position != -1)
                left.Code.Remove(position, right.Code.Length);
            return left;
        }
    }
}
