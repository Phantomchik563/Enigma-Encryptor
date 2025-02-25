using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Enigma_Code
{
    public partial class settingsForm : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        string localVer = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        public string[] languages = { "English", "Русский" };

        public settingsForm()
        {
            InitializeComponent();
        }

        private void panelApp_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panelApp_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panelApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void buttonCloseApp_MouseEnter(object sender, EventArgs e)
        {
            buttonCloseApp.BackColor = Color.Red;
        }

        private void buttonCloseApp_MouseLeave(object sender, EventArgs e)
        {
            buttonCloseApp.BackColor = panelApp.BackColor;
        }

        private void buttonCloseApp_Click(object sender, EventArgs e)
        {
            formMain formMain = new formMain();
            formMain.Show();
            this.Close();
        }

        private void buttonMinApp_MouseEnter(object sender, EventArgs e)
        {
            buttonMinApp.BackColor = Color.FromArgb(140, 140, 255);
        }

        private void buttonMinApp_MouseLeave(object sender, EventArgs e)
        {
            buttonMinApp.BackColor = panelApp.BackColor;
        }

        private void buttonMinApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void darkThemeCheck()
        {
            if (Properties.Settings.Default.darkTheme == false)
            {
                BackColor = Color.FromArgb(230, 230, 230);
                panelApp.BackColor = Color.FromArgb(245, 245, 245);
                labelApp.ForeColor = Color.FromArgb(0, 0, 0);
                buttonCloseApp.ForeColor = labelApp.ForeColor;
                buttonMinApp.ForeColor = labelApp.ForeColor;
                checkBoxDarkTheme.ForeColor = labelApp.ForeColor;
            }
            else
            {
                BackColor = Color.FromArgb(30, 30, 30);

                labelApp.ForeColor = Color.FromArgb(250, 250, 250);
                panelApp.BackColor = Color.FromArgb(50, 50, 50);
                buttonCloseApp.ForeColor = labelApp.ForeColor;
                buttonMinApp.ForeColor = labelApp.ForeColor;
                checkBoxDarkTheme.ForeColor = labelApp.ForeColor;
            }
        }

        private void checkBoxDarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDarkTheme.Checked)
            {
                Properties.Settings.Default.darkTheme = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.darkTheme = false;
                Properties.Settings.Default.Save();
            }
            darkThemeCheck();
        }
    }
}
