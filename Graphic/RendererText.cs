using System.Drawing;
using System.Windows.Forms;

namespace Common.Graphic
{
    /// <summary>
    /// Находит координаты, откуда надо выводить текст, чтобы он получился по центру
    /// </summary>
    public class RendererText
    {
        public static Point GetCenter(Font font, Rectangle rect, string text)
        {
            Point p = GetCenter(font, rect.Width, rect.Height, text);

            p.X += rect.Left;
            p.Y += rect.Top;

            return p;
        }

        public static Point GetCenter(Font font, int width, int height, string text)
        {
            Point p = new Point();
            Size size = TextRenderer.MeasureText(text, font);

            p.X = (width - size.Width) / 2;
            p.Y = (height - size.Height) / 2;

            if (p.X < 0)
                p.X = 0;

            if (p.Y < 0)
                p.Y = 0;

            return p;
        }

    }
}
