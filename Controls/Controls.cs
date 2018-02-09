using System.Windows.Forms;

namespace Common.Controls
{
    public class Controls
    {
        /// <summary>
        /// Если находит требуемый контрол
        /// </summary>
        public static bool GetControlByName(Control parentCtrl, string nameCtrl, out Control findedControl)
        {
            Control ctrl;

            for (int i = 0; i < parentCtrl.Controls.Count; i++)
            {
                ctrl = parentCtrl.Controls[i];

                if (ctrl.Name == nameCtrl)
                {
                    findedControl = ctrl;
                    return true;
                }
                else
                {
                    if (GetControlByName(ctrl, nameCtrl, out findedControl))
                        return true;
                }
            }            

            findedControl = null;
            return false;

        }
    }
}
