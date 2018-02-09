using System;

namespace Common.Zip.Types
{
    public class ZipFileStatus
    {
        public TimeSpan TimeDuration;
        public ZipFileResult Result;
        public int TotalFileProcess, TotalMaskrocess;
        public int TotalErrors;
        public string ErrMsg;
    }
}
