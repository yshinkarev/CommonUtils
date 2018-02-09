using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace Common.Components.HelpChm
{
    /// <summary>
    /// Компонент для упрощения подключения chm-справки к проекту
    /// </summary>
    public partial class HelpChm : Component
    {
        protected string _chmFileName = "";
        protected Types.HelpIndex[] _indexer;
        private ContainerControl _containerControl;

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

        [BrowsableAttribute(false)]
        [ReadOnly(true)]
        public ContainerControl ContainerControl
        {
            get { return _containerControl; }
            set { _containerControl = value; }
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

        public Form CreateForm(Type typeForm, object[] args)
        {
            return CreateForm(typeForm, args, false);
        }

        /// <param name="initForm">Запускать для формы CEnvironment.InitForm или нет</param>
        public Form CreateForm(Type typeForm, bool initForm)
        {
            return CreateForm(typeForm, null, initForm);
        }

        /// <param name="initForm">Запускать для формы CEnvironment.InitForm или нет</param>
        public Form CreateForm(Type typeForm, object[] args, bool initForm)
        {
            Form f = Activator.CreateInstance(typeForm, args) as Form;

            f.KeyPreview = true;
            f.KeyUp += Form_KeyUp;

            if (initForm)
                CEnvironment.InitForm(f);

            return f;
        }

        /// <summary>
        /// Вызывает справку с конкретным ID раздела
        /// </summary>
        /// <param name="topicID">ID раздела</param>
        /// <param name="parent">Контрол, для которого вызывается справка</param>
        public void ShowTopic(int topicID, Control parent)
        {
            if (topicID < 0)
                MessageBox.Show(@"Индекс раздела справки не может быть отрицательным числом. Обратитесь к разработчикам",
                    Application.OpenForms[0].Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else Help.ShowHelp(parent, _chmFileName, HelpNavigator.TopicId, topicID.ToString());
        }

        /// <summary>
        /// Выводит справку, как при запуске chm-файла
        /// </summary>
        /// <param name="parent">Контрол, для которого вызывается справка</param>
        public void ShowTableOfContents(Control parent)
        {
            Help.ShowHelp(parent, _chmFileName, HelpNavigator.TableOfContents);
        }

        protected void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form form = (sender as Form);
                int index = GetHelpIndex(form.Name);

                if (!System.IO.File.Exists(_chmFileName))
                    MessageBox.Show(@"Не найден файл справки """ + System.IO.Path.GetFileName(_chmFileName) + @"""",
                        Application.OpenForms[0].Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (index == -1)
                    {
                        MessageBox.Show(@"Индекс раздела справки не задан для данной формы. Обратитесь к разработчикам",
                            Application.OpenForms[0].Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ShowTableOfContents(form);
                    }
                    else
                        ShowTopic(index, form);
                }
            }
        }

        /// <summary>
        /// Возвращает индекс контекстной справки. Если нет такой, то -1
        /// </summary>
        private int GetHelpIndex(string formName)
        {
            if (_indexer != null)
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

                    if (componentHost is ContainerControl)
                        ContainerControl = componentHost as ContainerControl;
                }
            }
        }
    }
}
