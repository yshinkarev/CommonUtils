using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.Components.HelpChm.Types;

namespace Common.Components.HelpChm.Forms
{
    /// <summary>
    /// Форма для редактирования свойства HelpChm::Indexer
    /// </summary>
    public partial class frmHelpIndexEditor : Form
    {
        List<HelpIndex> _indexer;
        int _selectIndex = -1;
        SolidBrush _selBrush = new SolidBrush(Color.FromArgb(-3486977));

        public List<Types.HelpIndex> Indexer
        {
            get { return _indexer; }            
        }
        
        public frmHelpIndexEditor(HelpIndex[] indexerList)
        {
            InitializeComponent();

            if (indexerList == null)
                _indexer = new List<HelpIndex>();
            else
            {
                //System.Windows.Forms.MessageBox.Show(indexerList.Length.ToString());

                _indexer = new List<HelpIndex>(indexerList.Length);

                for(int i = 0; i < indexerList.Length; i++)
                    _indexer.Add(new HelpIndex(indexerList[i]));
            }

            ReSortIndexer();
        }

        private void lv_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {   
            e.Item = new ListViewItem(new string[] { "", _indexer[e.ItemIndex].FormName, _indexer[e.ItemIndex].Index.ToString() });
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (lv.SelectedIndices.Count > 0)
            {
                _selectIndex = lv.SelectedIndices[0];

                tbFormName.Text = _indexer[_selectIndex].FormName;
                nudIndex.Value = _indexer[_selectIndex].Index;

                lv.Refresh();
            }
        }

        protected void ReSortIndexer()
        {
            lv.VirtualListSize = _indexer.Count;            

            if (_indexer.Count == 0)            
            {            
                _selectIndex = -1;
                tbFormName.Text = "";
                nudIndex.Value = 0;             
            }

            lv.Refresh();            
        }

        private void btAddChange_Click(object sender, EventArgs e)
        {   
            if (tbFormName.Text == "")
                MessageBox.Show("Не задано имя формы!", Name);
            else
            {
                _indexer.Add(new HelpIndex(tbFormName.Text, Convert.ToInt32(nudIndex.Value)));
                _selectIndex = _indexer.Count - 1;

                ReSortIndexer();
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex != -1)
            {
                _indexer.RemoveAt(_selectIndex);

                if (_selectIndex >= _indexer.Count)
                    _selectIndex = _indexer.Count - 1;

                ReSortIndexer();
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            // проверка

            string overLap = "";            

            for(int i = 0; i < _indexer.Count; i++)
                for (int j = i + 1; j < _indexer.Count; j++)
                {
                    if (_indexer[i].FormName == _indexer[j].FormName /*|| _indexer[i].Index == _indexer[j].Index*/)
                        overLap += string.Format("{0} - {1}\r\n", _indexer[i].ToString(), _indexer[j].ToString());
                }

            if (overLap != "")
            {
                MessageBox.Show("Найдены совпадения:\r\n" + overLap.Substring(0, overLap.Length - 2), Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_indexer.Count == 0)
                _indexer = null;

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void nudIndex_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (_selectIndex ==  e.ItemIndex)
                e.Graphics.FillRectangle(_selBrush, e.Bounds);
            else
                e.DrawBackground();

            e.DrawText();
        }

        private void btImportExport_Click(object sender, EventArgs e)
        {
            openFileDialog.CheckFileExists = (sender == btImport);
            openFileDialog.CheckPathExists = !openFileDialog.CheckFileExists;            
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                if (sender == btImport)
                    FileImport(fileName);
                else
                    FileExport(fileName);
            }
        }

        private void FileExport(string fileName)
        {
            Common.IO.Serialization.FileSerializer.XmlWriteToFile(fileName, _indexer);
        }

        private void FileImport(string fileName)
        {            
            List<HelpIndex> newIndexer = (List<HelpIndex>) Common.IO.Serialization.FileSerializer.XmlReadFromFile(fileName, _indexer.GetType());

            if (newIndexer == null)
                if (MessageBox.Show("Импортируемый список пуст. Продолжить операцию?", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
                    return;

            _indexer = newIndexer;
            ReSortIndexer();
        }

        private void tbFormName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)            
                if (_selectIndex != -1)
                {
                    if (sender == tbFormName)
                        _indexer[_selectIndex].FormName = tbFormName.Text;
                    else
                        _indexer[_selectIndex].Index = Convert.ToInt32(nudIndex.Value);

                    lv.Refresh();
                }
        }
    }
}
