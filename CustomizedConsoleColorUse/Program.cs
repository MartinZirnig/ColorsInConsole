using CustomizedConsoleColor;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Channels;

namespace CustomizedConsoleColorTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //UseStringFormatter();
            //UseHexadecimal();
            //UseDrawingColor();
            UseBackgroundGradientGenerator();
            Console.ReadKey();
            UseForegroundGradientGenerator();
            Console.ReadKey();
            UseGradientGenerator();
            Console.ReadKey();

            //Epilepsy();
        }

        public static void UseStringFormatter()
        {
            RgbColor red = new RgbColor(255, 0, 0);
            RgbColor green = new RgbColor(0, 255, 0);
            RgbColor blue = new RgbColor(0, 0, 255);
            RgbColor sus = new RgbColor(128, 128, 128);
            RgbColor back = new RgbColor(System.Drawing.Color.Azure);

            ConsoleEffect flash = ConsoleEffect.Flashing;
            ConsoleEffect stopFlash = ConsoleEffect.StopFlashing;
            ConsoleEffect bold = ConsoleEffect.Bold;
            ConsoleEffect stopBold = ConsoleEffect.StopBold;
            ConsoleEffect underline = ConsoleEffect.Underline;
            ConsoleEffect stopUnderline = ConsoleEffect.StopUnderline;

            string r = "Red";
            string g = "Green";
            string b = "blue";
            string neco = "Neco";

            StringFormatter formatter = new StringFormatter(neco);
            formatter.AppendEffect(flash + ConsoleEffect.SetForegroundColor(red));
            formatter.AppendText(r);
            formatter.AppendEffect(stopFlash);
            formatter.AppendEffect(bold + ConsoleEffect.SetForegroundColor(green));
            formatter.AppendText(g);
            formatter.AppendEffect(stopBold);
            formatter.AppendEffect(underline + ConsoleEffect.SetForegroundColor(blue));
            formatter.AppendText(b);
            formatter.AppendEffect(stopUnderline);
            formatter.AppendEffect(ConsoleEffect.ResetFormatting);
            formatter.AppendForegroundColor(sus);
            formatter.AppendText(neco);

            ColorfulConsole.SetBackgroundColor(back);
            ColorfulConsole.ApplyEffect(ConsoleEffect.ClearConsole);
            Console.WriteLine(formatter.ToString());
        }
        public static void UseHexadecimal()
        {
            RgbColor color = new RgbColor("ABCDEF");
            ColorfulConsole.SetForegroundColor(color);
            Console.WriteLine("foobarbaz");
        }
        public static void UseDrawingColor()
        {
            Color drawing = Color.Orange;
            RgbColor color = new RgbColor(drawing);
            ColorfulConsole.SetForegroundColor(color);
            Console.WriteLine(nameof(drawing));
        }
        public static void UseBackgroundGradientGenerator()
        {
            GradientGenerator gradient = new GradientGenerator();
            RgbColor first = new RgbColor(100, 100, 100);
            RgbColor second = new RgbColor(100, 100, 255);

            string result = gradient.GenerateBackground("foo bar baz qux, quux", new DualColor(first, second)).ToString();
            Console.WriteLine(result);
            Console.ResetColor();

            RgbColor first2 = new RgbColor(100, 100, 100);
            RgbColor second2 = new RgbColor(100, 100, 255);

            string result2 = gradient.GenerateBackground("foo bar baz qux, quux", new DualColor(second2, first2)).ToString();
            Console.WriteLine(result2);
        }
        public static void UseForegroundGradientGenerator()
        {
            GradientGenerator gradient = new GradientGenerator();
            RgbColor first = new RgbColor(100, 100, 0);
            RgbColor second = new RgbColor(100, 100, 255);

            string result = gradient.GenerateForeground("foo bar baz qux, quux", new DualColor(first, second)).ToString();
            Console.WriteLine(result);
            Console.ResetColor();

            RgbColor first2 = new RgbColor(100, 100, 0);
            RgbColor second2 = new RgbColor(100, 100, 255);

            string result2 = gradient.GenerateForeground("foo bar baz qux, quux", new DualColor(second2, first2)).ToString();
            Console.WriteLine(result2);
        }
        public static void UseGradientGenerator()
        {
            GradientGenerator gradient = new GradientGenerator();
            RgbColor first = new RgbColor(100, 100, 0);
            RgbColor second = new RgbColor(100, 100, 255);

            RgbColor first2 = new RgbColor(0, 0, 0);
            RgbColor second2 = new RgbColor(255, 0, 0);

            string result2 = gradient.GenerateBoth("foo bar baz qux, quux", new DualColor(first2, second2), new DualColor(second, first)).ToString();
            Console.WriteLine(result2);
        }

        public static void Epilepsy()
        {
            Parallel.For(0, 500, _ =>
            {
                while (true)
                {
                    ColorfulConsole.SetBackgroundColor(new RgbColor(RandomByte, RandomByte, RandomByte));
                    ColorfulConsole.SetForegroundColor(new RgbColor(RandomByte, RandomByte, RandomByte));
                    Console.Write(RandomByte);
                }
            });

        }
        static int RandomByte => System.Random.Shared.Next(0, 255);
    }
}
