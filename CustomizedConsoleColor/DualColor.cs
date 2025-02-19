namespace CustomizedConsoleColor
{
    /// <summary>
    /// Simple structure for manipulation with two colors
    /// </summary>
    /// <param name="color1">First color</param>
    /// <param name="color2">Second color</param>
    public readonly struct DualColor(RgbColor color1, RgbColor color2)
    {
        /// <summary>
        /// First color (foreground when ConsoleColorSettings)
        /// </summary>
        public readonly RgbColor Color1 = color1;
        /// <summary>
        /// Second color (background when ConsoleColorSettings)
        /// </summary>
        public readonly RgbColor Color2 = color2;

        // used for simple changes between DualColor and ConsoleColorSetting
        public static implicit operator ConsoleColorSetting(DualColor color) =>
            new ConsoleColorSetting(color.Color1, color.Color2);
    }
}
