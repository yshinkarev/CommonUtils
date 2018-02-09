using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.ComponentModel.Design;

namespace Common.Components.HelpChm
{
    /// <summary>
    /// Компонент для упрощения подключения chm-справки к проекту
    /// </summary>
    public partial class HelpChm : Component
    {
        protected string _chmFileName = "";
        protected Types.HelpIndex[] _indexer = null;
        private ContainerControl _containerControl = null;

        public ContainerControl ContainerControl
        {
            get { return _containerControl; }
            set 
            { 
                _containerControl = value;

                Form f = _containerControl as Form;
                f.KeyPress += new KeyPressEventHandler(button1_Click);
            }
        }

        private void button1_Click(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("key press");
        }

        #region Constructors

        public HelpChm()
        {
            InitializeComponent();

            if (_containerControl != null)
                MessageBox.Show(_containerControl.Name);
        }

        public HelpChm(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #endregion

        #region Properties
        
        [Description("Имя файла справки chm, который будет использоваться в программе")]
        [EditorAttribute(typeof(Editor.CHMFileNameEditor), typeof(UITypeEditor))]
        public string ChmFileName
        {
            get { return _chmFileName; }
            set 
            {
                _chmFileName = value; 
            }
        }

        [Description("Массив соответствий: форма - индекс в справке")]
        [Editor(typeof(Editor.IndexerTypeEditor), typeof(UITypeEditor))]
        public Types.HelpIndex[] Indexer
        {
            get { return _indexer; }
            set { _indexer = value; }
        }
        
        #endregion

        /// <summary>
        /// Создается форма заданного типа и прикручивается возможность запуска справки по кнопке F1 (без InitForm)
        /// </summary>
        public Form CreateForm(Type typeForm)
        {
            return CreateForm(typeForm, false);
        }

        /// <param name="InitForm">Запускать для формы CEnvironment.InitForm или нет</param>
        public Form CreateForm(Type typeForm, bool InitForm)
        {
            Form f = Activator.CreateInstance(typeForm) as Form;

            f.KeyPreview = true;
            f.KeyUp += new KeyEventHandler(Form_KeyUp);

            if (InitForm)
                CEnvironment.InitForm(f);

            return f;
        }

        protected void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form form = (sender as Form);
                int index = GetHelpIndex(form.Name);

                if (index != -1)
                {
                    if (!System.IO.File.Exists(_chmFileName))
                        MessageBox.Show("Не найден файл справки \"" + System.IO.Path.GetFileName(_chmFileName) + "\"",
                            Application.OpenForms[0].Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Help.ShowHelp(form, _chmFileName, HelpNavigator.TopicId, index.ToString());
                }
            }
        }

        /// <summary>
        /// Возвращает индекс контекстной справки. Если нет такой, то -1
        /// </summary>
        private int GetHelpIndex(string formName)
        {
            for (int i = 0; i < _indexer.Length; i++)
                if (Indexer[i].FormName == formName)
                    return Indexer[i].Index;
            
            return -1;            
        }

        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;

                if (value == null)
                    return;

                IDesignerHost host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;

                if (host != null)
                {                    
                    IComponent componentHost = host.RootComponent;
                    //MessageBox.Show("-" + componentHost.GetType().Name);

                    if (componentHost is ContainerControl)
                    {
                        ContainerControl = componentHost as ContainerControl;
                        //MessageBox.Show("+" + componentHost.GetType().Name);
                    }
                }
            }
        }
    }
}
