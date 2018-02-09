using System.Drawing;
using System.Windows.Forms;

namespace Common.Controls.List_View
{
    public class ListViewers
    {
        public static void DisableListViewColumnWidth(ListView lv)
        {
            lv.ColumnWidthChanging += delegate(object sender, ColumnWidthChangingEventArgs e)
            {
                e.Cancel = true;
                e.NewWidth = ((ListView)sender).Columns[e.ColumnIndex].Width;
            };
        }

        public static int FindItemIndexAtCursor(ListView listView)
        {
            Point p = Cursor.Position;

            p = listView.PointToClient(p);

            ListViewItem item =  listView.GetItemAt(p.X, p.Y);

            if (item == null)
                return -1;
            else
                return item.Index;
        }
    }
}
