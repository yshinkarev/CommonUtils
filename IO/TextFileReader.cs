using System;
using System.Text;
using System.IO;

namespace Common.IO.TextFile
{
    [Flags]
    public enum TextFileReaderFlag
    {
        Default = 1,
        MissingComment = 2        
    }
    
    /// <summary>
    /// Читает текстовые файлы с настройками
    /// </summary>
    public class TextFileReader
    {
        string /*fileName,*/ commIdent = "#;";
        StreamReader sr;
        TextFileReaderFlag flags = TextFileReaderFlag.Default;
        int nstr;        

        public int Nstr
        {
            get { return nstr; }
        }

        public string CommentIdent
        {
            get { return commIdent; }
            set { commIdent = value; }
        }

        public TextFileReader()
        {
            Close();
        }

        public bool Open(string fileName, Encoding encoding)
        {
            return Open(fileName, encoding, new TextFileReaderFlag());
        }

        public bool Open(string fileName, Encoding encoding, TextFileReaderFlag flag)
        {
            try
            {
                sr = new StreamReader(fileName, encoding);
                flags = flag;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Close()
        {
            if (sr != null)
            {
                sr.Close();
                sr = null;
            }

            nstr = -1;
        }

        public bool ReadLine(out string str)
        {   
            try
            {
                str = sr.ReadLine();
                nstr++;

                if (str == null) return true;
                
                if ((flags & TextFileReaderFlag.MissingComment) != 0)
                {
                    if (commIdent.IndexOf(str[0]) != -1)
                        return ReadLine(out str);
                }

                return true;
            }
            catch(Exception)
            {
                str = "";
                return false;
            }
        }
    }
}
