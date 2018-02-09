namespace Common.Exceptions.Forms
{
    partial class frmFormException
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
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbComponent = new System.Windows.Forms.TextBox();
            this.tbMethod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbError = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbStatusSave = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(7, 7);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(46, 46);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // rtb
            // 
            this.rtb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb.Location = new System.Drawing.Point(7, 189);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(341, 96);
            this.rtb.TabIndex = 2;
            this.rtb.Text = "";
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(276, 433);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "В программе произошла необрабатываемая ошибка. \r\nМожно продолжить или завершить р" +
                "аботу программы.\r\nВ случае продолжении возможна нестабильная работа.\r\nДля устран" +
                "ения ошибки обратитесь к разработчику.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbComponent);
            this.groupBox1.Controls.Add(this.tbMethod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Источник ошибки";
            // 
            // tbComponent
            // 
            this.tbComponent.BackColor = System.Drawing.SystemColors.Control;
            this.tbComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbComponent.Location = new System.Drawing.Point(108, 48);
            this.tbComponent.Name = "tbComponent";
            this.tbComponent.ReadOnly = true;
            this.tbComponent.Size = new System.Drawing.Size(221, 20);
            this.tbComponent.TabIndex = 9;
            this.tbComponent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMethod
            // 
            this.tbMethod.BackColor = System.Drawing.SystemColors.Control;
            this.tbMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMethod.Location = new System.Drawing.Point(108, 18);
            this.tbMethod.Name = "tbMethod";
            this.tbMethod.ReadOnly = true;
            this.tbMethod.Size = new System.Drawing.Size(221, 20);
            this.tbMethod.TabIndex = 8;
            this.tbMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Имя компонента:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Имя метода:";
            // 
            // tbError
            // 
            this.tbError.BackColor = System.Drawing.SystemColors.Control;
            this.tbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbError.ForeColor = System.Drawing.Color.Red;
            this.tbError.Location = new System.Drawing.Point(50, 163);
            this.tbError.Name = "tbError";
            this.tbError.ReadOnly = true;
            this.tbError.Size = new System.Drawing.Size(298, 20);
            this.tbError.TabIndex = 10;
            this.tbError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Текст:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbStatusSave);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbEmail);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(7, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 134);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сохранение";
            // 
            // rtbStatusSave
            // 
            this.rtbStatusSave.BackColor = System.Drawing.SystemColors.Control;
            this.rtbStatusSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatusSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbStatusSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtbStatusSave.Location = new System.Drawing.Point(48, 73);
            this.rtbStatusSave.Name = "rtbStatusSave";
            this.rtbStatusSave.ReadOnly = true;
            this.rtbStatusSave.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbStatusSave.Size = new System.Drawing.Size(287, 54);
            this.rtbStatusSave.TabIndex = 16;
            this.rtbStatusSave.Text = "не сохранено";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Статус:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEmail.Location = new System.Drawing.Point(176, 52);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(0, 13);
            this.lbEmail.TabIndex = 14;
            this.lbEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbEmail_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(8, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(329, 68);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Для уведомления разработчиков об ошибке сперва нужно сохранить информацию о ней.\r" +
                "\nПосле сохранения будет создан архив, который нужно отправить по электронной поч" +
                "те";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(7, 433);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 12;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmFormException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 463);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.pbIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormException";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        public  System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button btOk;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbComponent;
        private System.Windows.Forms.TextBox tbMethod;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        public  System.Windows.Forms.LinkLabel lbEmail;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public  System.Windows.Forms.RichTextBox rtbStatusSave;
    }
}