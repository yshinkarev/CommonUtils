using System.Collections.Generic;

namespace Common.Zip.Types
{
    /// <summary>
    /// Описывает что именно и откуда надо паковать в классе ZipFiles.
    /// </summary>
    public class ZipFilesInfo
    {
        string _startDir;
        readonly List<ZipMaskFile> _mask = new List<ZipMaskFile>();
        int _level = 3;

        public ZipFilesInfo()
        {
            SetDatePakFilesNow = false;
            DelFilesAfterPak = false;
        }

        public void AddMask(ZipMaskFile zmf)
        {
            _mask.Add(zmf);
        }

        #region Properties

        /// <summary>
        /// Директория, которая считается базовой для всех файлов паковки.
        /// Если она задана, то все маски, конкретные файлы, подпапки используют в качестве начальной папки указанную папку.
        /// Если она не задана, то берется текущая папка, но всё пути рассматриваются, как абсолютные.
        /// </summary>
        public string StartDir
        {
            set 
            {
                if (value != string.Empty)
                {
                    if (value[value.Length - 1] != '\\')
                        value += "\\";
                }

                _startDir = value;
            }
            get { return _startDir; }
        }

        public List<ZipMaskFile> ListMask
        {
            get { return _mask; }
        }

        // Уровень сжатия: 0 (без сжатия) - 9 (максимальный). По умолчанию: 3
        public int Level
        {
            set { _level = value; }
            get { return _level; }
        }

        /// <summary>
        /// Пароль на архив
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Флаг: устанавливать время последнего изменения файлов в архиве. По умолчанию: не устанавливать
        /// </summary>
        public bool SetDatePakFilesNow { get; set; }

        /// <summary>
        /// Флаг: удалять исходные файлы после упаковки. По умолчанию: не удалять.
        /// </summary>
        public bool DelFilesAfterPak { get; set; }

        #endregion
    }
}
