using System.Drawing;

namespace CustomizedConsoleColor
{
    /// <summary>
    /// Representation of rgb color
    /// <para>Overrides comparison, so it can be compared to other instance values</para>
    /// </summary>
    public readonly struct RgbColor
    {
        // Exceptions messages
        private const string INCORRECT_STRING_HEXADECIMAL_FORMAT_ERROR = "Value must be in correct hexadecimal format";
        private const string INCORRECT_STRING_LENGTH_IN_HEXADECIMAL_ERROR = "Length of hexadecimal string must be {0} long, not {1}";
        private const string BYTE_OVERFLOW_ERROR = "Selected value must be between {0} and {1}, not {2}";


        // Value constants
        internal const string FOREGROUND_RGB_COLOR_CODE = "\u001b[38;2;{0};{1};{2}m";
        internal const string BACKGROUND_RGB_COLOR_CODE = "\u001b[48;2;{0};{1};{2}m";
        internal const string RESET_COLOR_CODE = "\u001b[38;2;0;0;0m\u001b[48;2;255;255;255m";
        private const int HEXADECIMAL_LENGHT = 6;
        internal const int VALUES_COUNT = 3;
        /// <summary>
        /// Actual values
        /// </summary>
        internal readonly byte R, G, B;
        /// <summary>
        /// Basic construction
        /// </summary>
        /// <param name="r">Red value</param>
        /// <param name="g">Green value</param>
        /// <param name="b">Blue value</param>
        public RgbColor(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
        /// <summary>
        /// Construction by integral values
        /// <para>incorrect size handle by exception</para>
        /// </summary>
        /// <param name="r">Red value</param>
        /// <param name="g">Green value</param>
        /// <param name="b">Blue value</param>
        /// <exception cref="ArgumentException">Appears when int is in incorrect format</exception>
        public RgbColor(int r, int g, int b) 
        {
            int[] values = [r, g, b];
            byte[] result = new byte[VALUES_COUNT];
            for (int i = 0; i < VALUES_COUNT; i++)
            {
                if (values[i] < byte.MinValue || values[i] > byte.MaxValue)
                    throw new ArgumentException(string.Format(BYTE_OVERFLOW_ERROR, byte.MinValue, byte.MaxValue, values[i]));
                result[i] = (byte)values[i];
            }
            this.R = result[0];            
            this.G = result[1];            
            this.B = result[2];
        }
        /// <summary>
        /// Construction by hexadecimal string value
        /// </summary>
        /// <param name="hexadecimal">Hexadecimal color value</param>
        /// <exception cref="ArgumentException">appears when hexadecimal is not in correct format</exception>
        public RgbColor(string hexadecimal)
        {
            if (hexadecimal.Length != HEXADECIMAL_LENGHT)
                throw new ArgumentException(string.Format(
                    INCORRECT_STRING_LENGTH_IN_HEXADECIMAL_ERROR, HEXADECIMAL_LENGHT, hexadecimal.Length));

            this.R = ParseHexadecimal(hexadecimal[..2]);
            this.G = ParseHexadecimal(hexadecimal[2..4]);
            this.B = ParseHexadecimal(hexadecimal[4..]);
        }

        private byte ParseHexadecimal(string value)
        {
            bool ok = byte.TryParse(value, System.Globalization.NumberStyles.HexNumber,
                null, out byte result);
            if (!ok) throw new ArgumentException(INCORRECT_STRING_HEXADECIMAL_FORMAT_ERROR);
            return result;
        }

        /// <summary>
        /// Construction using System.Drawing.Color
        /// </summary>
        /// <param name="color">Color instance</param>
        public RgbColor(Color color) 
        {
            this.R = color.R;
            this.G = color.G;
            this.B = color.B;
        }


        /// <summary>
        /// String override for easier printing
        /// </summary>
        /// <returns>string in format "R:{Red},G:{Green},B:{Blue}"</returns>
        public override string ToString()
        {
            return $"R:{R},G:{G},B:{B}";
        }

        // comparison override for easier manipulation
        public static bool operator ==(RgbColor left, RgbColor right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(RgbColor left, RgbColor right)
        {
            return !(left == right);
        }
        public override bool Equals(object? obj)
        {
            if (obj is RgbColor color)
            {
                return R == color.R
                    && G == color.G
                    && B == color.B;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (R, G, B).GetHashCode();
        }
    }
}
