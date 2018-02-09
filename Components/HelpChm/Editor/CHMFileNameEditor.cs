using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Components.HelpChm.Editor
{
    public class CHMFileNameEditor : System.Windows.Forms.Design.FileNameEditor
    {
        protected override void InitializeDialog(System.Windows.Forms.OpenFileDialog openFileDialog)
        {
            openFileDialog.DefaultExt = "chm";
            openFileDialog.Filter = "*.chm|*.chm|*.*|*.*" ;
            openFileDialog.CheckFileExists = true;
        }
    }
}
