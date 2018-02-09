using System;
using System.ComponentModel;

namespace Common.Components.HelpChm.Types
{
    /// <summary>
    /// Описывает индекс для одной формы
    /// </summary>    
    [Serializable]
    public class HelpIndex : IComparable
    {
        string _formName;
        int _index;

        public HelpIndex(HelpIndex hi)
        {
            _formName = hi.FormName;
            _index = hi.Index;
        }

        public HelpIndex()
        {
        }

        public HelpIndex(string formName, int index)
        {
            _formName = formName;
            _index = index;
        }
        
        [Description("Имя формы")]        
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }        

        [Description("Индекс справки")]        
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public override string ToString()
        {
            return string.Format("\"{0}\" {1}", _formName, _index);            
        }        

        public int CompareTo(object obj)
        {
            if (obj is HelpIndex)
                return Index.CompareTo((obj as HelpIndex).Index);
            else
                throw new ArgumentException("obj is not HelpIndex");
        }
    }
}
