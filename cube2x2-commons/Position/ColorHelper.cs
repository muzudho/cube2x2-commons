namespace Grayscale.Commons
{
    using System.Drawing;

    /// <summary>
    /// 色に関するユーティリティー。
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// 色をアルファベットに変換します。
        /// </summary>
        /// <param name="color">色。</param>
        /// <returns>アルファベット。</returns>
        public static string GetShort(Color color)
        {
            if (color == Color.Pink)
            {
                return "r";
            }
            else if (color == Color.Lime)
            {
                return "g";
            }
            else if (color == Color.SkyBlue)
            {
                return "b";
            }
            else if (color == Color.Orange)
            {
                return "y";
            }
            else if (color == Color.Violet)
            {
                return "v";
            }
            else if (color == Color.LightGray)
            {
                return "w";
            }

            return "?";
        }

        /// <summary>
        /// 数をアルファベットに変換します。
        /// </summary>
        /// <param name="color">色。</param>
        /// <returns>アルファベット。</returns>
        public static string GetShort(int color)
        {
            if (color == (int)ColorNumber.Red)
            {
                return "r";
            }
            else if (color == (int)ColorNumber.Green)
            {
                return "g";
            }
            else if (color == (int)ColorNumber.Blue)
            {
                return "b";
            }
            else if (color == (int)ColorNumber.Yellow)
            {
                return "y";
            }
            else if (color == (int)ColorNumber.Violet)
            {
                return "v";
            }
            else if (color == (int)ColorNumber.Gray)
            {
                return "w";
            }

            return "?";
        }

        /// <summary>
        /// アルファベットを色に変換します。
        /// </summary>
        /// <param name="ch">アルファベット。</param>
        /// <returns>色。</returns>
        public static Color GetColor(char ch)
        {
            if (ch == 'r')
            {
                return Color.Pink;
            }
            else if (ch == 'g')
            {
                return Color.Lime;
            }
            else if (ch == 'b')
            {
                return Color.SkyBlue;
            }
            else if (ch == 'y')
            {
                return Color.Orange;
            }
            else if (ch == 'v')
            {
                return Color.Violet;
            }
            else if (ch == 'w')
            {
                return Color.LightGray;
            }

            return Color.Black;
        }

        /// <summary>
        /// 数を色に変換します。
        /// </summary>
        /// <param name="color">色番号。</param>
        /// <returns>色。</returns>
        public static Color GetColor(int color)
        {
            if (color == 0)
            {
                return Color.Pink;
            }
            else if (color == 1)
            {
                return Color.Lime;
            }
            else if (color == 2)
            {
                return Color.SkyBlue;
            }
            else if (color == 3)
            {
                return Color.Orange;
            }
            else if (color == 4)
            {
                return Color.Violet;
            }
            else if (color == 5)
            {
                return Color.LightGray;
            }

            return Color.Black;
        }

        /// <summary>
        /// 色を数に変換します。
        /// </summary>
        /// <param name="color">色番号。</param>
        /// <returns>色。</returns>
        public static int GetColor(Color color)
        {
            if (color == Color.Pink)
            {
                return (int)ColorNumber.Red;
            }
            else if (color == Color.Lime)
            {
                return (int)ColorNumber.Green;
            }
            else if (color == Color.SkyBlue)
            {
                return (int)ColorNumber.Blue;
            }
            else if (color == Color.Orange)
            {
                return (int)ColorNumber.Yellow;
            }
            else if (color == Color.Violet)
            {
                return (int)ColorNumber.Violet;
            }
            else if (color == Color.LightGray)
            {
                return (int)ColorNumber.Gray;
            }

            return (int)ColorNumber.Error;
        }

        /// <summary>
        /// アルファベットを色に変換します。
        /// </summary>
        /// <param name="ch">アルファベット。</param>
        /// <returns>色。</returns>
        public static int GetNumberFromAlphabet(char ch)
        {
            if (ch == 'r')
            {
                return 0;
            }
            else if (ch == 'g')
            {
                return 1;
            }
            else if (ch == 'b')
            {
                return 2;
            }
            else if (ch == 'y')
            {
                return 3;
            }
            else if (ch == 'v')
            {
                return 4;
            }
            else if (ch == 'w')
            {
                return 5;
            }

            return -1;
        }
    }
}
