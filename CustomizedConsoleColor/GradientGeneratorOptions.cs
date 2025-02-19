namespace CustomizedConsoleColor
{
    /// <summary>
    /// Specifications for gradient generator
    /// defines which colors will be modified
    /// </summary>
    public readonly struct GradientGeneratorOptions
    {
        // actual value
        public readonly bool R;
        public readonly bool G;
        public readonly bool B;

        /// <summary>
        /// Construct options
        /// </summary>
        /// <param name="changeRed">Defines, if gradient generator will modify R in RGB</param>
        /// <param name="changeBlue">Defines, if gradient generator will modify G in RGB</param>
        /// <param name="changeGreen">Defines, if gradient generator will modify B in RGB</param>
        public GradientGeneratorOptions(bool changeRed, bool changeBlue, bool changeGreen)
        {
            R = changeRed;
            G = changeGreen;
            B = changeBlue;
        }
    }
}
