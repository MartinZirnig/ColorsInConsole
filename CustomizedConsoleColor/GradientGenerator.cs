namespace CustomizedConsoleColor
{
    /// <summary>
    /// Generator of simple text gradient effects
    /// </summary>
    public record GradientGenerator
    {
        // used for optimalization
        private static readonly GradientGeneratorOptions SIMPLE_OPTION = new GradientGeneratorOptions(true, true, true);

        /// <summary>
        /// Generates gradient for Background color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="colors">two different colors for handling gradient</param>
        /// <param name="options">specifications for gradient creation</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateBackground(string text, DualColor colors, GradientGeneratorOptions options)
        {
            int differenceR = colors.Color1.R - colors.Color2.R;
            int differenceG = colors.Color1.G - colors.Color2.G;
            int differenceB = colors.Color1.B - colors.Color2.B;

            var offsetsR = CalculateOffsetOrSetDefaults(text.Length, differenceR, options.R);
            var offsetsG = CalculateOffsetOrSetDefaults(text.Length, differenceG, options.G);
            var offsetsB = CalculateOffsetOrSetDefaults(text.Length, differenceB, options.B);

            RgbColor color = new RgbColor(colors.Color1.R, colors.Color1.G, colors.Color1.B);
            StringFormatter formatter = new StringFormatter();

            int lastWrittenR = 0;
            int lastWrittenG = 0;
            int lastWrittenB = 0;


            for (int charIndex = 0; charIndex < text.Length; charIndex++)
            {
                int r = UpdateColor(ref lastWrittenR, offsetsR, color.R);
                int g = UpdateColor(ref lastWrittenG, offsetsG, color.G);
                int b = UpdateColor(ref lastWrittenB, offsetsB, color.B);
                
                color = new RgbColor(r, g, b);
                formatter.AppendBackgroundColor(color);
                formatter.AppendText(text[charIndex]);
            }
            return formatter;
        }

       
        /// <summary>
        /// Generates gradient for Background color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="colors">two different colors for handling gradient</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateBackground(string text, DualColor colors)
        {
            return this.GenerateBackground(text, colors, SIMPLE_OPTION);

        }
        /// <summary>
        /// Generates gradient for Foreground color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="colors">two different colors for handling gradient</param>
        /// <param name="options">specifications for gradient creation</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateForeground(string text, DualColor colors, GradientGeneratorOptions options)
        {
            int differenceR = colors.Color1.R - colors.Color2.R;
            int differenceG = colors.Color1.G - colors.Color2.G;
            int differenceB = colors.Color1.B - colors.Color2.B;

            var offsetsR = CalculateOffsetOrSetDefaults(text.Length, differenceR, options.R);
            var offsetsG = CalculateOffsetOrSetDefaults(text.Length, differenceG, options.G);
            var offsetsB = CalculateOffsetOrSetDefaults(text.Length, differenceB, options.B);

            RgbColor color = new RgbColor(colors.Color1.R, colors.Color1.G, colors.Color1.B);
            StringFormatter formatter = new StringFormatter();

            int lastWrittenR = 0;
            int lastWrittenG = 0;
            int lastWrittenB = 0;


            for (int charIndex = 0; charIndex < text.Length; charIndex++)
            {
                int r = UpdateColor(ref lastWrittenR, offsetsR, color.R);
                int g = UpdateColor(ref lastWrittenG, offsetsG, color.G);
                int b = UpdateColor(ref lastWrittenB, offsetsB, color.B);

                color = new RgbColor(r, g, b);
                formatter.AppendForegroundColor(color);
                formatter.AppendText(text[charIndex]);
            }
            return formatter;
        }
        /// <summary>
        /// Generates gradient for Foreground color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="colors">two different colors for handling gradient</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateForeground(string text, DualColor colors)
        {
            return this.GenerateForeground(text, colors, SIMPLE_OPTION);
        }
        /// <summary>
        /// Generates gradient for booth Foregrounds and Background color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="foreColors">two different colors for handling Foreground gradient</param>
        /// <param name="foreOptions">specifications for Foreground gradient creation</param>
        /// <param name="backColors">two different colors for handling Background gradient</param>
        /// <param name="backOptions">specifications for Background gradient creation</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateBoth(string text, DualColor foreColors, GradientGeneratorOptions foreOptions, 
            DualColor backColors, GradientGeneratorOptions backOptions)
        {
            int differenceForegroundR = foreColors.Color1.R - foreColors.Color2.R;
            int differenceForegroundG = foreColors.Color1.G - foreColors.Color2.G;
            int differenceForegroundB = foreColors.Color1.B - foreColors.Color2.B;

            int differenceBackgroundR = foreColors.Color1.R - foreColors.Color2.R;
            int differenceBackgroundG = foreColors.Color1.G - foreColors.Color2.G;
            int differenceBackgroundB = foreColors.Color1.B - foreColors.Color2.B;


            var offsetsForegroundR = CalculateOffsetOrSetDefaults(text.Length, differenceForegroundR, foreOptions.R);
            var offsetsForegroundG = CalculateOffsetOrSetDefaults(text.Length, differenceForegroundG, foreOptions.G);
            var offsetsForegroundB = CalculateOffsetOrSetDefaults(text.Length, differenceForegroundB, foreOptions.B);

            var offsetsBackgroundR = CalculateOffsetOrSetDefaults(text.Length, differenceBackgroundR, backOptions.R);
            var offsetsBackgroundG = CalculateOffsetOrSetDefaults(text.Length, differenceBackgroundG, backOptions.G);
            var offsetsBackgroundB = CalculateOffsetOrSetDefaults(text.Length, differenceBackgroundB, backOptions.B);



            RgbColor foregroundColor = new RgbColor(foreColors.Color1.R, foreColors.Color1.G, foreColors.Color1.B);
            RgbColor backgroundColor = new RgbColor(backColors.Color1.R, backColors.Color1.G, backColors.Color1.B);
            StringFormatter formatter = new StringFormatter();
            


            int lastWrittenForegroundR = 0;
            int lastWrittenForegroundG = 0;
            int lastWrittenForegroundB = 0;

            int lastWrittenBackgroundR = 0;
            int lastWrittenBackgroundG = 0;
            int lastWrittenBackgroundB = 0;

            for (int charIndex = 0; charIndex < text.Length; charIndex++)
            {
                int foregroundR = UpdateColor(ref lastWrittenForegroundR, offsetsForegroundR, foregroundColor.R);
                int foregroundG = UpdateColor(ref lastWrittenForegroundG, offsetsForegroundG, foregroundColor.G);
                int foregroundB = UpdateColor(ref lastWrittenForegroundB, offsetsForegroundB, foregroundColor.B);
                
                int backgroundR = UpdateColor(ref lastWrittenBackgroundR, offsetsBackgroundR, backgroundColor.R);
                int backgroundG = UpdateColor(ref lastWrittenBackgroundG, offsetsBackgroundG, backgroundColor.G);
                int backgroundB = UpdateColor(ref lastWrittenBackgroundB, offsetsBackgroundB, backgroundColor.B);

                foregroundColor = new RgbColor(foregroundR, foregroundG, foregroundB);
                backgroundColor = new RgbColor(backgroundR, backgroundG, backgroundB);
                

                formatter.AppendForegroundColor(foregroundColor);
                formatter.AppendBackgroundColor(backgroundColor);
                formatter.AppendText(text[charIndex]);
            }
            return formatter;
        }
        /// <summary>
        /// Generates gradient for booth Foregrounds and Background color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="foreColors">two different colors for handling Foreground gradient</param>
        /// <param name="backColors">two different colors for handling Background gradient</param>
        /// <param name="options">specifications for gradient creation</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateBoth(string text, DualColor foreColors, DualColor backColors, GradientGeneratorOptions options)
        {
            return this.GenerateBoth(text, foreColors, options, backColors, options);
        }
        /// <summary>
        /// Generates gradient for booth Foregrounds and Background color
        /// </summary>
        /// <param name="text">modified text</param>
        /// <param name="foreColors">two different colors for handling Foreground gradient</param>
        /// <param name="backColors">two different colors for handling Background gradient</param>
        /// <returns>result in StringFormatter form (call ToString to get value)</returns>
        public StringFormatter GenerateBoth(string text, DualColor foreColors, DualColor backColors)
        {
            return this.GenerateBoth(text, foreColors, SIMPLE_OPTION, backColors, SIMPLE_OPTION);
        }

        private byte UpdateColor(ref int lasWritten, (int editted, int offset) offset, byte currentColor)
        {
            if (lasWritten++ >= offset.offset)
            {
                lasWritten = 0;
                currentColor += (byte)offset.editted;
            }

            return currentColor;
        }
        private (int editted, int offset) CalculateOffsetOrSetDefaults(int length, int difference, bool calculate)
        {
            if (calculate) 
                return CalculateOffsetsBasedOnLength(length, difference);
            return (0, int.MaxValue);
        }
        private (int editted, int offset) CalculateOffsetsBasedOnLength(int length, int difference)
        {
            if (difference == 0) return (0, length + 1);

            if (length < Math.Abs(difference))
                return (Math.Abs(difference / length), 1);
            else
                return (difference >= 0 ? 1 : -1, length / difference);
        }
    }
}
