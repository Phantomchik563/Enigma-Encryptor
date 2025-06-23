using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Enigma_Code
{
    public partial class formMain : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        string localVer = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        // все символы алфавита
        public char[] chars = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
        'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
        'ю', 'я', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '.', ',', ' ', 'a',
        'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
        't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-', '=', 'А', 'Б', 'В', 'Г',
        'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
        'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
        'Z', '*', '\n','\r', '\\', '_', '"', '%', '#', '@', '$', ';', ':', '^', '>', '<', '&', '[', ']',
        '{', '}', '`'};

        // исходный массив шифра
        public char[] code = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
        'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
        'ю', 'я', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '.', ',', ' ', 'a',
        'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
        't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-', '=', 'А', 'Б', 'В', 'Г',
        'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
        'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 
        'Z', '*', '\n','\r', '\\', '_', '"', '%', '#', '@', '$', ';', ':', '^', '>', '<', '&', '[', ']',
        '{', '}', '`'};

        // символы-разделители
        public char[] splitChars = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
        'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
        'ю', 'я', '?', '!', '.', ',', ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 
        'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
        't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-', '=', 'А', 'Б', 'В', 'Г',
        'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
        'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
        'Z', '*', '_', '"', '%', '#', '@', '$', ';', ':', '^', '>', '<', '&', '[', ']',
        '{', '}', '`'};

        public string[] languages = {"English", "Русский"};
        int charsLength, lang;
        string key1, key2, key = "00000";
        char temp;
        string[] textToDecr;
        int[] keyNums = new int[2]; // [0] - Ширина отступа между заменяемых элементов массива    [1] - Сколько раз нужно повторить цикл
        bool darkTheme;

        public formMain()
        {
            InitializeComponent();
            textBoxKey.MaxLength = 5;
            charsLength = chars.Length;

            textBoxKey.Text = Properties.Settings.Default.Key;
            label5.Text = "V-" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            Properties.Settings.Default.Upgrade();
        }

        private void buttonKeyLoad_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < chars.Length; i++) code[i] = chars[i]; // Сброс алфавита 

            if (textToDecr != null && textToDecr.Length > 2 && int.TryParse(textToDecr[textToDecr.Length - 1], out int number))
            {
                keySeparator(strReverse(textToDecr[textToDecr.Length - 1]));
                textBoxKey.Text = key;
            }
            else
            {
                keySeparator(textBoxKey.Text);
            }

            Properties.Settings.Default.Key = key;
            Properties.Settings.Default.Save();

            if (textBoxKey.Text == key)
            {
                richTextBoxChars.AppendText(key);

                keyNums[0] = int.Parse(key1);
                keyNums[1] = int.Parse(key2);

                progressBar.Value = 0;

                int u = 0, j = 0, k = 0, y = 0, key_2_modded = 1;

                while (y < 3)
                {
                    key_2_modded = key_2_modded * keyNums[1];
                    y++;
                }

                progressBar.Maximum = key_2_modded;

                while (k < key_2_modded) // Шифровка алфавита
                {

                    while (j + keyNums[0] + u < code.Length)
                    {
                        temp = code[j];
                        code[j] = code[j + keyNums[0] + u];
                        code[j + keyNums[0] + u] = temp;
                        j++;
                    }

                    progressBar.Value = k;

                    k++;
                    u++;
                    if (u > charsLength + 1)
                    {
                        u = u - charsLength;
                    }

                    j = 0;
                }

                richTextBoxChars.Text = new string(code) + "\n \n[" + charsLength + "]";
            }
            textBoxToDecr_TextChanged(sender, e);
        }
        
        private string strReverse(string str)
        {
            char[] outArr = str.ToCharArray();
            Array.Reverse(outArr);
            return new string(outArr);
        }

        private void mainEncryptionProcedure()
        {

        }

        private void keySeparator(string keyToSep)
        {
            int key1_keySep = 0, key2_keySep = 0, keyNotSeparated;
            keyNotSeparated = int.Parse(keyToSep);

            if (keyNotSeparated > 0 && keyNotSeparated < 10)
            {
                key1_keySep++;
                key2_keySep = keyNotSeparated;
            }
            else if (keyNotSeparated > 9 && keyNotSeparated < 100)
            {
                key1_keySep = keyNotSeparated / 10;
                key2_keySep = keyNotSeparated % 10;
            }
            else if (keyNotSeparated > 99 && keyNotSeparated < 1000)
            {
                key1_keySep = keyNotSeparated / 10;
                key2_keySep = keyNotSeparated % 100;
            }
            else if (keyNotSeparated > 999 && keyNotSeparated < 10000)
            {
                key1_keySep = keyNotSeparated / 100;
                key2_keySep = keyNotSeparated % 100;
            }
            else if (keyNotSeparated > 9999 && keyNotSeparated < 100000)
            {
                key1_keySep = keyNotSeparated / 1000;
                key2_keySep = keyNotSeparated % 1000;
            }
            key = keyNotSeparated.ToString();
            key1 = key1_keySep.ToString();
            key2 = key2_keySep.ToString();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            buttonCloseApp.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            buttonCloseApp.BackColor = panelApp.BackColor;
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.Save();
            System.Windows.Forms.Application.Exit();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            buttonMinApp.BackColor = Color.FromArgb(140,140,255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            buttonMinApp.BackColor = panelApp.BackColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void langCheck()
        {
            if (Properties.Settings.Default.Language == 1)
            {
                lang = 1;
                label1.Text = "Шифровка";
                label2.Text = "Дешифровка";

                buttonKeyLoad.Text = "Загрузить ключ";
                buttonKeyLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                toolTip.SetToolTip(progressBarConfirm, "Ключ в полях соответствует загруженному");
                toolTip.SetToolTip(label5, "Версия " + localVer + ", от 09.06.2024");

                toolTip.SetToolTip(textBoxKey, "Поле ключа");

                toolTip.SetToolTip(buttonKeyLoad, "Загрузить этот ключ");

                toolTip.SetToolTip(richTextBoxChars, "Все зашифрованные символы");
            }
            else if (Properties.Settings.Default.Language == 0)
            {
                lang = 0;
                label1.Text = "Encryption";
                label2.Text = "Decryption";

                buttonKeyLoad.Text = "Load key";
                buttonKeyLoad.Font = new System.Drawing.Font("Tahoma", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                toolTip.SetToolTip(progressBarConfirm, "The key in the fields same with the loaded key");
                toolTip.SetToolTip(label5, "Version " + localVer + ", of 09.06.2024");

                toolTip.SetToolTip(textBoxKey, "Field for key");

                toolTip.SetToolTip(buttonKeyLoad, "Load this key");

                toolTip.SetToolTip(richTextBoxChars, "All encrypted symbols");
            }
        }

        private void textBoxToEncr_TextChanged(object sender, EventArgs e) // Изменение текста в боксе -> перешифровка текста
        {
            int i = 0;
            string txtEncrypted = ""; // Переменная готового зашифрованного текста
            char[] textToEncr = textBoxToEncr.Text.ToCharArray();
            Random random = new Random();

            while (i < textToEncr.Length)
            {
                string letter;
                long index;

                if ((i + 1) % 2 == 0)
                {
                    index = Array.IndexOf(code, textToEncr[i]) * ((i + 7));
                    letter = index.ToString();
                }
                else if ((i + 1) % 3 == 0)
                {
                    index = Array.IndexOf(code, textToEncr[i]) * ((i + 2) ^ 2);
                    letter = index.ToString();
                }
                else
                {
                    index = Array.IndexOf(code, textToEncr[i]) * (i + 2);
                    letter = index.ToString();
                }


                txtEncrypted = txtEncrypted + letter + splitChars[random.Next(0, splitChars.Length - 1)];
                i++;
            }
            txtEncrypted = txtEncrypted + strReverse(key);
            richTextBoxEncr.Text = txtEncrypted;
        }

        private void textBoxToDecr_TextChanged(object sender, EventArgs e)
        {
            richTextBoxDecr.Clear(); // Дешифровка текста
            textToDecr = null;

            int j = 0, k = 0;
            string txtDecrypted = "";

            while (k < textBoxToDecr.Text.Length)
            {
                textToDecr = textBoxToDecr.Text.Split(splitChars);
                k++;

                while (j < textToDecr.Length - 1 && textToDecr != null)
                {
                    if (textToDecr[j] != "" || textToDecr[j] != null)
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            txtDecrypted = txtDecrypted + code[int.Parse(textToDecr[j]) / ((j + 7))];
                        }
                        else if ((j + 1) % 3 == 0)
                        {
                            txtDecrypted = txtDecrypted + code[int.Parse(textToDecr[j]) / ((j + 2) ^ 2)];
                        }
                        else
                        {
                            txtDecrypted = txtDecrypted + code[int.Parse(textToDecr[j]) / (j + 2)];
                        }
                    }
                    else
                    {
                        textToDecr[j] = "/";
                    }
                    j++;
                }
            }

            richTextBoxDecr.Text = txtDecrypted;
        }

        private void darkThemeCheck()
        {
            if (Properties.Settings.Default.darkTheme == false)
            {
                darkTheme = false;
                label1.ForeColor = Color.FromArgb(0, 0, 0);
                label2.ForeColor = Color.FromArgb(0, 0, 0);
                label3.ForeColor = Color.FromArgb(0, 0, 0);
                label4.ForeColor = Color.FromArgb(0, 0, 0);
                label5.ForeColor = Color.FromArgb(0, 0, 0);

                BackColor = Color.FromArgb(230, 230, 230);

                textBoxToEncr.BackColor = BackColor;
                textBoxToDecr.BackColor = BackColor;

                textBoxToEncr.ForeColor = label1.ForeColor;
                textBoxToDecr.ForeColor = label1.ForeColor;

                textBoxKey.BackColor = BackColor;

                textBoxKey.ForeColor = label1.ForeColor;

                progressBarConfirm.BackColor = BackColor;
                progressBar.BackColor = BackColor;

                progressBarConfirm.ForeColor = label1.ForeColor;
                progressBar.ForeColor = label1.ForeColor;

                richTextBoxEncr.BackColor = BackColor;
                richTextBoxDecr.BackColor = BackColor;
                richTextBoxChars.BackColor = BackColor;

                richTextBoxEncr.ForeColor = label1.ForeColor;
                richTextBoxDecr.ForeColor = label1.ForeColor;
                richTextBoxChars.ForeColor = label1.ForeColor;

                buttonKeyLoad.ForeColor = label1.ForeColor;

                panelApp.BackColor = Color.FromArgb(245, 245, 245);

                labelApp.ForeColor = label1.ForeColor;

                buttonCloseApp.ForeColor = label1.ForeColor;
                buttonMinApp.ForeColor = label1.ForeColor;

                buttonSettings.Image = Properties.Resources.Settings_Icon_LightTheme;
            }
            else if(Properties.Settings.Default.darkTheme == true)
            {
                darkTheme = true;
                label1.ForeColor = Color.FromArgb(250, 250, 250);
                label2.ForeColor = Color.FromArgb(250, 250, 250);
                label3.ForeColor = Color.FromArgb(250, 250, 250);
                label4.ForeColor = Color.FromArgb(250, 250, 250);
                label5.ForeColor = Color.FromArgb(250, 250, 250);
                labelApp.ForeColor = label1.ForeColor;

                BackColor = Color.FromArgb(30, 30, 30);

                textBoxToEncr.BackColor = BackColor;
                textBoxToDecr.BackColor = BackColor;

                textBoxToEncr.ForeColor = label1.ForeColor;
                textBoxToDecr.ForeColor = label1.ForeColor;

                textBoxKey.BackColor = BackColor;

                textBoxKey.ForeColor = label1.ForeColor;

                progressBarConfirm.BackColor = BackColor;
                progressBar.BackColor = BackColor;

                progressBarConfirm.ForeColor = label1.ForeColor;
                progressBar.ForeColor = label1.ForeColor;

                richTextBoxEncr.BackColor = BackColor;
                richTextBoxDecr.BackColor = BackColor;
                richTextBoxChars.BackColor = BackColor;

                richTextBoxEncr.ForeColor = label1.ForeColor;
                richTextBoxDecr.ForeColor = label1.ForeColor;
                richTextBoxChars.ForeColor = label1.ForeColor;

                buttonKeyLoad.ForeColor = label1.ForeColor;

                panelApp.BackColor = Color.FromArgb(50, 50, 50);

                buttonCloseApp.ForeColor = label1.ForeColor;
                buttonMinApp.ForeColor = label1.ForeColor;

                buttonSettings.Image = Properties.Resources.Settings_Icon_DarkTheme;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxKey.Text, out int number))
            {
                if (textBoxKey.Text == key)
                {
                    progressBarConfirm.Value = 1;
                }
                else
                {
                    progressBarConfirm.Value = 0;
                }
            }
            langCheck();
            darkThemeCheck();
            Properties.Settings.Default.Save();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            formMain formMain = new formMain();
            settingsForm SettingsForm = new settingsForm();
            SettingsForm.Show();
            SettingsForm.Activate();
            Properties.Settings.Default.darkTheme = darkTheme;
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }
    }
}
