using System.Drawing;

namespace Common.Graphic
{
    /// <summary>
    /// Класс с общими функциями для работы с графикой
    /// </summary>
    public static class Graph
    {
        /// <summary>
        /// Преобразует иконку в битмап
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static Bitmap GetBitmap(Icon icon)
        {            
            Bitmap bmp = new Bitmap(icon.Width, icon.Height);
            Graphics gxMem = Graphics.FromImage(bmp);
            gxMem.DrawIcon(icon, 0, 0);
            gxMem.Dispose();

            return bmp;
        }
    }
}
