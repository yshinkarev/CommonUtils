namespace Common.Zip.Types
{
    /// <summary>
    /// Описывает одну маску для добавления в архив
    /// </summary>
    public class ZipMaskFile
    {
        readonly string _path;
        readonly string _searchPattern;
        readonly System.IO.SearchOption _searchOption;

        #region Constructors

        /// <summary>
        /// Задается маска: *.*
        /// Путь - текущий каталог.
        /// Файлы только в текущем каталоге. Вложенные каталоги игнорируются.
        /// </summary>
        public ZipMaskFile(): this("")
        {
        }

        /// <param name="path">Каталог, в котором будут анализироваться файлы</param>
        public ZipMaskFile(string path): this(path, "*.*")
        {            
        }

        /// <param name="searchPattern">Маска для файлов</param>
        public ZipMaskFile(string path, string searchPattern): this(path, searchPattern, System.IO.SearchOption.TopDirectoryOnly)
        {   
        }

        /// <param name="searchOption">Анализ только в данном каталоге или вложенные тоже рассматриваются</param>
        public ZipMaskFile(string path, string searchPattern, System.IO.SearchOption searchOption)
        {
            _path = path;
            _searchPattern = searchPattern;
            _searchOption = searchOption;
        }

        #endregion

        #region Properties

        public string Path
        {
            get { return _path; }
        }

        public string SearchPattern
        {
            get { return _searchPattern; }
        }

        public System.IO.SearchOption SearchOption
        {
            get { return _searchOption; }
        }

        #endregion
    }
}
