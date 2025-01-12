namespace Enigma_Code
{
    partial class formMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxDarkTheme = new System.Windows.Forms.CheckBox();
            this.textBoxToEncr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxToDecr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxEncr = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDecr = new System.Windows.Forms.RichTextBox();
            this.textBoxKey1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonKeyLoad = new System.Windows.Forms.Button();
            this.richTextBoxChars = new System.Windows.Forms.RichTextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.panelApp = new System.Windows.Forms.Panel();
            this.labelApp = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.buttonMinApp = new System.Windows.Forms.Button();
            this.buttonCloseApp = new System.Windows.Forms.Button();
            this.comboBoxLang = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxKey2 = new System.Windows.Forms.TextBox();
            this.panelApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // checkBoxDarkTheme
            // 
            this.checkBoxDarkTheme.AutoSize = true;
            this.checkBoxDarkTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDarkTheme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxDarkTheme.Location = new System.Drawing.Point(853, 452);
            this.checkBoxDarkTheme.Name = "checkBoxDarkTheme";
            this.checkBoxDarkTheme.Size = new System.Drawing.Size(112, 20);
            this.checkBoxDarkTheme.TabIndex = 0;
            this.checkBoxDarkTheme.Text = "Тёмная тема";
            this.checkBoxDarkTheme.UseVisualStyleBackColor = true;
            this.checkBoxDarkTheme.CheckedChanged += new System.EventHandler(this.checkBoxDarkTheme_CheckedChanged);
            // 
            // textBoxToEncr
            // 
            this.textBoxToEncr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxToEncr.Location = new System.Drawing.Point(12, 62);
            this.textBoxToEncr.Multiline = true;
            this.textBoxToEncr.Name = "textBoxToEncr";
            this.textBoxToEncr.Size = new System.Drawing.Size(290, 173);
            this.textBoxToEncr.TabIndex = 2;
            this.textBoxToEncr.TextChanged += new System.EventHandler(this.textBoxToEncr_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Шифровка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дешифровка";
            // 
            // textBoxToDecr
            // 
            this.textBoxToDecr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxToDecr.Location = new System.Drawing.Point(12, 272);
            this.textBoxToDecr.Multiline = true;
            this.textBoxToDecr.Name = "textBoxToDecr";
            this.textBoxToDecr.Size = new System.Drawing.Size(290, 173);
            this.textBoxToDecr.TabIndex = 5;
            this.textBoxToDecr.TextChanged += new System.EventHandler(this.textBoxToDecr_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Niagara Engraved", 120.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 171);
            this.label3.TabIndex = 11;
            this.label3.Text = ">";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Niagara Engraved", 120.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 171);
            this.label4.TabIndex = 12;
            this.label4.Text = ">";
            // 
            // richTextBoxEncr
            // 
            this.richTextBoxEncr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxEncr.Location = new System.Drawing.Point(430, 62);
            this.richTextBoxEncr.Name = "richTextBoxEncr";
            this.richTextBoxEncr.Size = new System.Drawing.Size(368, 171);
            this.richTextBoxEncr.TabIndex = 13;
            this.richTextBoxEncr.Text = "";
            // 
            // richTextBoxDecr
            // 
            this.richTextBoxDecr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDecr.Location = new System.Drawing.Point(430, 272);
            this.richTextBoxDecr.Name = "richTextBoxDecr";
            this.richTextBoxDecr.Size = new System.Drawing.Size(368, 171);
            this.richTextBoxDecr.TabIndex = 14;
            this.richTextBoxDecr.Text = "";
            // 
            // textBoxKey1
            // 
            this.textBoxKey1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKey1.Location = new System.Drawing.Point(430, 239);
            this.textBoxKey1.Multiline = true;
            this.textBoxKey1.Name = "textBoxKey1";
            this.textBoxKey1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxKey1.Size = new System.Drawing.Size(26, 27);
            this.textBoxKey1.TabIndex = 15;
            this.textBoxKey1.Text = "00";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(758, 239);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Maximum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(40, 29);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 16;
            // 
            // buttonKeyLoad
            // 
            this.buttonKeyLoad.BackColor = System.Drawing.Color.Red;
            this.buttonKeyLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKeyLoad.FlatAppearance.BorderSize = 0;
            this.buttonKeyLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonKeyLoad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonKeyLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonKeyLoad.Location = new System.Drawing.Point(301, 239);
            this.buttonKeyLoad.Name = "buttonKeyLoad";
            this.buttonKeyLoad.Size = new System.Drawing.Size(123, 27);
            this.buttonKeyLoad.TabIndex = 17;
            this.buttonKeyLoad.Text = "Загрузить ключ";
            this.buttonKeyLoad.UseVisualStyleBackColor = false;
            this.buttonKeyLoad.Click += new System.EventHandler(this.buttonKeyLoad_Click);
            // 
            // richTextBoxChars
            // 
            this.richTextBoxChars.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxChars.Location = new System.Drawing.Point(804, 62);
            this.richTextBoxChars.Name = "richTextBoxChars";
            this.richTextBoxChars.Size = new System.Drawing.Size(161, 381);
            this.richTextBoxChars.TabIndex = 18;
            this.richTextBoxChars.Text = "";
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar2.Location = new System.Drawing.Point(494, 239);
            this.progressBar2.MarqueeAnimationSpeed = 50;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(266, 29);
            this.progressBar2.Step = 1;
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Help;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 454);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "V-1.19.6";
            // 
            // panelApp
            // 
            this.panelApp.Controls.Add(this.labelApp);
            this.panelApp.Controls.Add(this.pictureBoxIcon);
            this.panelApp.Controls.Add(this.buttonMinApp);
            this.panelApp.Controls.Add(this.buttonCloseApp);
            this.panelApp.Location = new System.Drawing.Point(0, 0);
            this.panelApp.Name = "panelApp";
            this.panelApp.Size = new System.Drawing.Size(977, 28);
            this.panelApp.TabIndex = 24;
            this.panelApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panelApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panelApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApp.Location = new System.Drawing.Point(34, 6);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(126, 19);
            this.labelApp.TabIndex = 28;
            this.labelApp.Text = "Enigma Encryptor";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackgroundImage = global::Enigma_Code.Properties.Resources.encryption_icon_216177_fotor_20240419182913;
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxIcon.Image = global::Enigma_Code.Properties.Resources.encryption_icon_216177_fotor_20240419182913;
            this.pictureBoxIcon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(28, 28);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 27;
            this.pictureBoxIcon.TabStop = false;
            // 
            // buttonMinApp
            // 
            this.buttonMinApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinApp.FlatAppearance.BorderSize = 0;
            this.buttonMinApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinApp.Location = new System.Drawing.Point(899, 0);
            this.buttonMinApp.Name = "buttonMinApp";
            this.buttonMinApp.Size = new System.Drawing.Size(39, 28);
            this.buttonMinApp.TabIndex = 26;
            this.buttonMinApp.Text = "—";
            this.buttonMinApp.UseVisualStyleBackColor = true;
            this.buttonMinApp.Click += new System.EventHandler(this.button5_Click);
            this.buttonMinApp.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.buttonMinApp.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // buttonCloseApp
            // 
            this.buttonCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCloseApp.FlatAppearance.BorderSize = 0;
            this.buttonCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCloseApp.Location = new System.Drawing.Point(938, 0);
            this.buttonCloseApp.Name = "buttonCloseApp";
            this.buttonCloseApp.Size = new System.Drawing.Size(39, 28);
            this.buttonCloseApp.TabIndex = 25;
            this.buttonCloseApp.Text = "X";
            this.buttonCloseApp.UseVisualStyleBackColor = true;
            this.buttonCloseApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button4_MouseClick);
            this.buttonCloseApp.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            this.buttonCloseApp.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            // 
            // comboBoxLang
            // 
            this.comboBoxLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxLang.FormattingEnabled = true;
            this.comboBoxLang.Location = new System.Drawing.Point(804, 34);
            this.comboBoxLang.Name = "comboBoxLang";
            this.comboBoxLang.Size = new System.Drawing.Size(161, 24);
            this.comboBoxLang.TabIndex = 25;
            this.comboBoxLang.SelectedIndexChanged += new System.EventHandler(this.comboBoxLang_SelectedIndexChanged);
            // 
            // textBoxKey2
            // 
            this.textBoxKey2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKey2.Location = new System.Drawing.Point(462, 239);
            this.textBoxKey2.Multiline = true;
            this.textBoxKey2.Name = "textBoxKey2";
            this.textBoxKey2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxKey2.Size = new System.Drawing.Size(26, 27);
            this.textBoxKey2.TabIndex = 20;
            this.textBoxKey2.Text = "00";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(977, 484);
            this.Controls.Add(this.comboBoxLang);
            this.Controls.Add(this.panelApp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxKey2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.richTextBoxChars);
            this.Controls.Add(this.buttonKeyLoad);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxKey1);
            this.Controls.Add(this.richTextBoxDecr);
            this.Controls.Add(this.richTextBoxEncr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxToDecr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxToEncr);
            this.Controls.Add(this.checkBoxDarkTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.Text = "Enigma Code";
            this.panelApp.ResumeLayout(false);
            this.panelApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkBoxDarkTheme;
        private System.Windows.Forms.TextBox textBoxToEncr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxToDecr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxEncr;
        private System.Windows.Forms.RichTextBox richTextBoxDecr;
        private System.Windows.Forms.TextBox textBoxKey1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonKeyLoad;
        private System.Windows.Forms.RichTextBox richTextBoxChars;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelApp;
        private System.Windows.Forms.Button buttonCloseApp;
        private System.Windows.Forms.Button buttonMinApp;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelApp;
        private System.Windows.Forms.ComboBox comboBoxLang;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textBoxKey2;
    }
}

