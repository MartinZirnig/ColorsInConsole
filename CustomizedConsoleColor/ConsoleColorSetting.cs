namespace CustomizedConsoleColor
{
    /// <summary>
    /// Stores two separated colors
    /// created for simple manipulation with console-color states
    /// </summary>
    /// <param name="foreground">Foreground color</param>
    /// <param name="background">Background color</param>
    public readonly struct ConsoleColorSetting(RgbColor foreground, RgbColor background)
    {
        // used for command generation
        private const string COMMAND_TEMPLATE = "\u001b[38;2;{0};{1};{2}m\u001b[48;2;{3};{4};{5}m";
        /// <summary>
        /// Foreground Color
        /// </summary>
        public readonly RgbColor Foreground = foreground;
        /// <summary>
        /// Background Color
        /// </summary>
        public readonly RgbColor Background = background;
        // used by other inner processes
        internal readonly string Command =
            string.Format(COMMAND_TEMPLATE, foreground.R, foreground.G, foreground.B, background.R, background.G, background.B);

        // used for simple changes between DualColor and ConsoleColorSetting
        public static implicit operator DualColor(ConsoleColorSetting color) =>
            new DualColor(color.Foreground, color.Background);
    }
}
