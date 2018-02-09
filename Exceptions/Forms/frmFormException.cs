using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace Common.Exceptions.Forms
{
    /// <summary>
    /// Используется в классе FormException
    /// </summary>
    public partial class frmFormException : Form
    {
        private readonly Exception _ex;
        private readonly StackTrace _stack;
        private StreamWriter _sWriter;

        public frmFormException(Exception ex)
        {
            InitializeComponent();

            _ex = ex;

            pbIcon.Image = Graphic.Graph.GetBitmap(SystemIcons.Error);

            CEnvironment.InitForm(this);

            folderBrowserDialog.SelectedPath = Application.StartupPath;
            folderBrowserDialog.Description = @"Выберите корневую папку для сохранения информации об ошибке";

            _stack = new StackTrace();

            MethodBase method = _stack.GetFrame(2).GetMethod();

            tbMethod.Text = method.Name;
            tbComponent.Text = method.DeclaringType.Name;

            string s = _ex.Message;
            int pos = s.IndexOf("\r");

            if (pos != -1)
                s = s.Substring(0, pos - 1);

            tbError.Text = s;

            rtb.Text = ex.ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {   
                string zipFileName = string.Format("\\{0}_exception_{1}",  MsgBox.AppTitle, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                string path = folderBrowserDialog.SelectedPath + zipFileName + "\\";

                if (CreateDebugDir(path))
                {
                    CreateWriter(path);
                    
                    bool ret = SaveStack(path);

                    if (ret)
                        ret = SaveException(path);
                    else
                        SaveException(path);

                    if (ret)
                        ret = SaveAssembly(path);
                    else
                        SaveAssembly(path);

                    if (ret)
                        ret = SaveAssemblies(path);
                    else
                        SaveAssemblies(path);

                    if (_sWriter != null)
                        _sWriter.Dispose();

                    zipFileName = folderBrowserDialog.SelectedPath + zipFileName + ".zip";

                    if (ret)
                        ret = CreateZipFile(zipFileName, path);
                    else CreateZipFile(zipFileName, path);

                    if (ret)
                    {
                        rtbStatusSave.Text = @"сохранен\r\n" + zipFileName;
                        rtbStatusSave.ForeColor = Color.Green;
                    }
                    else
                    {
                        rtbStatusSave.Text = @"ошибка при создании/сохранении\r\n" + zipFileName;
                        rtbStatusSave.ForeColor = Color.Maroon;
                    }
                }                
            }
        }

        #region SaveFunc

        private bool SaveStack(string path)
        {
            WriteToLog("Component: " + tbComponent.Text);
            WriteToLog("Method: " + tbMethod.Text);
            WriteToLog("Message: " + tbError.Text + "\r\n");
            
            WriteToLog(_stack + "\r\n");
            
            bool ret = IO.Serialization.FileSerializer.BinWriteToFile(path + "stack.bin", _stack);

            if (!ret)
                MsgBox.ShowError("Ошибка в ходе создания файла-стэка");

            return ret;
        }

        private bool SaveException(string path)
        {
            WriteToLog(_ex + "\r\n");

            bool ret = IO.Serialization.FileSerializer.BinWriteToFile(path + "exception.bin", _ex);

            if (!ret)
                MsgBox.ShowError("Ошибка в ходе создания файла-исключения");

            return ret;
        }

        private bool SaveAssembly(string path)
        {
            Assembly ass = Assembly.GetEntryAssembly();

            WriteToLog(ass + "\r\n");

            bool ret = IO.Serialization.FileSerializer.BinWriteToFile(path + "application.bin", ass);

            if (!ret)
                MsgBox.ShowError("Ошибка в ходе создания файла-приложения");

            return ret;
        }

        private bool SaveAssemblies(string path)
        {
            Assembly ass = Assembly.GetEntryAssembly();

            AssemblyName[] assNames = ass.GetReferencedAssemblies();

            foreach (AssemblyName aname in assNames)
            {
                WriteToLog(aname.ToString());
            }
            
            bool ret = IO.Serialization.FileSerializer.BinWriteToFile(path + "assembly.bin", assNames);

            if (!ret)
                MsgBox.ShowError("Ошибка в ходе создания списка сборок");

            return ret;
        }

        #endregion

        #region InternalFunc

        private bool CreateZipFile(string fileName, string path)
        {
            bool ret;

            Zip.Types.ZipFilesInfo zfi = new Zip.Types.ZipFilesInfo();
            zfi.Level = 9;
            zfi.Password = "exception_zip";
            zfi.StartDir = path;
            zfi.DelFilesAfterPak = true;

            zfi.AddMask(new Zip.Types.ZipMaskFile("", "*.*"));

            using (Zip.ZipFiles zip = new Zip.ZipFiles(zfi))
            {
                ret = (zip.Execute(fileName).Result == Zip.Types.ZipFileResult.OK);
            }            

            return ret;
        }

        private void CreateWriter(string path)
        {
            const string FNAME = "summary.txt";
            try
            {
                _sWriter = new StreamWriter(path + FNAME, false, Encoding.Default);
            }
            catch (Exception)
            {
                _sWriter = null;
                MsgBox.ShowError("Не удается создать обобщенный файл " + FNAME);
            }
        }
        
        private bool CreateDebugDir(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                MsgBox.ShowError("Не удается создать директорию:\r\n" + path);
                return false;
            }

            return true;
        }

        private void WriteToLog(string text)
        {
            if (_sWriter != null)
                try
                {
                    _sWriter.WriteLine(text);
                }
                catch (Exception) { }
        }

        #endregion

        private void lbEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link != null)
                if (e.Link.LinkData != null)
                    Process.Start(e.Link.LinkData as string);
        }
    }
}
