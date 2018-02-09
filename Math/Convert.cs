using System;
using System.Text;

namespace Common.Math
{
    public static class Convert
    {
        /// <summary>
        /// Преобразует hex-строку (без 0x) в число
        /// </summary>        
        /// <returns>-1 - если не удалось преобразовать</returns>
        public static int HexToInt(string str)
        {
            int value;
            try
            {
                value = int.Parse(str, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            catch (Exception)
            {
                value = -1;
            }

            return value;
        }

        public static void CodePage(Encoding src, Encoding trg, ref string str)
        {
            byte[] sourceBytes = Encoding.Default.GetBytes(str);
            byte[] resultBytes = Encoding.Convert(src, trg, sourceBytes);
            str = Encoding.Default.GetString(resultBytes);            
        }
    }
}
