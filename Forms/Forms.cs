using System.Windows.Forms;

namespace Common.Forms
{
    /// <summary>
    /// Общий класс с различными функциями для работы с формами
    /// </summary>
    public static class Forms
    {
        /// <summary>
        /// Ищет среди открытых форм приложения заданную и возвращает 0-индекс, если нашел
        /// </summary>
        public static int FindForm(string formName)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
                if (Application.OpenForms[i].Name == formName)
                    return i;

            return -1;            
        }

        /// <summary>
        /// Возвращает форму по имени класса, иначе - null
        /// </summary>
        public static Form FindFormPtr(string formName)
        {
            int index = FindForm(formName);

            if (index != -1)
                return Application.OpenForms[index];
            else
                return null;
        }
    }
}
