using System.Windows.Forms;
using System.Drawing;

namespace Common
{
    /// <summary>
    /// Стандартизирует форму в соответствии с главной формой. Обращаться к классу только после создания главной формы
    /// </summary>
    public class CEnvironment
    {
        static Icon _mainIcon;

        static CEnvironment()
        {
            if (Application.OpenForms.Count > 0)
                _mainIcon = Application.OpenForms[0].Icon;
        }

        public static void Initialize(Form baseForm)
        {
            _mainIcon = baseForm.Icon;
        }

        /// <summary>
        /// Задает для формы иконку главной формы и если нет заголовка, то устанавливается текст приложения
        /// </summary>        
        public static void InitForm(Form form)
        {
            form.Icon = _mainIcon;

            if (form.Text == "")
                form.Text = MsgBox.AppTitle;        
        }
    }
    
}
