using System;
using Common.Zip.Types;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace Common.Zip
{
    /// <summary>
    /// Класс предназаначен для упаковки файлов в архив. Требуется наличие бибилиотеки ICSharpCode.SharpZipLib.dll.
    /// </summary>
    public class ZipFiles: IDisposable
    {
        readonly ZipFilesInfo _zfi;
        FileStream _fZip;
        ZipOutputStream _zip;
        string _rootPath = string.Empty;
        string _zipFileName = string.Empty;
        ZipFileStatus _status;
        byte[] _buffer;

        /// <param name="zfi">Информация о файлах и местоположении для сжатия</param>
        public ZipFiles(ZipFilesInfo zfi)
        {
            if (zfi == null)
                throw new ArgumentNullException("zfi");

            _zfi = zfi;
        }

        public ZipFileStatus Execute(string zipFileName)
        {
            DateTime timeStart = DateTime.Now;

            _status = new ZipFileStatus();

            _zipFileName = zipFileName;
            if (CreateZipFile())
            {
                if (SetParamsForZip())
                {
                    if (GetRootPath())
                    {
                        foreach (ZipMaskFile mask in _zfi.ListMask)
                        {
                            ProcessOneMask(mask);
                        }
                    }
                }
            }

            _status.TimeDuration = DateTime.Now - timeStart;
            
            return _status;
        }

        private void ProcessOneMask(ZipMaskFile mask)
        {
            string[] files;
            string path = _zfi.StartDir + mask.Path;

            try
            {
                files = Directory.GetFiles(path, mask.SearchPattern, mask.SearchOption);
            }
            catch(Exception ex)
            {
                ErrAdd(ZipFileResult.GetFileListErr, ex);
                return;
            }
            
            foreach (string fname in files)
            {
                ProcessOneFile(fname, GetEntryFileName(fname));
            }

            _status.TotalMaskrocess++;

            if (_zfi.DelFilesAfterPak)
                try
                {
                    new IO.Directory.DeleteEmptyDirs(path).DelDirIfEmpty();
                }
                catch (Exception ex)
                {
                    ErrAdd(ZipFileResult.InternalError, ex);
                }
        }

        private void ProcessOneFile(string srcFileName, string entryFileName)
        {
            if (srcFileName != _zipFileName)
            {                
                try
                {
                    ZipEntry newEntry = new ZipEntry(entryFileName);

                    if (_zfi.SetDatePakFilesNow)
                        newEntry.DateTime = DateTime.Now;

                    _zip.PutNextEntry(newEntry);
                    
                }
                catch(Exception ex)
                {
                    ErrAdd(ZipFileResult.InternalError, ex);
                    return;
                }

                try
                {
                    using (FileStream streamReader = new FileStream(srcFileName, FileMode.Open, FileAccess.Read))
                    {
                        StreamUtils.Copy(streamReader, _zip, _buffer);
                    }

                    _status.TotalFileProcess++;

                    if (_zfi.DelFilesAfterPak)
                        File.Delete(srcFileName);
                }
                catch (Exception ex)
                {
                    ErrAdd(ZipFileResult.IOError, ex);
                    return;
                }                
            }
        }

        #region InternalFunc

        private string GetEntryFileName(string fileName)
        {
            if (_rootPath == string.Empty)
                return fileName;
            else
            {
                string endPath = fileName.Substring(_rootPath.Length);
                return endPath;
            }
        }

        private bool GetRootPath()
        {   
            string[] paths = new string[_zfi.ListMask.Count];
            int minPathLen = 1024;

            for (int i = 0; i < _zfi.ListMask.Count; i++)
            {
                try
                {
                    paths[i] = Path.GetFullPath(_zfi.StartDir + _zfi.ListMask[i].Path);
                }
                catch (Exception ex)
                {
                    return ErrAdd(ZipFileResult.IllegalPath, ex);
                }

                if (minPathLen > paths[i].Length)
                    minPathLen = paths[i].Length;
            }

            int splashPos = -1;

            for (int i = 0; i < minPathLen; i++)
            {
                char symb = paths[0][i];

                for (int j = 1; j < _zfi.ListMask.Count; j++)
                {
                    if (symb != paths[j][i])
                    {
                        symb = '\0';
                        break;
                    }
                }

                if (symb == '\0')
                    break;
                else if (symb == '\\')
                    splashPos = i;
            }

            if (splashPos != -1)
                _rootPath = paths[0].Substring(0, splashPos + 1);

            return true;
        }

        private bool SetParamsForZip()
        {
            try
            {
                _zip.SetLevel(_zfi.Level);

                if (_zfi.Password != string.Empty)
                    _zip.Password = _zfi.Password;
            }
            catch (Exception ex)
            {
                return ErrAdd(ZipFileResult.InternalError, ex);
            }

            return true;
        }

        private bool CreateZipFile()
        {
            try
            {
                _buffer = new byte[4096];
            }
            catch (Exception ex)
            {
                return ErrAdd(ZipFileResult.InternalError, ex);
            }

            try
            {
                _fZip = new FileStream(_zipFileName, FileMode.Create);
                _zipFileName = _fZip.Name;
            }
            catch (Exception ex)
            {
                return ErrAdd(ZipFileResult.IOError, ex);
            }

            try
            {
                _zip = new ZipOutputStream(_fZip);
            }
            catch (Exception ex)
            {
                return ErrAdd(ZipFileResult.InternalError, ex);
            }

            return true;
        }

        #endregion

        private bool ErrAdd(ZipFileResult result, Exception ex)
        {
            _status.Result = result;
            _status.TotalErrors++;

            _status.ErrMsg = result + " " + ex.Message + "\r\n";

            return false;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_zip != null)
            {
                try
                {
                    _zip.IsStreamOwner = true;
                    _zip.Close();

                }
                catch (Exception)
                { }
            }
        }

        #endregion
    }
}
