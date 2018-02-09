using System.Windows.Forms;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// Выводит сообщения. Не использовать в design-mode
    /// </summary>
    public class MsgBox
    {
        static readonly string appTitle = "";

        static MsgBox()
        {            
            Assembly thisAsm = Assembly.GetEntryAssembly();

            object[] _attrs = thisAsm.GetCustomAttributes((typeof(AssemblyTitleAttribute)), false);
            appTitle = ((AssemblyTitleAttribute)_attrs[0]).Title;

            if (string.IsNullOrEmpty(appTitle))
            {
                appTitle = AppProduct;
            }
            else if (string.IsNullOrEmpty(appTitle))
                appTitle = System.IO.Path.GetFileNameWithoutExtension(thisAsm.FullName);
        }

        static public string AppTitle
        {
            get
            {
                return appTitle;
            }
        }

        static public string AppProduct
        {
            get
            {
                return (Assembly.GetEntryAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false)[0] as
                    AssemblyProductAttribute).Product;
            }
        }

        static public DialogResult Show(string text, MessageBoxButtons buttons,
            MessageBoxIcon icon)
        {
            return MessageBox.Show(text, appTitle, buttons, icon);
        }

        static public DialogResult ShowError(string text, MessageBoxButtons buttons)
        {
            return Show(text, buttons, MessageBoxIcon.Error);
        }

        static public DialogResult ShowWarning(string text, MessageBoxButtons buttons)
        {
            return Show(text, buttons, MessageBoxIcon.Warning);
        }

        static public DialogResult ShowQuestion(string text, MessageBoxButtons buttons)
        {
            return Show(text, buttons, MessageBoxIcon.Question);
        }

        static public DialogResult ShowInformation(string text, MessageBoxButtons buttons)
        {
            return Show(text, buttons, MessageBoxIcon.Information);
        }

        static public DialogResult ShowError(string text)
        {
            return ShowError(text, MessageBoxButtons.OK);
        }

        static public DialogResult ShowWarning(string text)
        {
            return ShowWarning(text, MessageBoxButtons.OK);
        }

        static public DialogResult ShowInformation(string text)
        {
            return ShowInformation(text, MessageBoxButtons.OK);
        }
    } 
}