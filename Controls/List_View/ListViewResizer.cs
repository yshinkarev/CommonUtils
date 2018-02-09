using System;
using System.Windows.Forms;

namespace Common.Controls.List_View
{
    /// <summary>
    /// Изменяет ширину колонок ListView в случае изменения размеров самого ListView
    /// </summary>
    public class ListViewResizer
    {
        readonly double[] _perc;
        readonly int _board;

        public ListViewResizer(ListView lv)
        {
            if (lv == null)
                throw new ArgumentNullException("lv");

            int w = 0;

            for (int i = 0; i < lv.Columns.Count; i++)
                w += lv.Columns[i].Width;

            _board = lv.Width - w;

            _perc = new double[lv.Columns.Count];


            for (int i = 0; i < lv.Columns.Count; i++)
                _perc[i] = lv.Columns[i].Width / (double)(w);

            lv.Resize += ListViewResize;
        }

        void ListViewResize(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            int w = lv.Width - _board;
            
            for (int i = 0; i < lv.Columns.Count; i++)
                lv.Columns[i].Width = (int)(w * _perc[i]);
        }

    }
}
