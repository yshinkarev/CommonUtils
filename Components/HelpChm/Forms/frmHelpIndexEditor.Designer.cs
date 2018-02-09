namespace Common.Components.HelpChm.Forms
{
    partial class frmHelpIndexEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.clFormName = new System.Windows.Forms.ColumnHeader();
            this.clIndex = new System.Windows.Forms.ColumnHeader();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.nudIndex = new System.Windows.Forms.NumericUpDown();
            this.tbFormName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.btImport = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.clFormName,
            this.clIndex});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.Location = new System.Drawing.Point(7, 11);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.OwnerDraw = true;
            this.lv.Size = new System.Drawing.Size(251, 196);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.VirtualMode = true;
            this.lv.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv_DrawColumnHeader);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lv.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lv_RetrieveVirtualItem);
            this.lv.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv_DrawSubItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // clFormName
            // 
            this.clFormName.Text = "Имя формы";
            this.clFormName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clFormName.Width = 169;
            // 
            // clIndex
            // 
            this.clIndex.Text = "Индекс";
            this.clIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clIndex.Width = 54;
            // 
            // gbAdd
            // 
            this.gbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAdd.Controls.Add(this.nudIndex);
            this.gbAdd.Controls.Add(this.tbFormName);
            this.gbAdd.Controls.Add(this.label2);
            this.gbAdd.Controls.Add(this.label1);
            this.gbAdd.Location = new System.Drawing.Point(267, 6);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(186, 107);
            this.gbAdd.TabIndex = 1;
            this.gbAdd.TabStop = false;
            // 
            // nudIndex
            // 
            this.nudIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudIndex.Location = new System.Drawing.Point(10, 73);
            this.nudIndex.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudIndex.Name = "nudIndex";
            this.nudIndex.Size = new System.Drawing.Size(166, 20);
            this.nudIndex.TabIndex = 3;
            this.nudIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFormName_KeyPress);
            // 
            // tbFormName
            // 
            this.tbFormName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormName.Location = new System.Drawing.Point(10, 32);
            this.tbFormName.Name = "tbFormName";
            this.tbFormName.Size = new System.Drawing.Size(166, 20);
            this.tbFormName.TabIndex = 1;
            this.tbFormName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFormName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Индекс справки:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя формы:";
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(267, 119);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAddChange_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Location = new System.Drawing.Point(378, 119);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(75, 23);
            this.btDel.TabIndex = 3;
            this.btDel.Text = "Удалить";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(378, 184);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(267, 184);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.Location = new System.Drawing.Point(378, 152);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 5;
            this.btExport.Text = "Экспорт";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btImportExport_Click);
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Location = new System.Drawing.Point(267, 152);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(75, 23);
            this.btImport.TabIndex = 4;
            this.btImport.Text = "Импорт";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImportExport_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "*.xml|*.xml|*.*|*.*";
            this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.Title = "Выберите файл для импорта/экспорта";
            // 
            // frmHelpIndexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 215);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.gbAdd);
            this.Controls.Add(this.lv);
            this.MinimumSize = new System.Drawing.Size(467, 242);
            this.Name = "frmHelpIndexEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор \"индекс - форма\"";
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader clFormName;
        private System.Windows.Forms.ColumnHeader clIndex;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFormName;
        private System.Windows.Forms.NumericUpDown nudIndex;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}