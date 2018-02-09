using System;
using System.IO;

namespace Common.IO
{
    /// <summary>
    /// Класс с общими функцияим для работы с файлами
    /// </summary>
    public static class Files
    {
        /// <summary>
        /// Удаляет файл, если он существует. Не кидает исключение IOException
        /// </summary>
        public static bool DelIfExists(string fileName)
        {
            if (File.Exists(fileName))
                try
                {
                    File.Delete(fileName);                    
                }
                catch (IOException)
                {
                    return false;
                }

            return true;
        }

        /// <summary>
        /// Удаляет файл (без всяких exception
        /// </summary>        
        /// <returns>True - если файл успешно удален</returns>        
        public static bool DelSilent(string fileName)
        {
            try
            {
                File.Delete(fileName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
