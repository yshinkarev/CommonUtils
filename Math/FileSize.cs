using System;

namespace Common.Math
{
    /// <summary>
    /// Возвращает строку размера. В зависимости от размера возвращает в кб, мб, гб. Округляет до сотых
    /// </summary>
    public static class FileSize
    {
        public static string FileSizeFmt(int bytes)
        {
            if (bytes >= 1073741824)
                return FileSizeFmt(bytes, "Г");
            else if (bytes >= 1048576)
                return FileSizeFmt(bytes, "М");
            else if (bytes >= 1024)
                return FileSizeFmt(bytes, "К");
            else
                return FileSizeFmt(bytes, "");
        }

        /// <param name="type">"", "К", "М", "Г"</param>
        public static string FileSizeFmt(int bytes, string type)
        {
            int div;

            if (type == "Г")
                div = 1073741824;
            else if (type == "М")
                div = 1048576;
            else if (type == "К")
                div = 1024;
            else if (type == "")
                div = 1;
            else throw new ArgumentException("Invalid type");

            return String.Format("{0:##.##} {1}", (bytes / (float)div), type);
        }
    }
}
