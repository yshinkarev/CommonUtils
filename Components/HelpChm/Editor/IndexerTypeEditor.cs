using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace Common.Components.HelpChm.Editor
{
    public class IndexerTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)
                    provider.GetService(typeof(IWindowsFormsEditorService));

                if (editorService != null)
                {   
                    Types.HelpIndex[] indexerList = null;

                    if (value != null)
                        indexerList = (Types.HelpIndex[])value;

                    Forms.frmHelpIndexEditor form = new Forms.frmHelpIndexEditor(indexerList);
                    form.Name = context.Instance.GetType().Name; 

                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (form.Indexer == null)
                            value = null;
                        else
                            value = form.Indexer.ToArray();
                    }                        
                }
            }

            return base.EditValue(context, provider, value);
        }
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            if (context != null)
                return UITypeEditorEditStyle.Modal;
            else
                return base.GetEditStyle(context);
        }
    }    
}
