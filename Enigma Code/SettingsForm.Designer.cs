namespace Enigma_Code
{
    partial class settingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.labelApp = new System.Windows.Forms.Label();
            this.panelApp = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.buttonMinApp = new System.Windows.Forms.Button();
            this.buttonCloseApp = new System.Windows.Forms.Button();
            this.comboBoxLang = new System.Windows.Forms.ComboBox();
            this.checkBoxDarkTheme = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApp.Location = new System.Drawing.Point(34, 6);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(62, 19);
            this.labelApp.TabIndex = 28;
            this.labelApp.Text = "Settings";
            // 
            // panelApp
            // 
            this.panelApp.Controls.Add(this.labelApp);
            this.panelApp.Controls.Add(this.pictureBoxIcon);
            this.panelApp.Controls.Add(this.buttonMinApp);
            this.panelApp.Controls.Add(this.buttonCloseApp);
            this.panelApp.Location = new System.Drawing.Point(-1, -1);
            this.panelApp.Name = "panelApp";
            this.panelApp.Size = new System.Drawing.Size(645, 28);
            this.panelApp.TabIndex = 25;
            this.panelApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelApp_MouseDown);
            this.panelApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelApp_MouseMove);
            this.panelApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelApp_MouseUp);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxIcon.Image = global::Enigma_Code.Properties.Resources.App_Settings_Icon;
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
            this.buttonMinApp.Location = new System.Drawing.Point(567, 0);
            this.buttonMinApp.Name = "buttonMinApp";
            this.buttonMinApp.Size = new System.Drawing.Size(39, 28);
            this.buttonMinApp.TabIndex = 26;
            this.buttonMinApp.Text = "—";
            this.buttonMinApp.UseVisualStyleBackColor = true;
            this.buttonMinApp.Click += new System.EventHandler(this.buttonMinApp_Click);
            this.buttonMinApp.MouseEnter += new System.EventHandler(this.buttonMinApp_MouseEnter);
            this.buttonMinApp.MouseLeave += new System.EventHandler(this.buttonMinApp_MouseLeave);
            // 
            // buttonCloseApp
            // 
            this.buttonCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCloseApp.FlatAppearance.BorderSize = 0;
            this.buttonCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCloseApp.Location = new System.Drawing.Point(606, 0);
            this.buttonCloseApp.Name = "buttonCloseApp";
            this.buttonCloseApp.Size = new System.Drawing.Size(39, 28);
            this.buttonCloseApp.TabIndex = 25;
            this.buttonCloseApp.Text = "X";
            this.buttonCloseApp.UseVisualStyleBackColor = true;
            this.buttonCloseApp.Click += new System.EventHandler(this.buttonCloseApp_Click);
            this.buttonCloseApp.MouseEnter += new System.EventHandler(this.buttonCloseApp_MouseEnter);
            this.buttonCloseApp.MouseLeave += new System.EventHandler(this.buttonCloseApp_MouseLeave);
            // 
            // comboBoxLang
            // 
            this.comboBoxLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxLang.FormattingEnabled = true;
            this.comboBoxLang.Location = new System.Drawing.Point(12, 92);
            this.comboBoxLang.Name = "comboBoxLang";
            this.comboBoxLang.Size = new System.Drawing.Size(161, 24);
            this.comboBoxLang.TabIndex = 30;
            this.comboBoxLang.SelectedIndexChanged += new System.EventHandler(this.comboBoxLang_SelectedIndexChanged);
            // 
            // checkBoxDarkTheme
            // 
            this.checkBoxDarkTheme.AutoSize = true;
            this.checkBoxDarkTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDarkTheme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxDarkTheme.Location = new System.Drawing.Point(12, 55);
            this.checkBoxDarkTheme.Name = "checkBoxDarkTheme";
            this.checkBoxDarkTheme.Size = new System.Drawing.Size(112, 20);
            this.checkBoxDarkTheme.TabIndex = 29;
            this.checkBoxDarkTheme.Text = "Тёмная тема";
            this.checkBoxDarkTheme.UseVisualStyleBackColor = true;
            this.checkBoxDarkTheme.CheckedChanged += new System.EventHandler(this.checkBoxDarkTheme_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 327);
            this.Controls.Add(this.comboBoxLang);
            this.Controls.Add(this.checkBoxDarkTheme);
            this.Controls.Add(this.panelApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.panelApp.ResumeLayout(false);
            this.panelApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelApp;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Panel panelApp;
        private System.Windows.Forms.Button buttonMinApp;
        private System.Windows.Forms.Button buttonCloseApp;
        private System.Windows.Forms.ComboBox comboBoxLang;
        private System.Windows.Forms.CheckBox checkBoxDarkTheme;
        private System.Windows.Forms.Timer timer;
    }
}