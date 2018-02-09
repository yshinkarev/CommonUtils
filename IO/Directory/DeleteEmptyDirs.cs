using System;
using dir = System.IO.Directory;

namespace Common.IO.Directory
{
    /// <summary>
    /// Удаляет вложенные пустые папки относительно заданной папки
    /// </summary>
    public class DeleteEmptyDirs
    {
        readonly string _rootDir;

        public DeleteEmptyDirs(string rootDir)
        {
            if (string.IsNullOrEmpty(rootDir))
                throw new ArgumentNullException("rootDir");

            _rootDir = rootDir;

            ProcessDirectory(rootDir);

        }

        /// <returns>Возвращается True, если после удаления подпапок, заданная папка оказалось также пустой.
        /// В этом случае заданная папка также удаляется</returns>
        public bool Execute()
        {
            ProcessDirectory(_rootDir);

            return DelDirIfEmpty(_rootDir);
        }

        private void ProcessDirectory(string startLocation)
        {
            foreach (string directory in System.IO.Directory.GetDirectories(startLocation))
            {
                ProcessDirectory(directory);
                DelDirIfEmpty(directory);
            }
        }

        /// <summary>
        /// Удаляется папка, если внутри нее нет папок (даже пустых) и файлов
        /// </summary>        
        /// <returns>True - если удаление прошло успешно. 
        /// Иначе: если произошла ошибка при удалении или папка не пуста</returns>
        public bool DelDirIfEmpty(string path)
        {
            if (dir.GetFiles(path).Length == 0 && dir.GetDirectories(path).Length == 0)
            {
                try
                {
                    dir.Delete(path, false);
                    return true;
                }
                catch (Exception) { }
            }
            
            return false;
        }

        /// <summary>
        /// Аналогично DelDirIfEmpty с параметром, только в качестве папке для удаления берется заданная папка в конструкторе
        /// </summary>        
        public bool DelDirIfEmpty()
        {
            return DelDirIfEmpty(_rootDir);
        }
    }
}
