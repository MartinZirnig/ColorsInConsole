using System.Text;

namespace CustomizedConsoleColor
{
    /// <summary>
    /// Class for formatting string
    /// optimized for appending,
    /// <para> cannot remove once appended value </para>
    /// when formatting finish, call ToString function
    /// </summary>
    public class StringFormatter 
    {
        // inner StringBuilder for optimized appending
        private StringBuilder _builder;    
        /// <summary>
        /// Construct instance
        /// </summary>
        public StringFormatter()
        {
            this._builder = new StringBuilder();
        }
        /// <summary>
        /// Construct instance with some text
        /// </summary>
        /// <param name="text">appended text</param>
        public StringFormatter(string text)
        {
            this._builder = new StringBuilder(text);
        }
        /// <summary>
        /// Construct instance with some effect
        /// </summary>
        /// <param name="effect">appended effect</param>
        public StringFormatter(ConsoleEffect effect)
        {
            this._builder = new StringBuilder(effect.Code);
        }
        /// <summary>
        /// Construct instance with some text and effect
        /// </summary>
        /// <param name="text">appended text</param>
        /// <param name="effect">appended effect</param>
        public StringFormatter(string text, ConsoleEffect effect)
        {
            this._builder = new StringBuilder(effect.Code);
            this._builder.Append(text);
        }

        /// <summary>
        /// append text to the end of current string
        /// </summary>
        /// <param name="text">appended text</param>
        public void AppendText(string text)
        {
            this._builder.Append(text);
        }

        /// <summary>
        /// append text to the end of current string
        /// </summary>
        /// <param name="text">appended text</param>
        public void AppendText(char text)
        {
            this._builder.Append(text);
        }
        /// <summary>
        /// append effect to the end of current string
        /// </summary>
        /// <param name="effect">appended effect</param>
        public void AppendEffect(ConsoleEffect effect)
        {
            this._builder.Append(effect.Code);
        }
        /// <summary>
        /// append Background color to the end of current string
        /// </summary>
        /// <param name="color">appended color</param>
        public void AppendBackgroundColor(RgbColor color)
        {
            this._builder.Append(string.Format(RgbColor.BACKGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));
        }
        /// <summary>
        /// append Foreground color to the end of current string
        /// </summary>
        /// <param name="color">appended color</param>
        public void AppendForegroundColor(RgbColor color)
        {
            this._builder.Append(string.Format(RgbColor.FOREGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));

        }
        /// <summary>
        /// append Color to the end of current string
        /// </summary>
        /// <param name="color">appended color</param>
        public void AppendColor(ConsoleColorSetting color)
        {
            this._builder.Append(color.Command);
        }
        /// <summary>
        /// append text and jump to next line
        /// </summary>
        /// <param name="text">appended text</param>
        public void AppendTextLine(string text)
        {
            this._builder.AppendLine(text);
        }
        /// <summary>
        /// Ekvivalent to AppendText function
        /// </summary>
        /// <param name="text">appended value</param>
        public void Append(string text)
        {
            this._builder.Append(text);
        }
        /// <summary>
        /// Ekvivalent to AppendText function
        /// </summary>
        /// <param name="c">appended value</param>
        public void Append(char c)
        {
            this._builder.Append(c);
        }
        /// <summary>
        /// Ekvivalent to AppendEffect
        /// </summary>
        /// <param name="effect">appended effect</param>
        public void Append(ConsoleEffect effect)
        {
            this._builder.Append(effect.Code);
        }
        /// <summary>
        /// Ekvivalent to append color
        /// </summary>
        /// <param name="color">appended color</param>
        public void Append(ConsoleColorSetting color)
        {
            this._builder.Append(color.Command);
        }
        /// <summary>
        /// Append color by foreground flag
        /// </summary>
        /// <param name="color">appended color</param>
        /// <param name="foreground">decide if appending foreground (true) or background (false)</param>
        public void Append(RgbColor color, bool foreground)
        {
            if (foreground) 
                this._builder.Append(string.Format(RgbColor.FOREGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));
            else
                this._builder.Append(string.Format(RgbColor.BACKGROUND_RGB_COLOR_CODE, color.R, color.G, color.B));
        }
        /// <summary>
        /// Transform instance into writable string
        /// </summary>
        /// <returns>Completed string</returns>
        public override string ToString()
        {
            return this._builder.ToString();
        }
    }
}
