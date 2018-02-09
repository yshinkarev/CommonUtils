using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Common.Controls
{
    /// <summary>
    /// Формирует журнал: запись в файл + отображение данных в отдельной форме
    /// </summary>
    public class ListViewLog
    {
        static ListView lv;
        static bool ownerCreate;
        static readonly ImageList il;
        static string fileName = "";        

        public const string dateTimeFormat = "dd MMM yyyy HH:mm:ss";
        static readonly string[] iconNames = new[] { "INFO", "ERR", "WARN" };

        static public void AddInfo(string text)
        {
            AddItem(text, 0);            
        }

        static public void AddError(string text)
        {
            AddItem(text, 1);
        }

        static public void AddWarning(string text)
        {
            AddItem(text, 2);
        }

        private delegate void AddItemHandler(string text, int Param);

        static void AddItem(string text, int Param)
        {
            if (lv.InvokeRequired)
                lv.Invoke(new AddItemHandler(AddItem), new object[] { text, Param });
            else
            {
                string dt = DateTime.Now.ToString(dateTimeFormat);
                ListViewItem item = new ListViewItem(new[] {"", dt, text}, Param);

                lv.Items.Add(item);

                if (fileName != "")
                {
                    try
                    {
                        StreamWriter f = new StreamWriter(fileName, true, Encoding.Default);

                        if (Param == 1)
                            f.WriteLine("[{0}]  {1,21}: {2}", iconNames[Param], dt, text);
                        else
                            f.WriteLine("[{0}] {1,21}: {2}", iconNames[Param], dt, text);

                        f.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        static public bool Create(ContainerControl owner, Point[] rect)
        {
            if (ownerCreate && lv != null)
                lv.Dispose();

            try
            {
                if (lv == null)
                {
                    lv = new ListView();
                    ownerCreate = true;                    
                }

                lv.Parent = owner;
                lv.Items.Clear();
                lv.Columns.Clear();

                lv.AutoArrange = false;
                lv.MultiSelect = false;
                lv.Columns.Add("");
                lv.Columns.Add("Дата");
                lv.Columns.Add("Информация");

                for (int i = 0; i < lv.Columns.Count; i++)
                    lv.Columns[i].TextAlign = HorizontalAlignment.Left;

                lv.FullRowSelect = true;
                lv.GridLines = true;
                lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                lv.ImeMode = ImeMode.Off;                
                lv.MultiSelect = false;
                lv.Name = "listViewLog";
                lv.ShowGroups = false;
                lv.ShowItemToolTips = true;                

                if (rect != null)
                {
                    lv.Location = rect[0];
                    lv.Size = new Size(rect[1].X - rect[0].X, rect[1].Y - rect[0].Y);
                }
                                
                lv.TabIndex = 4;
                lv.UseCompatibleStateImageBehavior = false;
                lv.View = View.Details;

                Graphics g = lv.CreateGraphics();
                lv.Columns[0].Width = 25;
                lv.Columns[1].Width = g.MeasureString(DateTime.Now.ToString(dateTimeFormat) 
                + "W", lv.Font).ToSize().Width;
                g.Dispose();

                lv.Resize += OnListViewResize;                
                OnListViewResize(lv, EventArgs.Empty);

                lv.SmallImageList = il;

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.ToString(), MessageBoxButtons.OK);
                return false;
            }
        }

        static void OnListViewResize(object sender, EventArgs e)
        {
            lv.Columns[2].Width = lv.ClientSize.Width - lv.Columns[1].Width - lv.Columns[0].Width;
        }

        static ListViewLog()
        {
            try
            {
                il = new ImageList {ColorDepth = ColorDepth.Depth32Bit};

                ResourceManager rm = new ResourceManager("Common.Properties.Resources",
                Assembly.GetCallingAssembly());

                for (int i = 0; i < iconNames.Length; i++)
                {
                    Icon icon = (Icon)rm.GetObject("i" + iconNames[i]);
                    il.Images.Add(icon);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError("Ошибка в конструкторе ListViewLog:\r\n\r\n" + ex);
            }
        }
        
        /// <summary>
        /// При задании этого свойства начинает писаться в лог-файл
        /// Если его обнулить, запись прекращается
        /// При первой установке имени, файл с таким именем удаляется
        /// </summary>
        public static string FileName
        {
            get { return fileName; }
            set 
            { 
                fileName = value;

                if (value != "")
                    File.Delete(value);
            }
        }

        /// <summary>
        /// Если задать его вручную (уже имеющийся на форме), то он и будет
        /// использоваться. Создаваться внутри класса не будет
        /// </summary>
        public static ListView ListView
        {
            get { return lv; }
            set 
            {
                lv = value;
                ownerCreate = false;
            }
        }
    }
}
